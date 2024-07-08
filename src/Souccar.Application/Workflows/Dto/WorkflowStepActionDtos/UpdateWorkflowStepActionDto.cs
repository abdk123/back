using Abp.Application.Services.Dto;
using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Workflows.Dto.WorkflowStepActionDtos
{
    public class UpdateWorkflowStepActionDto : EntityDto
    {
        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int Type { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int? WorkflowIndexId { get; set; }
    }
}
