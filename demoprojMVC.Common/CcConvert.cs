using System;

namespace demoprojMVC.Common
{
    public class CcConvert
    {
        private static DateTime defdate = Convert.ToDateTime("1910-1-1");

        public static bool isDatetime(object data)
        {
            bool result;
            try
            {
                Convert.ToDateTime(data.ToString());
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool isByte(object data)
        {
            if (CcConvert.isNull(data))
            {
                return false;
            }
            bool result;
            try
            {
                Convert.ToByte(data);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool isInt32(object data)
        {
            if (CcConvert.isNull(data))
            {
                return false;
            }
            bool result;
            try
            {
                Convert.ToInt32(data.ToString());
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool isInt64(object data)
        {
            if (CcConvert.isNull(data))
            {
                return false;
            }
            bool result;
            try
            {
                Convert.ToInt64(data.ToString());
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool isDouble(object data)
        {
            if (CcConvert.isNull(data))
            {
                return false;
            }
            bool result;
            try
            {
                Convert.ToDouble(data.ToString());
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool isDecimal(object data)
        {
            if (CcConvert.isNull(data))
            {
                return false;
            }
            bool result;
            try
            {
                Convert.ToDecimal(data);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool isSingle(object data)
        {
            if (CcConvert.isNull(data))
            {
                return false;
            }
            bool result;
            try
            {
                Convert.ToSingle(data);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static bool isNull(object data)
        {
            return data == null || data.GetType().ToString() == "System.DBNull";
        }

        public static bool isEmpty(string str)
        {
            return str == null || str.Trim() == "";
        }

        public static bool isBool(object data)
        {
            if (data == null)
            {
                return false;
            }
            string s = data.ToString().ToLower();
            return s == "true" || s == "是" || s == "1" || s == "yes" || s == "真" || s == "男";
        }

        public static bool isGender(object data)
        {
            if (data == null)
            {
                return false;
            }
            string s = data.ToString().ToLower();
            return s == "true" || s == "男" || s == "1" || s == "M" || s == "男性";
        }

        public static string DatetimeToShortString(DateTime dt)
        {
            if (CcConvert.isDatetime(dt))
            {
                return dt.ToString("yyyy-MM-dd");
            }
            return string.Empty;
        }

        public static DateTime ObjectToDateTime(object dataPara)
        {
            DateTime result;
            try
            {
                result = Convert.ToDateTime(dataPara);
            }
            catch (Exception)
            {
                result = CcConvert.defdate;
            }
            return result;
        }

        public static int ObjectToInt(object dataPara)
        {
            return CcConvert.ObjectToInt(dataPara, 0);
        }

        public static int ObjectToInt(object dataPara, int def)
        {
            int result;
            try
            {
                result = (int)Convert.ToInt16(dataPara);
            }
            catch (Exception)
            {
                result = def;
            }
            return result;
        }

        public static float ObjectToSingle(object dataPara)
        {
            return CcConvert.ObjectToSingle(dataPara, 0f);
        }

        public static float ObjectToSingle(object dataPara, float def)
        {
            float result;
            try
            {
                result = Convert.ToSingle(dataPara);
            }
            catch (Exception)
            {
                result = def;
            }
            return result;
        }

        public static decimal ObjectToDecimal(object dataPara)
        {
            return CcConvert.ObjectToDecimal(dataPara, 0m);
        }

        public static decimal ObjectToDecimal(object dataPara, decimal def)
        {
            decimal result;
            try
            {
                result = Convert.ToDecimal(dataPara);
            }
            catch (Exception)
            {
                result = def;
            }
            return result;
        }

        public static long ObjectToBigInt(object dataPara)
        {
            return CcConvert.ObjectToBigInt(dataPara, 0);
        }

        public static long ObjectToBigInt(object dataPara, int def)
        {
            long result;
            try
            {
                result = Convert.ToInt64(dataPara);
            }
            catch (Exception)
            {
                result = (long)def;
            }
            return result;
        }

        public static byte ObjectToByte(object dataPara)
        {
            return CcConvert.ObjectToByte(dataPara, 0);
        }

        public static byte ObjectToByte(object dataPara, byte def)
        {
            byte result;
            try
            {
                result = Convert.ToByte(dataPara);
            }
            catch (Exception)
            {
                result = def;
            }
            return result;
        }

        public static double ObjectToDouble(object dataPara)
        {
            return CcConvert.ObjectToDouble(dataPara, 0.0);
        }

        public static double ObjectToDouble(object dataPara, double def)
        {
            double result;
            try
            {
                result = Convert.ToDouble(dataPara);
            }
            catch (Exception)
            {
                result = def;
            }
            return result;
        }

        public static decimal ObjectToMoney(object dataPara)
        {
            return CcConvert.ObjectToDecimal(dataPara, 0m);
        }

        public static string ObjectToString(object dataPara)
        {
            return CcConvert.ObjectToString(dataPara, "");
        }

        public static string ObjectToString(object dataPara, string def)
        {
            if (!CcConvert.isNull(dataPara))
            {
                return Convert.ToString(dataPara);
            }
            return def;
        }

        public static bool ObjectToBool(object dataPara)
        {
            string s = CcConvert.ObjectToString(dataPara).ToLower();
            return s == "true" || s == "是" || s == "1" || s == "yes" || s == "真" || s == "男";
        }

        public static string quotedStr(string str)
        {
            if (str.Contains("'"))
            {
                return str;
            }
            return "'" + str + "'";
        }

        public static DateTime StrToDateTime(string para, ref string errmsg)
        {
            DateTime result;
            try
            {
                result = Convert.ToDateTime(para);
            }
            catch
            {
                errmsg = errmsg + "错误的日期格式" + para + "<br />";
                result = Convert.ToDateTime("2099-12-31");
            }
            return result;
        }

        public static DateTime StrToDateTime(string para)
        {
            DateTime result;
            try
            {
                result = Convert.ToDateTime(para);
            }
            catch
            {
                result = Convert.ToDateTime("2099-12-31");
            }
            return result;
        }

        public static string StrCheckNull(string para, string def)
        {
            if (para != null && !(para == ""))
            {
                return para;
            }
            return def;
        }

        public static bool StrToBool(string para)
        {
            string[] strbool = new string[]
            {
                "true",
                "Yes",
                "是",
                "1",
                "yes",
                "True",
                "真"
            };
            bool found = false;
            string[] array = strbool;
            for (int i = 0; i < array.Length; i++)
            {
                string s = array[i];
                if (s == para)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public static int StrToInt(string para, int def, ref string errmsg)
        {
            int result;
            try
            {
                result = Convert.ToInt32(para);
            }
            catch
            {
                errmsg = errmsg + "提供了错误的整数：" + para + "<br />";
                result = def;
            }
            return result;
        }

        public static double StrToDouble(string para)
        {
            return CcConvert.StrToDouble(para, 0.0);
        }

        public static double StrToMoney(string para)
        {
            return CcConvert.StrToDouble(para, 0.0);
        }

        public static double StrToDouble(string para, double def)
        {
            double result;
            try
            {
                result = Convert.ToDouble(para);
            }
            catch
            {
                result = def;
            }
            return result;
        }

        public static int StrToInt(string para, int def)
        {
            int result;
            try
            {
                Convert.ToInt32(para);
                result = Convert.ToInt32(para);
            }
            catch
            {
                result = def;
            }
            return result;
        }

        public static int StrToInt(string para)
        {
            return CcConvert.StrToInt(para, 0);
        }

    }
}