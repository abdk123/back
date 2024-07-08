using Abp.Application.Services.Dto;
using Souccar.Workflows.Dto.WorkflowStepDtos;
using System.Collections.Generic;

namespace Souccar.Workflows.Dto.WorkflowDtos
{
    public class WorkflowDto : EntityDto
    {
        public WorkflowDto()
        {
            Steps = new List<WorkflowStepDto>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public WorkflowStatus Status { get; set; }
        public IList<WorkflowStepDto> Steps { get; set; }
    }
}
