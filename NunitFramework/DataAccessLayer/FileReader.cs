using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace NUnitFramework.DataAccessLayer
{
   public class FileReader
    {

        public Dictionary<String, String> PropertiesToDic(String filePath)
        {
            String[] textDate = File.ReadAllLines(filePath);
            
            var data = new Dictionary<string, string>();

            foreach (var line in textDate)
            {
                data.Add(line.Split('=')[0].Trim(), line.Split('=')[1].Trim());
            }

            return data;
        }
        public Dictionary<String, String> XmlToDic(String filePath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            var data = new Dictionary<string, string>();

            foreach (XmlNode node in xmlDoc.DocumentElement.ChildNodes)
            {
                data.Add(node.Name, node.InnerText);
            }

            return data;
        }
        public Dictionary<String,String> JsonToDic(String filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            var dic = new Dictionary<String, String>();

            String json = reader.ReadToEnd();

            dynamic array = JsonConvert.DeserializeObject(json);

            foreach (var item in array)
            {
                dic.Add("url", Convert.ToString(item.url));
                dic.Add("username", Convert.ToString(item.username));
                dic.Add("password", Convert.ToString(item.username));
            }

            return dic;
        }
    }
}
