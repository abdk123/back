using Souccar.Core.Filter;

namespace Souccar.Core.Dto.PagedRequests
{
    public class FilteringPagedRequestDto : SearchPagedRequestDto, IFilterResultRequest
    {
        public FilterDto Filtering { get; set; }
    }
}
