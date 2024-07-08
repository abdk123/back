namespace Souccar.CodeGenerator.Models.Fields
{
    public class ReadFieldModel
    {
        public int Order { get; set; }
        public string Name { get; set; }
        public FieldUiType FieldType { get; set; }
        public bool IsGetter { get; set; }
        public bool IsHidden { get; set; }
        public bool Sortable { get; set; }
        public bool Filterable { get; set; }
        public bool Searchable { get; set; }
        public bool IsReference { get; set; }
        public float Width { get; set; }
        public string ReferenceItem { get; set; }
        public bool IsImage { get; set; }
        public string Expression { get; set; }
        public string Formate { get; set; }
    }

    public enum FieldUiType
    {
        Text,
        Number,
        Boolean,
        DateTime,
        Time,
        Image,
        File,
        Enum,
        Reference
    }
}
