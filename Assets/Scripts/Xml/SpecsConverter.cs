namespace Assets.Scripts.Xml
{

    public class SpecsConverter : XmlConverter
    {
        

        public int[] Convert(string xmlSpecsText)
        {
            string[] specsStrings = GetElementsInString(xmlSpecsText);
            int[] specs = new int[specsStrings.Length];

            for (int i = 0; i < specsStrings.Length; i++)
            {
                specs[i] = int.Parse(specsStrings[i]);
            }

            return specs;
        }
    }
}