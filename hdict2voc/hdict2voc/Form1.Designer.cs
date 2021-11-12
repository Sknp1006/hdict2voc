
namespace hdict2voc
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.load_hdict = new System.Windows.Forms.Button();
            this.gen_xml = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // load_hdict
            // 
            this.load_hdict.Location = new System.Drawing.Point(12, 12);
            this.load_hdict.Name = "load_hdict";
            this.load_hdict.Size = new System.Drawing.Size(99, 53);
            this.load_hdict.TabIndex = 1;
            this.load_hdict.Text = "载入文件(dl_dataset)";
            this.load_hdict.UseVisualStyleBackColor = true;
            this.load_hdict.Click += new System.EventHandler(this.load_hdict_Click);
            // 
            // gen_xml
            // 
            this.gen_xml.Location = new System.Drawing.Point(117, 12);
            this.gen_xml.Name = "gen_xml";
            this.gen_xml.Size = new System.Drawing.Size(75, 53);
            this.gen_xml.TabIndex = 2;
            this.gen_xml.Text = "生成";
            this.gen_xml.UseVisualStyleBackColor = true;
            this.gen_xml.Click += new System.EventHandler(this.gen_xml_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(311, 44);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(211, 21);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = "D:\\VOC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(210, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "VOC数据集路径：";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 71);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(510, 422);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 505);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.gen_xml);
            this.Controls.Add(this.load_hdict);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button load_hdict;
        private System.Windows.Forms.Button gen_xml;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

