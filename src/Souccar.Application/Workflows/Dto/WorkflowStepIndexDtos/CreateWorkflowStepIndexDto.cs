using Souccar.Consts;
using System.ComponentModel.DataAnnotations;

namespace Souccar.Workflows.Dto.WorkflowStepIndexDtos
{
    public class CreateWorkflowStepIndexDto
    {
        [Required(ErrorMessage = SouccarAppConstant.Required, AllowEmptyStrings = false), MaxLength(SouccarAppConstant.SimpleStringMaxLength)]
        public string ActionName { get; set; }

        [Required(ErrorMessage = SouccarAppConstant.Required)]
        public int Order { get; set; }
    }
}
