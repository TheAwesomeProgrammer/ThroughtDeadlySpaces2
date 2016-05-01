namespace Assets.Scripts.Xml
{

    public class SpecsConverter : XmlConverter
    {
        

        public float[] Convert(string xmlSpecsText)
        {
            string[] specsStrings = GetElementsInString(xmlSpecsText);
            float[] specs = new float[specsStrings.Length];

            for (int i = 0; i < specsStrings.Length; i++)
            {
                specs[i] = float.Parse(specsStrings[i]);
            }

            return specs;
        }
    }
}