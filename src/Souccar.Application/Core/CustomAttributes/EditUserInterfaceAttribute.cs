using System;

namespace Souccar.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class EditUserInterfaceAttribute : Attribute
    {
        public string Group { get; set; }
        public int Order { get; set; }
        public bool IsReference { get; set; }
        public string CascadeFrom { get; set; }
        public bool IsImage { get; set; }
        public bool IsFile { get; set; }
        public int FileSize { get; set; }
        public bool IsDateTime { get; set; }
        public bool IsTime { get; set; }
        public string Formate { get; set; }
    }
}
