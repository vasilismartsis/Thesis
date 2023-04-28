using System.Collections.Generic;

namespace JsonCreator.PropertyModels
{
    public class SelectProperty : Property
    {
        public enum SelectType
        {
            file,
            folder
        }

        public enum FileFilter
        {
            fbx,
            anim,
            jpg,
            jpeg,
            png
        }

        public string buttonName;
        public SelectType selectType;
        public List<FileFilter> fileFilters;
    }
}
