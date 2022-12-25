using System;

namespace Mahtan.Assets.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ModelAttribute : Attribute
    {
        public string SingleEntityTitle { get; set; }
        public string MultipleEntitiesTitle { get; set; }
    }
}
