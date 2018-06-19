using System;
using System.IO;
using System.Xml;

namespace demoprojMVC.Common
{
    public class TableIDCodingRule
    {
        private static string xmlfile = "TableIDCodingRule.xml";
        protected static string App_DataPath
        {
            get
            {
                return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data\\"); //SDXml.App_DataPath;
            }
        }

        public static string newID(string tablename, string baseid)
        {
            XmlDocument xml = new XmlDocument();
            string result2;
            try
            {
                xml.Load(TableIDCodingRule.App_DataPath + TableIDCodingRule.xmlfile);
                string xpath = string.Format("/TableIDCodingRule/Item[@Tablename='{0}']", tablename.ToLower());
                XmlNode xn = xml.DocumentElement.SelectSingleNode(xpath);
                if (xn == null)
                {
                    throw new Exception("error in loading xmlfile");
                }
                string codepref = xn.Attributes["Codepref"].Value;
                int i = CcConvert.StrToInt(xn.Attributes["Timestamp"].Value, 0);
                string mils = DateTime.Now.Millisecond.ToString("d6").Substring(6 - i, i);
                int codelen = CcConvert.StrToInt(xn.Attributes["AutoCodeLength"].Value, 0);
                if (codelen == 0)
                {
                    throw new Exception("定义代码可变长度不能为0");
                }
                if (baseid == "")
                {
                    baseid = codepref + 0.ToString("d" + codelen) + mils;
                }
                int varid = Convert.ToInt32(baseid.Substring(codepref.Length, codelen), 10);
                string result = codepref + (varid + 1).ToString("d" + codelen) + mils;
                result2 = result;
            }
            catch (Exception)
            {
                result2 = "";
            }
            return result2;
        }


    }

}