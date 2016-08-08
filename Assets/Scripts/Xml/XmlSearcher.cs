using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Assets.Scripts.Extensions;
using UnityEngine;
using UnityEngine.Assertions;

namespace Assets.Scripts.Xml
{
    

    public class XmlSearcher
    {
        private const string SpecNodeName = "Specs";
        private const string AttributeNodeName = "Att";
        private const string AttributeLevelNodeName = "AttLevel";
        private const string AttributeLevelName = "level";

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

        public string GetAttributeText(XmlNode node, string attributeName)
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

        public int[] GetSpecsInNode(XmlNode node, string specName = SpecNodeName)
        {
            XmlNode specsNode = SelectChildNode(node, specName);
            string specsText = specsNode.InnerText;
            int[] specs = _specsConverter.Convert(specsText).Select(i => (int)i).ToArray();
            return specs;
        }

        public float[] GetSpecsInNodeFloat(XmlNode node, string specName = SpecNodeName)
        {
            XmlNode specsNode = SelectChildNode(node, specName);
            string specsText = specsNode.InnerText;
            float[] specs = _specsConverter.Convert(specsText);
            return specs;
        }

        public int[] GetSpecsInNode(string nodeName, string specName = SpecNodeName)
        {
            return GetSpecsInNode(SelectNodeInDocument(nodeName), specName);
        }

        public float[] GetSpecsInNodeFloat(string nodeName, string specName = SpecNodeName)
        {
            return GetSpecsInNodeFloat(SelectNodeInDocument(nodeName), specName);
        }

        public string[] GetEquipmentAttributesInNode(XmlNode node, string attributeNodeName = AttributeNodeName)
        {
            XmlNode attributeNode = SelectChildNode(node, attributeNodeName);

            return GetEquipmentAttributes(attributeNode);
        }

        public string[] GetEquipmentAttributes(XmlNode node)
        {
            return _attributeConverter.Convert(node.InnerText);
        }

        public int[] GetSpecsInNodeWithId(int id,XmlNode node)
        {
            return GetSpecs(GetNodeInArrayWithId(id, node));
        }

        public int[] GetSpecsInNodeWithId(int id, XmlNode node, string specName)
        {
            return GetSpecs(GetNodeInArrayWithId(id, node));
        }
        
        public int[] GetSpecs(XmlNode node)
        {
            int[] specs = _specsConverter.Convert(node.InnerText).Select(i => (int)i).ToArray(); ;
            return specs;
        }

        public float[] GetSpecsFloat(XmlNode node)
        {
            float[] specs = _specsConverter.Convert(node.InnerText);
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

        public int[] GetSpecsInChildrenWithId(int id, XmlNode xmlNode, string specNodeName)
        {
            return GetSpecsInNode(GetNodeInArrayWithId(id, xmlNode), specNodeName);
        }

        public float[] GetSpecsInChildrenWithIdFloat(int id, string arrayNodeName, string specNodeName)
        {
            return GetSpecsInNodeFloat(GetNodeInArrayWithId(id, arrayNodeName), specNodeName);
        }

        public int[] GetSpecsInChildrenWithId(int id, XmlNode arrayNode)
        {
            return GetSpecsInNode(GetNodeInArrayWithId(id, arrayNode));
        }

        public int GetAttributeLevelInNode(XmlNode attributeNode, int attributeNumber, string xmlAttributeLevelNodeName = AttributeLevelNodeName)
        {
            int attributeLevel = -1;

            XmlNode attributeLevelNode = SelectChildNode(attributeNode, xmlAttributeLevelNodeName);

            int[] specs = GetSpecs(attributeLevelNode);

            if (specs != null && specs.Length >= attributeNumber)
            {
                attributeLevel = specs[attributeNumber];
            }

            return attributeLevel;
        }

        private bool HasAttribute(XmlNode node, string attributeName)
        {
            return node != null && node.Attributes != null && node.Attributes[attributeName] != null;
        }

        public XmlNode GetAttributeNode(XmlNode node, string attributeName)
        {
            XmlNode attributeNode = null;

            if (HasAttribute(node, attributeName))
            {
                attributeNode =  node.Attributes[attributeName];
            }

            return attributeNode;
        }

        public XmlNode GetLevelNodeInChildren(XmlNode xmlNode, int level, string xmlAttributeLevelName = AttributeLevelName)
        {
            XmlNode levelNodeInChildren = null;

            foreach (var childNode in xmlNode.ChildNodes)
            {
                XmlAttribute attributeLevelNode = (XmlAttribute)GetAttributeNode((XmlNode)childNode, xmlAttributeLevelName);
                if (attributeLevelNode != null)
                {
                    int levelInNode = int.Parse(attributeLevelNode.InnerText);

                    if (levelInNode == level)
                    {
                        levelNodeInChildren = attributeLevelNode.OwnerElement;
                    }
                }
            }

            return levelNodeInChildren;
        }
    }
}