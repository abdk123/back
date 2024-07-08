using Souccar.Consts;
using Souccar.Workflows.Dto.WorkflowStepActionDtos;
using Souccar.Workflows.Dto.WorkflowStepGroupDtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Workflows.Dto.WorkflowStepDtos
{
    public class CreateWorkflowStepDto
    {
        public CreateWorkflowStepDto()
        {
            Groups = new List<CreateWorkflowStepGroupDto>();
            Actions = new List<CreateWorkflowStepActionDto>();
        }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int Status { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int Index { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? WorkflowId { get; set; }
        public IList<CreateWorkflowStepGroupDto> Groups { get; set; }
        public IList<CreateWorkflowStepActionDto> Actions { get; set; }
    }
}
