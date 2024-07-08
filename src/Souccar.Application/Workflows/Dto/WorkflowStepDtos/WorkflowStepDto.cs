using Abp.Application.Services.Dto;
using Souccar.Workflows.Dto.WorkflowStepActionDtos;
using Souccar.Workflows.Dto.WorkflowStepGroupDtos;
using System.Collections.Generic;

namespace Souccar.Workflows.Dto.WorkflowStepDtos
{
    public class WorkflowStepDto : EntityDto
    {
        public WorkflowStepDto()
        {
            Groups = new List<WorkflowStepGroupDto>();
            Actions = new List<WorkflowStepActionDto>();
        }
        public string Title { get; set; }
        public WorkflowStepStatus Status { get; set; }
        public int Index { get; set; }
        //public WorkflowDto Workflow { get; set; }
        public int? WorkflowId { get; set; }
        public IList<WorkflowStepGroupDto> Groups { get; set; }
        public IList<WorkflowStepActionDto> Actions { get; set; }
    }
}
