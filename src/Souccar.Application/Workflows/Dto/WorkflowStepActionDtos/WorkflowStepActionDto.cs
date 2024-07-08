using Abp.Application.Services.Dto;
using Souccar.Workflows.Dto.WorkflowStepIndexDtos;

namespace Souccar.Workflows.Dto.WorkflowStepActionDtos
{
    public class WorkflowStepActionDto : EntityDto
    {
        public string Name { get; set; }
        public WorkflowActionType Type { get; set; }
        //public WorkflowStepDto WorkflowStep { get; set; }
        //public int? WorkflowStepId { get; set; }
        public WorkflowStepIndexDto WorkflowIndex { get; set; }
        public int? WorkflowIndexId { get; set; }
    }
}
