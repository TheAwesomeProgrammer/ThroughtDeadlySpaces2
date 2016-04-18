using System;
using System.Xml;
using UnityEngine;

namespace Assets.Scripts.Xml
{
    public class XmlSearcher
    {
        private SpecsConverter _specsConverter = new SpecsConverter();

        private string _pathToXmlDocument;

        public XmlSearcher(Location location)
        {
            _pathToXmlDocument = XmlFileLocations.GetLocation(location);
        }

        public XmlSearcher(string pathToXmlDocument)
        {
            _pathToXmlDocument = pathToXmlDocument;
        }

        public XmlNode SelectNodeInDocument(string nodeName, string pathToXmlDocument)
        {
            XmlDocument xmlDocument = XmlLoader.LoadXmlDocument(pathToXmlDocument);
            return xmlDocument.SelectSingleNode(nodeName);
        }

        public XmlNode SelectChildNode(XmlNode xmlNode, string nodeName)
        {
            return xmlNode.SelectSingleNode(nodeName);
        }

        public XmlNodeList GetChildsNodes(XmlNode xmlNode)
        {
            return xmlNode.ChildNodes;
        }

        public int[] GetSpecs(XmlNode node)
        {
            XmlNode specsNode = node.SelectSingleNode("Specs");
            string specsText = specsNode.InnerText;
            int[] specs = _specsConverter.Convert(specsText);
            return specs;
        }

        public XmlNode GetNodeWithId(int id, string nodeName)
        {
            XmlNode swordsNode = SelectNodeInDocument(nodeName, _pathToXmlDocument);
            foreach (XmlNode swordNode in swordsNode.ChildNodes)
            {
                int swordNodeId = Int32.Parse(swordNode.Attributes["id"].InnerText);

                if (swordNodeId == id)
                {
                    return swordNode;
                }
            }

            return null;
        }

        public int[] GetSpecsWithId(int id, string nodeName)
        {
            return GetSpecs(GetNodeWithId(id, nodeName));
        }
    }
}