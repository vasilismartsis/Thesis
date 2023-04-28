namespace JsonCreator.PropertyModels
{
    public class VectorProperty : Property
    {
        public class Values
        {
            public float x;
            public float y;
            public float z;

            public Values(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
        }

        public Values values;
    }
}
