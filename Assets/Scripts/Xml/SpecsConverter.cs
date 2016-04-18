namespace Assets.Scripts.Xml
{

    public class SpecsConverter
    {
        private const char SplitIdentifier = ',';
        private const string EndIdentifier = ")";
        private const string StartIdenfier = "(";

        public int[] Convert(string xmlSpecsText)
        {
            xmlSpecsText = xmlSpecsText.Replace(StartIdenfier, "");
            xmlSpecsText = xmlSpecsText.Replace(EndIdentifier, "");

            string[] specsStrings = xmlSpecsText.Split(SplitIdentifier);
            int[] specs = new int[specsStrings.Length];

            for (int i = 0; i < specsStrings.Length; i++)
            {
                specs[i] = int.Parse(specsStrings[i]);
            }

            return specs;
        }
    }
}