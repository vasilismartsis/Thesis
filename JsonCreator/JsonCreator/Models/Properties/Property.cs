using System.Collections.Generic;

namespace JsonCreator.PropertyModels
{
    public class Property
    {
        public enum Dimension
        {
            both,
            _3d,
            _2d
        }

        public SceneProperties.PropertyNames name;
        public string title;
        public string description;
        public List<SceneProperties.PropertyNames> children;
        public Dimension dimension = Dimension.both;
        public bool unique;
        public bool optional;
    }
}
