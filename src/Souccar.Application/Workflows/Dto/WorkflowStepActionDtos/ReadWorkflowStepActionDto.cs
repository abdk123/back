using Abp.Application.Services.Dto;
using Souccar.Workflows.Dto.WorkflowStepDtos;
using Souccar.Workflows.Dto.WorkflowStepIndexDtos;

namespace Souccar.Workflows.Dto.WorkflowStepActionDtos
{
    public class ReadWorkflowStepActionDto : EntityDto
    {
        public string Name { get; set; }
        public WorkflowActionType Type { get; set; }
        public ReadWorkflowStepDto WorkflowStep { get; set; }
        public int? WorkflowStepId { get; set; }
        public ReadWorkflowStepIndexDto WorkflowIndex { get; set; }
        public int? WorkflowIndexId { get; set; }
    }
}
