using System;
using System.Collections.Generic;
using System.Xml;
using Assets.Scripts.Tests.Helper;
using Assets.Scripts.Xml;
using UnityEngine;

namespace Assets.Scripts.Tests.Xml
{
    public class XmlSearcherTester : MonoBehaviour
    {
        private const string PathToTestXml = "Xml/Test/XmlDocument.xml";
        private const int ItemId = 1;
        private const int SpecId = 1;

        private XmlSearcher _xmlSearcher;

        void Start()
        {
            RunTest(TestIfCanSelectNodeInDocument);
            RunTest(TestIfCanSelectChildNode);
            RunTest(TestIfCanGetNodeInArrayWithIdByUsingName);
            RunTest(TestIfCanGetNodeInArrayWithIdByUsingNode);
            RunTest(TestIfCanGetNodesInArrayWithIdByUsingName);
            RunTest(TestIfCanGetNodesInArrayWithIdByUsingNode);
            RunTest(TestIfCanGetChildrenWithName);
            RunTest(TestIfCanSpecsInNode);
            RunTest(TestIfCanGetAttributesInNode);
            RunTest(TestIfCanGetAttributesInNode);
            RunTest(TestIfCanGetSpecsInNodeWithId);
            RunTest(TestIfCanGetSpecs);
            RunTest(TestIfCanGetSpecsInChildrenWithIdUsingNode);
            RunTest(TestIfCanGetSpecsInChildrenWithIdUsingName);
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
            Assert.IsEquals(_xmlSearcher.SelectNodeInDocument("Item").Name, "Item", "Testing if can select node in document");
        }

        void TestIfCanSelectChildNode()
        {
            XmlNode items = _xmlSearcher.SelectNodeInDocument("Items");
            Assert.IsEquals(_xmlSearcher.SelectChildNode(items, "Item").Name, "Item", "Testing if can select child node");
        }

        void TestIfCanGetNodeInArrayWithIdByUsingName()
        {
            Assert.IsEquals(_xmlSearcher.GetNodeInArrayWithId(ItemId, "Items").Name, "Item", "Testing if can node in with id by using name");
        }

        void TestIfCanGetNodeInArrayWithIdByUsingNode()
        {
            Assert.IsEquals(_xmlSearcher.GetNodeInArrayWithId(ItemId, _xmlSearcher.SelectNodeInDocument("Items")).Name, "Item",
                "Testing if can node in with id by using node");
        }

        void TestIfCanGetNodesInArrayWithIdByUsingName()
        {
            List<XmlNode> nodesInArrayWithId = _xmlSearcher.GetNodesInArrayWithId(ItemId, "Items");
            Assert.IsEquals(nodesInArrayWithId[0].Name, "Item", "Testing if can nodes in array with id by using name");
        }

        void TestIfCanGetNodesInArrayWithIdByUsingNode()
        {
            List<XmlNode> nodesInArrayWithId = _xmlSearcher.GetNodesInArrayWithId(ItemId, _xmlSearcher.SelectNodeInDocument("Items"));
            Assert.IsEquals(nodesInArrayWithId[0].Name, "Item", "Testing if can nodes in array with id by using name");
        }

        void TestIfCanGetChildrenWithName()
        {
            List<XmlNode> nodesInArrayWithId = _xmlSearcher.GetChildrensWithName(_xmlSearcher.SelectNodeInDocument("Items"), "Item");
            Assert.IsEquals(nodesInArrayWithId[0].Name, "Item", "Testing if can nodes in array with id by using name");
        }

        void TestIfCanSpecsInNode()
        {
            int[] specs = _xmlSearcher.GetSpecsInNode(_xmlSearcher.SelectNodeInDocument("Item"));
            Assert.IsEquals(specs[0], 1, "Test if can specs in node");
            Assert.IsEquals(specs[1], 2, "Test if can specs in node");
        }

        void TestIfCanGetAttributesInNode()
        {
            string[] atrributes = _xmlSearcher.GetAttributesInNode(_xmlSearcher.SelectNodeInDocument("Item"));
            Assert.IsEquals(atrributes[0], "Rusty", "Test if can get attributes in node");
        }

        void TestIfCanGetSpecsInNodeWithId()
        {
            int[] specs = _xmlSearcher.GetSpecsInNodeWithId(SpecId, _xmlSearcher.SelectNodeInDocument("Item"));
            Assert.IsEquals(specs[0], 1, "Test if can specs in node with id");
            Assert.IsEquals(specs[1], 2, "Test if can specs in node with id");
        }

        void TestIfCanGetSpecs()
        {
            int[] specs = _xmlSearcher.GetSpecs(_xmlSearcher.SelectChildNode(_xmlSearcher.SelectNodeInDocument("Item"), "Specs"));
            Assert.IsEquals(specs[0], 1, "Test if can get specs");
            Assert.IsEquals(specs[1], 2, "Test if can get specs");
        }

        void TestIfCanGetSpecsInChildrenWithIdUsingNode()
        {
            int[] specs = _xmlSearcher.GetSpecsInChildrenWithId(ItemId, _xmlSearcher.SelectNodeInDocument("Items"));
            Assert.IsEquals(specs[0], 1, "Test if can get specs int children with id using node");
            Assert.IsEquals(specs[1], 2, "Test if can get specs int children with id using node");
        }

        void TestIfCanGetSpecsInChildrenWithIdUsingName()
        {
            int[] specs = _xmlSearcher.GetSpecsInChildrenWithId(ItemId, "Items");
            Assert.IsEquals(specs[0], 1, "Test if can get specs in children with id using name");
            Assert.IsEquals(specs[1], 2, "Test if can get specs in children with id using name");
        }
    }
}