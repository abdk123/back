using System.Collections.Generic;

namespace Souccar.Core.Filter
{
    public class FilterDto
    {
        public FilterDto()
        {
            Rules = new List<FilterRuleDto>();
        }
        public string Condition { get; set; }

        public IList<FilterRuleDto> Rules { get; set; }
    }
}
