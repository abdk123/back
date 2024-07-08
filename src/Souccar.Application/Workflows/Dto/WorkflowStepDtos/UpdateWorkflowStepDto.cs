using Abp.Application.Services.Dto;
using Souccar.Consts;
using Souccar.Workflows.Dto.WorkflowStepActionDtos;
using Souccar.Workflows.Dto.WorkflowStepGroupDtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Workflows.Dto.WorkflowStepDtos
{
    public class UpdateWorkflowStepDto : EntityDto
    {
        public UpdateWorkflowStepDto()
        {
            Groups = new List<UpdateWorkflowStepGroupDto>();
            Actions = new List<UpdateWorkflowStepActionDto>();
        }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int Status { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int Index { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? WorkflowId { get; set; }
        public IList<UpdateWorkflowStepGroupDto> Groups { get; set; }
        public IList<UpdateWorkflowStepActionDto> Actions { get; set; }
    }
}
