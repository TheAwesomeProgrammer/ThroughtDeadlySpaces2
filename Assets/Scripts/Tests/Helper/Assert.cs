using UnityEngine;

namespace Assets.Scripts.Tests.Helper
{
    public class Assert
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
            Debug.Log(message);
            IsTrue(condition);
        }

        public static void IsEquals(int expected, int actual, string message)
        {
            IsTrue(expected == actual, message);
            Debug.Log("Expected " + expected + " actual " + actual);
        }

        public static void IsEquals(string expected, string actual, string message)
        {
            IsTrue(expected == actual, message);
            Debug.Log("Expected " + expected + " actual " + actual);
        }
    }
}