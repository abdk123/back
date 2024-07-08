using Abp.Application.Services.Dto;
using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Workflows.Dto.WorkflowDtos
{
    public class UpdateWorkflowDto : EntityDto
    {
        public UpdateWorkflowDto()
        {
            //Steps = new List<UpdateWorkflowStepDto>();
        }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Description { get; set; }
        //public int Status { get; set; }
        //public IList<UpdateWorkflowStepDto> Steps { get; set; }
    }
}
