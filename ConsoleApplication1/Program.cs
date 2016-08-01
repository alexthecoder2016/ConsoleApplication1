using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 30; i++)
                Console.Write(CesarEncryptingHelper.GetCharacter(i));

            var e = CesarEncryptingHelper.Encrypt("ATTACKATDAWN".ToLower(), "LEMONLEMONLE".ToLower()).ToUpper();
            var d = CesarEncryptingHelper.Decrypt(e.ToLower(), "LEMONLEMONLE".ToLower()).ToUpper();
        }
    }

    public class XmlHelper
    {
        public static void CreateBasicXml(string fileName)
        {
            var xmlDoc = new XmlDocument();
            var rootNode = xmlDoc.AppendChild(xmlDoc.CreateElement("root"));
            rootNode.AppendChild(xmlDoc.CreateElement("child1"));
            rootNode.AppendChild(xmlDoc.CreateElement("child2"));
            rootNode.AppendChild(xmlDoc.CreateElement("child3"));
            xmlDoc.Save(fileName);
        }
    }

    public class CesarEncryptingHelper
    {
        public static string Encrypt(string value, string key)
        {
            var result = "";
            for (int i = 0; i < key.Length; i++)
            {
                result += GetCharacter(
                    (GetCode(value[i]) + (GetCode(key[i]))) % 26
                    );
            }
            return result;
        }

        public static string Decrypt(string value, string key)
        {
            var result = string.Join("", value.ToList().Select((v, index) => value[index]));
            return result;
            //var result = "";

            //foreach (char v in value)
            //{
            //    result += v;
            //}

            //return result;

            //for (int i = 0; i < key.Length; i++)
            //{
            //    result += GetCharacter(
            //        (GetCode(value[i]) + 26 - (GetCode(key[i]))) % 26
            //        );
            //}
        }

        public static int GetCode(char c)
        {
            return Convert.ToInt32(c) - 97;
        }

        public static char GetCharacter(int i)
        {
            return Convert.ToChar(i + 97);
        }

    }
}
