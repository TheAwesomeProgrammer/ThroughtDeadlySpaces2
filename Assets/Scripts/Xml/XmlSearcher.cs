using System;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Xml
{
    

    public class XmlSearcher
    {
        private SpecsConverter _specsConverter = new SpecsConverter();
        private AttributeConverter _attributeConverter = new AttributeConverter();

        private string _pathToXmlDocument;
        private XmlDocument _xmlDocument;

        public XmlSearcher(Location location) : this(XmlFileLocations.GetLocation(location))
        {
        }

        public XmlSearcher(string pathToXmlDocument)
        {
            SetDocument(pathToXmlDocument);
        }

        void SetDocument(string pathToDocument)
        {
            _pathToXmlDocument = pathToDocument;
            _xmlDocument = XmlLoader.LoadXmlDocument(_pathToXmlDocument);
        }

        public void SetLocation(Location location)
        {
            SetDocument(XmlFileLocations.GetLocation(location));
        }

        public XmlNode SelectNodeInDocument(string nodeName)
        {
            return _xmlDocument.GetElementsByTagName(nodeName)[0];
        }

        public XmlNode SelectChildNode(XmlNode xmlNode, string nodeName)
        {
            return xmlNode.SelectSingleNode(nodeName);
        }

        public XmlNodeList GetChildsNodes(XmlNode xmlNode)
        {
            return xmlNode.ChildNodes;
        }

        public XmlNode GetNodeInArrayWithId(int id, XmlNode arrayNode)
        {
            if (arrayNode == null)
            {
                throw new NullReferenceException("Array node is null");
            }

            foreach (XmlNode childNode in arrayNode.ChildNodes)
            {
                if (HasNodeId(id, childNode))
                {
                    return childNode;
                }
            }

            return null;
        }

        public XmlNode GetNodeInArrayWithId(int id, string arrayNodeName)
        {
            return GetNodeInArrayWithId(id, SelectNodeInDocument(arrayNodeName));
        }

        private bool HasNodeId(int id, XmlNode node)
        {
            int nodeId = int.MinValue;

            string idText = GetAttributeText(node, "id");
            if (idText != "")
            {
                nodeId = int.Parse(idText);
            }

            return nodeId == id;
        }

        private string GetAttributeText(XmlNode node, string attributeName)
        {
            if (node.Attributes != null && node.Attributes.Count > 0)
            {
                return node.Attributes[attributeName].InnerText;
            }
            return "";
        }

        public List<XmlNode> GetNodesInArrayWithId(int id, XmlNode arrayNode)
        {
            List<XmlNode> nodesWithId = new List<XmlNode>();

            foreach (XmlNode childNode in arrayNode.ChildNodes)
            {
                if (HasNodeId(id, childNode))
                {
                    nodesWithId.Add(childNode);
                }
            }

            return nodesWithId;
        }

        public List<XmlNode> GetNodesInArrayWithId(int id, string arrayNodeName)
        {
            return GetNodesInArrayWithId(id, SelectNodeInDocument(arrayNodeName));
        }

        public List<XmlNode> GetChildrensWithName(XmlNode parent, string name)
        {
            List<XmlNode> childrenWithName = new List<XmlNode>();

            foreach (XmlNode child in parent.ChildNodes)
            {
                if (child.Name == name)
                {
                    childrenWithName.Add(child);
                }
            }

            return childrenWithName;
        }

        public int[] GetSpecsInNode(XmlNode node, string specName = "Specs")
        {
            XmlNode specsNode = SelectChildNode(node, specName);
            string specsText = specsNode.InnerText;
            int[] specs = _specsConverter.Convert(specsText);
            return specs;
        }

        public int[] GetSpecsInNode(string nodeName, string specName = "Specs")
        {
            return GetSpecsInNode(SelectNodeInDocument(nodeName), specName);
        }

        public string[] GetAttributesInNode(XmlNode node, string attributeNodeName = "Att")
        {
            XmlNode attributeNode = SelectChildNode(node, attributeNodeName);

            return GetAttributes(attributeNode);
        }

        public string[] GetAttributes(XmlNode node)
        {
            return _attributeConverter.Convert(node.InnerText);
        }

        public int[] GetSpecsInNodeWithId(int id,XmlNode node)
        {
            return GetSpecs(GetNodeInArrayWithId(id, node));
        }

        public int[] GetSpecs(XmlNode node)
        {
            int[] specs = _specsConverter.Convert(node.InnerText);
            return specs;
        }

        public int[] GetSpecsInChildren(string arrayName, string nodeName)
        {
            return GetSpecsInNode(SelectChildNode(SelectNodeInDocument(arrayName), nodeName));
        }

        public int[] GetSpecsInChildrenWithId(int id, string arrayNodeName)
        {
            return GetSpecsInNode(GetNodeInArrayWithId(id, arrayNodeName));
        }

        public int[] GetSpecsInChildrenWithId(int id, string arrayNodeName, string specNodeName)
        {
            return GetSpecsInNode(GetNodeInArrayWithId(id, arrayNodeName), specNodeName);
        }

        public int[] GetSpecsInChildrenWithId(int id, XmlNode arrayNode)
        {
            return GetSpecsInNode(GetNodeInArrayWithId(id, arrayNode));
        }
    }
}