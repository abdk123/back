using Souccar.CodeGenerator.Models.Fields;

namespace Souccar.CodeGenerator.Models.Back
{
    public class ReadDtoModel
    {
        public ReadDtoModel()
        {
            Fields = new List<ReadFieldModel>();
            DisplayModes = new List<DisplayMode>
            {
                new DisplayMode("table",true),
                new DisplayMode("list",true)
            };
        }
        public string Name { get; set; }
        public string FullName { get; set; }
        public string EntityName { get; set; }
        public IList<DisplayMode> DisplayModes { get; set; }
        public IList<ReadFieldModel> Fields { get; set; }
    }

    public class DisplayMode
    {
        public DisplayMode(string mode, bool isDefault = false)
        {
            Mode = mode;
            IsDefault = isDefault;
        }
        public string Mode { get; set; }
        public bool IsDefault { get; set; }
    }
}
