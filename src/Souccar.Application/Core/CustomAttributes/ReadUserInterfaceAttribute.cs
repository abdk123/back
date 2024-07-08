using System;

namespace Souccar.Core.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ReadUserInterfaceAttribute : Attribute
    {
        public bool IsHidden { get; set; }
        public int Width { get; set; }
        public int Order { get; set; }
        public bool IsReference { get; set; }
        public string ReferenceId { get; set; }
        public bool IsImage { get; set; }
        public string Expression { get; set; }
        public string ImageColumnPath { get; set; }
        public string ImageAlert { get; set; }
        public string Formate { get; set; }
        public bool Sortable { get; set; }
        public bool Filterable { get; set; }
        public bool Searchable { get; set; }

    }
}
