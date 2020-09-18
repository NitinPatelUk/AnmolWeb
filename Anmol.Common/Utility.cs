using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using System.Web;
using System.Xml.Serialization;

namespace _Anmol.Common
{
    public class Utility
    {

        public static SqlParameter GetSQLParam(string paramName, SqlDbType type, dynamic value)
        {
            SqlParameter sqlParam = new SqlParameter(paramName, type);
            sqlParam.Value = value;
            return sqlParam;
        }

        public static SqlParameter GetSQLParam(string paramName, SqlDbType type, dynamic value, [Optional] string typeName)
        {
            SqlParameter sqlParam = new SqlParameter(paramName, type);
            sqlParam.Value = value;
            if (typeName != null)
            {
                sqlParam.TypeName = typeName;
            }
            return sqlParam;
        }

        public static string GetSortOrder(string SortBy, string SortDirection)
        {
            return SortBy + " " + (SortDirection.ToLower() == "descending" ? "DESC" : "");
        }

        public static void WriteLogFile(string msg)
        {
            const string path = @"C:\Users\sit87\Desktop\Log.txt";
            File.AppendAllText(msg, path);
        }
        public static int GenerateRandomNumber()
        {
            int _min = 100000;
            int _max = 999999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        public static object[] GetSQLParam(string v1, object varchar, object v2)
        {
            throw new NotImplementedException();
        }
    }

    public class ConvertToXml<T> where T : class, new()
    {
        static ConvertToXml()
        {


        }

        public static string GetXMLString(List<T> sourceList, string csvSelectedProperties = "")
        {

            //All numeric values in created xml was with dot symbol instead of comma
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            if (sourceList != null)
            {


                StringBuilder xmlString = new StringBuilder();
                xmlString.Append(@"<table>");

                Type sourceType;
                foreach (T item in sourceList)
                {
                    xmlString.Append("<row>");
                    sourceType = item.GetType();

                    foreach (PropertyInfo p in sourceType.GetProperties().Where(p => string.IsNullOrEmpty(csvSelectedProperties) || csvSelectedProperties.Split(',').Contains(p.Name)))
                    {
                        xmlString.Append("<" + p.Name + ">");
                        xmlString.Append(EncodeSpecialCharacter(p.GetValue(item, null)));
                        xmlString.Append("</" + p.Name + ">");
                    }
                    xmlString.Append("</row>");
                }
                xmlString.Append("</table>");

                return xmlString.ToString();
            }
            return string.Empty;
        }

        /// <summary>
        /// Replace Special Character as following 
        /// 1) &  =   &amp;
        /// 2) <  =   &lt;
        /// 3) >  =   &gt;
        /// 4) "  =   &quot;
        /// 5) '  =   &#39;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static object EncodeSpecialCharacter(object value)
        {
            if (value != null)
            {
                string strValue = value as string;

                if (!string.IsNullOrEmpty(strValue))
                {
                    strValue = strValue.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace(@"""", "&quot;").Replace("'", "&#39;");
                    return strValue;

                }
            }
            return value;
        }

        public static T DeserializeFromXMLNew<T>(string xmlSting)
        {
            var ser = new XmlSerializer(typeof(T));
            var wrapper = (T)ser.Deserialize(new StringReader(xmlSting));
            return wrapper;
        }
    }
}

