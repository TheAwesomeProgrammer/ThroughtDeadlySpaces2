using System.Collections.Generic;
using System.Linq;

namespace Assets.Scripts.Xml
{
    public class XmlConverter
    {
        protected const char SplitIdentifier = ',';
        protected const string EndIdentifier = ")";
        protected const string StartIdenfier = "(";

        public string[] GetElementsInString(string textToSplit)
        {
            textToSplit = textToSplit.Replace(StartIdenfier, "");
            textToSplit = textToSplit.Replace(EndIdentifier, "");
            string[] stringSplitted = textToSplit.Split(SplitIdentifier);

            return RemoveEmptyStrings(stringSplitted);
        }

        string[] RemoveEmptyStrings(string[] stringsToCheck)
        {
            return stringsToCheck.Where(stringItem => stringItem != "").ToArray();
        }
    }
}