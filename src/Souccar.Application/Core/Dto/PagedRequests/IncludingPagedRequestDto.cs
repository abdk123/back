using Souccar.Core.Includes;

namespace Souccar.Core.Dto.PagedRequests
{
    public class IncludingPagedRequestDto: FilteringPagedRequestDto, IIncludeResultRequest
    {
        public string Including { get; set; }
    }
}
