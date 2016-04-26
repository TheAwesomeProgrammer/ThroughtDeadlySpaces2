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

            return textToSplit.Split(SplitIdentifier);
        }
    }
}