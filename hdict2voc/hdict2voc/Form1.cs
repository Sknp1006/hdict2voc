using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HalconDotNet;


namespace hdict2voc
{
    public partial class Form1 : Form
    {
        public delegate void WriteVocXml(VOC_DATASET voc, string s);
        public delegate void CopyImage(string s, string ss);
        public delegate void UpdateTxtBox(string s);

        WriteVocXml WriteVocXmlHelper;
        CopyImage CopyImageHelper;

        public Form1()
        {
            InitializeComponent();
            WriteVocXmlHelper = new WriteVocXml(utils.WriteVocXml);
            CopyImageHelper = new CopyImage(utils.CopyImage);

        }
        public HTuple HDict = new HTuple();
        public DLdataset dataset = new DLdataset();
        public List<sample> samples = new List<sample>();
        public HTuple hv_DictFile;
        public string saveInfoPath;



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void load_hdict_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofg = new OpenFileDialog() { Filter = "Halcon字典文件(*.hdict)|*.hdict", Title = "请选择dl_dataset" })
            {
                if (ofg.ShowDialog() == DialogResult.OK)
                {
                    hv_DictFile = ofg.FileName;
                    saveInfoPath = hv_DictFile + ".txt";
                }

                try
                {
                    richTextBox1.Text = "";
                    HDict.Dispose();
                    HOperatorSet.ReadDict(hv_DictFile, new HTuple(), new HTuple(), out HDict);
                    richTextBox1.AppendText(String.Format("成功读取文件: {0}\n", hv_DictFile.S));
                }
                catch
                {
                    if (hv_DictFile == null)
                    {
                        richTextBox1.AppendText(String.Format("未选择文件\n"));
                    }
                    else
                    {
                        richTextBox1.AppendText(String.Format("读取文件失败: {0}\n", hv_DictFile.S));
                    }

                }
            }
        }

        private void gen_xml_Click(object sender, EventArgs e)
        {
            // 生成之前清空文件目录
            System.IO.DirectoryInfo VOC = new System.IO.DirectoryInfo(textBox1.Text);
            if (VOC.Exists)
            {
                
            }
            else
            {
                VOC.Create();
            }

            System.IO.DirectoryInfo Annotations = new System.IO.DirectoryInfo(System.IO.Path.Combine(textBox1.Text, "Annotations"));
            System.IO.DirectoryInfo JPEGImages = new System.IO.DirectoryInfo(System.IO.Path.Combine(textBox1.Text, "JPEGImages"));

            if (Annotations.Exists)
            {
                Annotations.Delete(true);
                Annotations.Create();
            }
            else
            {
                Annotations.Create();
            }

            if (Annotations.Exists)
            {
                JPEGImages.Delete(true);
                JPEGImages.Create();
            }
            else
            {
                JPEGImages.Create();
            }

            GetDLDataset();
            GetDLDatasetSamples();

            //string sourcePath = dataset.image_dir.S;
            //string targetPath = System.IO.Path.Combine(textBox1.Text + , fileName);

            foreach (sample item in samples)
            {
                VOC_DATASET voc = new VOC_DATASET();
                HObject image = new HObject();
                HTuple width, height;
                string sourcePath = System.IO.Path.Combine(dataset.image_dir.S, item.image_file_name);
                HOperatorSet.ReadImage(out image, sourcePath);
                HOperatorSet.GetImageSize(image, out width, out height);

                voc.width = width;
                voc.height = height;
                voc.depth = 3;
                voc.folder = "VOC";
                voc.filename = item.image_file_name;

                // 遍历sample中的元素
                for (int i = 0; i < item.bbox_label_id.Length; i++)
                {
                    Objects obj = new Objects();
                    obj.name = dataset.class_names.TupleSelect(item.bbox_label_id.TupleSelect(i));
                    obj.xmin = item.bbox_col1.TupleSelect(i).D;
                    obj.ymin = item.bbox_row1.TupleSelect(i).D;
                    obj.xmax = item.bbox_col2.TupleSelect(i).D;
                    obj.ymax = item.bbox_row2.TupleSelect(i).D;

                    voc.objects.Add(obj);
                }
                image.Dispose();

                string targetPath = System.IO.Path.Combine(textBox1.Text, "Annotations", voc.filename.Replace(".jpg", ".xml"));
                WriteVocXmlHelper(voc, targetPath);
                this.Invoke(new Action(() => richTextBox1.AppendText(String.Format("写入xml文件: {0}\n", targetPath))));

                string destFile = System.IO.Path.Combine(textBox1.Text, "JPEGImages", voc.filename);
                CopyImageHelper(sourcePath, destFile);
                this.Invoke(new Action(() => richTextBox1.AppendText(String.Format("复制jpg文件: {0}\n", destFile))));

                richTextBox1.SelectionStart = richTextBox1.Text.Length;
                richTextBox1.ScrollToCaret();
            }

            richTextBox1.AppendText(String.Format("数据集转换成功Done！\n"));

        }
        private void GetDLDataset()
        {
            HTuple AllKeys = new HTuple();
            System.Diagnostics.Debug.Assert(HDict.Type.ToString() != "EMPTY");
            HOperatorSet.GetDictParam(HDict, "keys", new HTuple(), out AllKeys);
            if (AllKeys.Length != 0)
            {
                try
                {
                    HOperatorSet.GetDictTuple(HDict, "class_ids", out this.dataset.class_ids);
                    HOperatorSet.GetDictTuple(HDict, "class_names", out this.dataset.class_names);
                    HOperatorSet.GetDictTuple(HDict, "samples", out this.dataset.samples);
                    HOperatorSet.GetDictTuple(HDict, "image_dir", out this.dataset.image_dir);
                }
                catch
                {
                    MessageBox.Show("此文件格式不支持,无法正常读取！");
                    return;
                }
            }
            else
            {
                MessageBox.Show("hdict文件为空！");
            }
        }
        private void GetDLDatasetSamples()
        {
            HTuple selectsample = dataset.samples.TupleSelect(0);  // 遍历samples
            HTuple AllKeys = new HTuple();
            HOperatorSet.GetDictParam(selectsample, "keys", new HTuple(), out AllKeys);
            if (AllKeys.Length != 0)
            {
                richTextBox1.AppendText(String.Format("共有 {0} 个样本\n", dataset.samples.Length.ToString()));
                for (int i = 0; i < dataset.samples.Length; i++)
                {
                    selectsample = dataset.samples.TupleSelect(i);
                    HOperatorSet.GetDictParam(selectsample, "keys", new HTuple(), out AllKeys);

                    sample doi = new sample();
                    HOperatorSet.GetDictTuple(selectsample, "image_id", out doi.image_id);
                    HOperatorSet.GetDictTuple(selectsample, "image_file_name", out doi.image_file_name);
                    HOperatorSet.GetDictTuple(selectsample, "bbox_label_id", out doi.bbox_label_id);
                    HOperatorSet.GetDictTuple(selectsample, "bbox_row1", out doi.bbox_row1);
                    HOperatorSet.GetDictTuple(selectsample, "bbox_col1", out doi.bbox_col1);
                    HOperatorSet.GetDictTuple(selectsample, "bbox_row2", out doi.bbox_row2);
                    HOperatorSet.GetDictTuple(selectsample, "bbox_col2", out doi.bbox_col2);

                    samples.Add(doi);
                }
            }
            else
            {
                MessageBox.Show("此文件格式不支持,无法正常读取！");
                return;
            }
        }
    }
}
