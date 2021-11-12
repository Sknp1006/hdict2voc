using System.Collections.Generic;
using HalconDotNet;

namespace hdict2voc
{
    public class DLdataset
    {
        public HTuple class_ids;
        public HTuple class_names;
        public HTuple image_dir;
        public HTuple samples;
        //public HTuple dlsample_dir;
    }

    public class sample
    {
        public HTuple image_id;
        public HTuple image_file_name;
        public HTuple bbox_label_id;
        public HTuple bbox_col1;
        public HTuple bbox_row1;
        public HTuple bbox_col2;
        public HTuple bbox_row2;
        public HTuple dlsample_file_name;
    }

    /// <summary>
    /// 表示一个样本
    /// </summary>
    public class VOC_DATASET
    {
        #region 节点字段
        public const string ANNOTATION = "annotation";
        /// <summary>
        /// 文件夹（无影响）
        /// </summary>
        public const string FOLDER = "folder";
        /// <summary>
        /// 图片文件名
        /// </summary>
        public const string FILENAME = "filename";
        /// <summary>
        /// 文件宽高及通道数
        /// </summary>
        public const string SIZE = "size";
        /// <summary>
        /// 图片宽度
        /// </summary>
        public const string WIDTH = "width";
        /// <summary>
        /// 图片高度
        /// </summary>
        public const string HEIGHT = "height";
        /// <summary>
        /// 图片通道数
        /// </summary>
        public const string DEPTH = "depth";
        /// <summary>
        /// 是否用于分割（在图像物体识别中01无所谓）
        /// </summary>
        public const string SEGMENTED = "segmented";
        /// <summary>
        /// 标记类别
        /// </summary>
        public const string OBJECT = "object";
        /// <summary>
        /// 分类名称
        /// </summary>
        public const string NAME = "name";
        ///// <summary>
        ///// 拍摄角度
        ///// </summary>
        //public const string POSE = "pose";
        /// <summary>
        /// 是否被截断
        /// </summary>
        public const string TRUNCATED = "truncated";
        /// <summary>
        /// 是否难以识别
        /// </summary>
        public const string DIFFICULT = "difficult";
        /// <summary>
        /// 坐标信息
        /// </summary>
        public const string BNDBOX = "bndbox";
        /// <summary>
        /// column1
        /// </summary>
        public const string XMIN = "xmin";
        /// <summary>
        /// row1
        /// </summary>
        public const string YMIN = "ymin";
        /// <summary>
        /// column2
        /// </summary>
        public const string XMAX = "xmax";
        /// <summary>
        /// row2
        /// </summary>
        public const string YMAX = "ymax";
        #endregion

        public string folder = string.Empty;
        public string filename = string.Empty;
        public int width = 0;
        public int height = 0;
        public int depth = 3;
        public int segmented = 1;

        public List<Objects> objects = new List<Objects>();
    }
    
    public class Objects
    {
        public string name = string.Empty;
        public int truncated = 0;
        public int difficult = 0;
        public double xmin = 0;
        public double ymin = 0;
        public double xmax = 0;
        public double ymax = 0;
    }

}
