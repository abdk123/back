using Abp.Application.Services.Dto;
using Souccar.Workflows.Dto.WorkflowStepActionDtos;
using Souccar.Workflows.Dto.WorkflowStepGroupDtos;
using System.Collections.Generic;

namespace Souccar.Workflows.Dto.WorkflowStepDtos
{
    public class ReadWorkflowStepDto : EntityDto
    {
        public ReadWorkflowStepDto()
        {
            Groups = new List<ReadWorkflowStepGroupDto>();
            Actions = new List<ReadWorkflowStepActionDto>();
        }
        public string Title { get; set; }
        public WorkflowStepStatus Status { get; set; }
        public int Index { get; set; }
        //public ReadWorkflowDto Workflow { get; set; }
        public int? WorkflowId { get; set; }
        public IList<ReadWorkflowStepGroupDto> Groups { get; set; }
        public IList<ReadWorkflowStepActionDto> Actions { get; set; }
    }
}
