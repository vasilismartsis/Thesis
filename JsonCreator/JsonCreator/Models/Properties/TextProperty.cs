namespace JsonCreator.PropertyModels
{
    public class TextProperty : Property
    {
        public enum ValueType
        {
            alphanumeric,
            numeric
        }

        public ValueType valueType;
        public string value;
    }
}
