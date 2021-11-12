using System.Xml;


namespace hdict2voc
{
    class utils
    {
        public static void WriteVocXml(VOC_DATASET data, string file)
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(file, System.Text.Encoding.UTF8);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement(VOC_DATASET.ANNOTATION);

            xmlWriter.WriteStartElement(VOC_DATASET.FOLDER);
            xmlWriter.WriteString(data.folder);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement(VOC_DATASET.FILENAME);
            xmlWriter.WriteString(data.filename);
            xmlWriter.WriteEndElement();

            #region SIZE
            xmlWriter.WriteStartElement(VOC_DATASET.SIZE);
            xmlWriter.WriteStartElement(VOC_DATASET.WIDTH);
            xmlWriter.WriteString(data.width.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement(VOC_DATASET.HEIGHT);
            xmlWriter.WriteString(data.height.ToString());
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement(VOC_DATASET.DEPTH);
            xmlWriter.WriteString(data.depth.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            #endregion

            xmlWriter.WriteStartElement(VOC_DATASET.SEGMENTED);
            xmlWriter.WriteString(data.segmented.ToString());
            xmlWriter.WriteEndElement();

            #region OBJECT
            foreach (Objects item in data.objects)
            {
                xmlWriter.WriteStartElement(VOC_DATASET.OBJECT);  // start object

                xmlWriter.WriteStartElement(VOC_DATASET.NAME);
                xmlWriter.WriteString(item.name);
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement(VOC_DATASET.TRUNCATED);
                xmlWriter.WriteString(item.truncated.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement(VOC_DATASET.DIFFICULT);
                xmlWriter.WriteString(item.difficult.ToString());
                xmlWriter.WriteEndElement();

                xmlWriter.WriteStartElement(VOC_DATASET.BNDBOX);
                xmlWriter.WriteStartElement(VOC_DATASET.XMIN);
                xmlWriter.WriteString(item.xmin.ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement(VOC_DATASET.YMIN);
                xmlWriter.WriteString(item.ymin.ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement(VOC_DATASET.XMAX);
                xmlWriter.WriteString(item.xmax.ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.WriteStartElement(VOC_DATASET.YMAX);
                xmlWriter.WriteString(item.ymax.ToString());
                xmlWriter.WriteEndElement();
                xmlWriter.WriteEndElement();

                xmlWriter.WriteEndElement();  // end object
            }
            #endregion


            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

            xmlWriter.Flush();
            xmlWriter.Close();
        }

        public static void CopyImage(string sourceFile, string destFile)
        {
            System.IO.File.Copy(sourceFile, destFile, true);
        }
    }
}
