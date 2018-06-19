using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace demoprojMVC.UI.Helpers
{
    public class XmlHelper
    {
        public static string xmlFileRootPath { get { return AppDomain.CurrentDomain.BaseDirectory + @"\App_Data\"; } }
        /// <summary>
        /// linq获取xml文件节点的内容 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="filter"></param>
        /// <returns>用于下拉框的List</returns>
        public static List<SelectListItem> GetListByXpath(string filePath, string filter, string selected = "", string textElem="Text",string valueElem ="DValue", bool needFindChildElems = true)
        {
            if (!filePath.Contains("\\"))
                filePath = xmlFileRootPath + filePath;
            if (!File.Exists(filePath))
                return null;
            try
            {
                XDocument xdc = XDocument.Load(filePath);
                IEnumerable<XElement> elems = xdc.XPathSelectElements(filter);
                if (needFindChildElems)
                    elems = elems.Elements();
                List<SelectListItem> selectList = ElemsTransferSelectListItems(elems, selected,textElem,valueElem).ToList();
                return selectList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// linq获取xml文件节点的内容 用于SimpleData.xml文件
        /// </summary>
        /// <param name="firstEleValue">第一节点的Value值</param>
        /// <returns>用于下拉框的List</returns>
        public static List<SelectListItem> GetListByXpath(string firstEleValue, string selected = "")
        {
            string filePath = xmlFileRootPath + "SimpleData.xml";
            if (!File.Exists(filePath))
                return null;
            try
            {
                string filter = string.Format("/DD/DItems[@DValue='{0}']", firstEleValue);
                XDocument xdc = XDocument.Load(filePath);
                IEnumerable<XElement> elems = xdc.XPathSelectElement(filter).Elements();
                List<SelectListItem> selectList = ElemsTransferSelectListItems(elems, selected).ToList();
                return selectList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        /// <summary>
        /// 将IEnumerable<XElement> 转换为 IEnumerable<SelectListItem>
        /// </summary>
        /// <param name="elems"></param>
        /// <param name="selected"></param>
        /// <returns></returns>
        private static IEnumerable<SelectListItem> ElemsTransferSelectListItems(IEnumerable<XElement> elems,string selected, string textElem="Text", string valueElem="DValue")
        {
            List<SelectListItem> selectList = new List<SelectListItem>();
            SelectListItem temp = null;
            foreach (XElement element in elems)
            {
                temp = new SelectListItem
                {
                    Text = element.Attribute(textElem).Value,
                    Value = element.Attribute(valueElem).Value

                };
                if (!string.IsNullOrEmpty(selected) && selected == temp.Value)
                    temp.Selected = true;
                selectList.Add(temp);
            }
            return selectList;
        } 
        /// <summary>
        /// 通过xpath 返回指定的xml属性值
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="filter"></param>
        /// <param name="returnValue"></param>
        /// <returns></returns>
        public static string GetOneByXPath(string filePath, string filter, string returnValue)
        {
            if (!filePath.Contains("\\"))
                filePath = xmlFileRootPath + filePath;
            if (!File.Exists(filePath))
                return "";
            try
            {

                XDocument xdc = XDocument.Load(filePath);
                XElement elem = xdc.XPathSelectElement(filter);
                return elem.Attribute(returnValue).Value;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// 获取一个元素的某一属性值 用于SimpleData.xml文件
        /// </summary>
        /// <param name="firstEleValue">第一节点的Value值</param>
        /// <param name="secEleValue">第二节点的Value值</param>
        /// <param name="returnValue">要返回的属性值</param>
        /// <returns></returns>
        public static string GetOneByXPathBeUsedSimpleData(string firstEleValue, string secEleValue, string returnValue)
        {

            string filePath = xmlFileRootPath + "SimpleData.xml";
            if (!File.Exists(filePath))
                return "";
            try
            {
                string filter = string.Format("/DD/DItems[@DValue='{0}']/DItem[@DValue='{1}']", firstEleValue, secEleValue);
                XDocument xdc = XDocument.Load(filePath);
                XElement elem = xdc.XPathSelectElement(filter);
                return elem.Attribute(returnValue).Value;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}