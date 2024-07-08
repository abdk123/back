using Abp.Application.Services.Dto;

namespace Souccar.Workflows.Dto.WorkflowStepGroupDtos
{
    public class ReadWorkflowStepGroupDto : EntityDto
    {
        public int? WorkflowStepId { get; set; }
    }
}
