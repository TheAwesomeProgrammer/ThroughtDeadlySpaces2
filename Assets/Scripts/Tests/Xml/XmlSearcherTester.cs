﻿using System;
using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Tests.Helper;
using XmlLibrary;
using UnityEngine;

namespace Assets.Scripts.Tests.Xml
{
    public class XmlSearcherTester : MonoBehaviour
    {
        private const string PathToTestXml = "Xml/Test/XmlDocument.xml";
        private const int ItemId = 1;
        private const int SpecId = 1;

        private XmlSearcher _xmlSearcher;
        private XmlNodeInfo _xmlNodeInfo;

        void Start()
        {
            RunTest(TestIfCanSelectNodeInDocument);
            RunTest(TestIfCanSelectChildNode);
            RunTest(TestIfCanGetNodeInArrayWithIdByUsingName);
            RunTest(TestIfCanGetNodeInArrayWithIdByUsingNode);
            RunTest(TestIfCanGetNodesInArrayWithIdByUsingName);
            RunTest(TestIfCanGetNodesInArrayWithIdByUsingNode);
            RunTest(TestIfCanGetChildrenWithName);
            RunTest(TestIfCanGetAttributesInNode);
            RunTest(TestIfCanGetAttributesInNode);
            RunTest(TestIfCanGetSpecs);
        }

        void RunTest(Action actionTest)
        {
            Reset();
            actionTest();
        }

        void Reset()
        {
            _xmlSearcher = new XmlSearcher(PathToTestXml);
        }

        void TestIfCanSelectNodeInDocument()
        {
            IntegrationAssert.Equals(_xmlSearcher.SelectNodeInDocument("Item").Name, "Item", "Testing if can select node in document");
        }

        void TestIfCanSelectChildNode()
        {
            XmlNode items = _xmlSearcher.SelectNodeInDocument("Items");
            IntegrationAssert.Equals(_xmlSearcher.SelectChildNode(items, "Item").Name, "Item", "Testing if can select child node");
        }

        void TestIfCanGetNodeInArrayWithIdByUsingName()
        {
            IntegrationAssert.Equals(_xmlSearcher.GetNodeInArrayWithId(ItemId, "Items").Name, "Item", "Testing if can node in with id by using name");
        }

        void TestIfCanGetNodeInArrayWithIdByUsingNode()
        {
            IntegrationAssert.Equals(_xmlSearcher.GetNodeInArrayWithId(ItemId, _xmlSearcher.SelectNodeInDocument("Items")).Name, "Item",
                "Testing if can node in with id by using node");
        }

        void TestIfCanGetNodesInArrayWithIdByUsingName()
        {
            List<XmlNode> nodesInArrayWithId = _xmlSearcher.GetNodesInArrayWithId(ItemId, "Items");
            IntegrationAssert.Equals(nodesInArrayWithId[0].Name, "Item", "Testing if can nodes in array with id by using name");
        }

        void TestIfCanGetNodesInArrayWithIdByUsingNode()
        {
            List<XmlNode> nodesInArrayWithId = _xmlSearcher.GetNodesInArrayWithId(ItemId, _xmlSearcher.SelectNodeInDocument("Items"));
            IntegrationAssert.Equals(nodesInArrayWithId[0].Name, "Item", "Testing if can nodes in array with id by using name");
        }

        void TestIfCanGetChildrenWithName()
        {
            List<XmlNode> nodesInArrayWithId = _xmlSearcher.GetChildrensWithName(_xmlSearcher.SelectNodeInDocument("Items"), "Item");
            IntegrationAssert.Equals(nodesInArrayWithId[0].Name, "Item", "Testing if can nodes in array with id by using name");
        }

        void TestIfCanGetAttributesInNode()
        {
            string[] atrributes = _xmlNodeInfo.GetEquipmentAttributesInNode(_xmlSearcher.SelectNodeInDocument("Item"));
            IntegrationAssert.Equals(atrributes[0], "Rusty", "Test if can get attributes in node");
        }

        void TestIfCanGetSpecs()
        {
            int[] specs = _xmlNodeInfo.GetSpecs(_xmlSearcher.SelectChildNode(_xmlSearcher.SelectNodeInDocument("Item"), "Specs"));
            IntegrationAssert.Equals(specs[0], 1, "Test if can get specs");
            IntegrationAssert.Equals(specs[1], 2, "Test if can get specs");
        }
    }
}