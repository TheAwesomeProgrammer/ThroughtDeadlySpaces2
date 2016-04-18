using System.Xml;
using UnityEngine;

namespace Assets.Scripts.Xml
{
    public class XmlLoader
    {
        public static XmlDocument LoadXmlDocument(string pathToXmlDocument)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(Application.dataPath + "/" + pathToXmlDocument);
            return xmlDocument;
        }
    }
}