using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Workflows.Dto.WorkflowDtos
{
    public class CreateWorkflowDto
    {
        public CreateWorkflowDto()
        {
            //Steps = new List<CreateWorkflowStepDto>();
        }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Title { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string Description { get; set; }
        //public IList<CreateWorkflowStepDto> Steps { get; set; }
    }
}
