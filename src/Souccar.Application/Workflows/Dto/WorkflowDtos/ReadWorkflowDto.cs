using Abp.Application.Services.Dto;
using Souccar.Workflows.Dto.WorkflowStepDtos;
using System.Collections.Generic;

namespace Souccar.Workflows.Dto.WorkflowDtos
{
    public class ReadWorkflowDto : EntityDto
    {
        public ReadWorkflowDto()
        {
            Steps = new List<ReadWorkflowStepDto>();
        }
        public string Title { get; set; }
        public string Description { get; set; }
        public WorkflowStatus Status { get; set; }
        public IList<ReadWorkflowStepDto> Steps { get; set; }
    }
}
