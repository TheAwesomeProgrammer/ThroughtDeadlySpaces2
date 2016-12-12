using System;
using System.Diagnostics;
using Debug = UnityEngine.Debug;

namespace Assets.Scripts.Tests.Helper
{
    public class IntegrationAssert
    {
        public static void IsTrue(bool condition)
        {
            if (condition)
            {
                IntegrationTest.Pass();
            }
            else
            {
                IntegrationTest.Fail();
            }
        }

        public static void IsTrue(bool condition, string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Debug.Log(message);
            }
            IsTrue(condition);
        }

        public static void Equals(object actual, object expected, string message = "")
        {
            var methodName = new StackTrace().GetFrame(1).GetMethod();
            var className = methodName.ReflectedType.Name;
            Debug.Log("Expected " + expected + " actual " + actual + Environment.NewLine + 
                " Called from " + methodName + " method in " + className +" class" + Environment.NewLine + 
                message);
            IsTrue(expected.Equals(actual), message);
        }
    }
}