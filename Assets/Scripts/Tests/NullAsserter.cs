using UnityEngine;

namespace Assets.Scripts.Tests
{
    public static class NullAsserter
    {
        public static void Assert(object objectToTest, string objectName, string additionalMessage = "")
        {
            Debug.Assert(objectToTest != null, objectName + " is null. "+ additionalMessage);
        }
    }
}