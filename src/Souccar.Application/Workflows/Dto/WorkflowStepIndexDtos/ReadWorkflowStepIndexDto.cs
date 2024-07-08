using Abp.Application.Services.Dto;

namespace Souccar.Workflows.Dto.WorkflowStepIndexDtos
{
    public class ReadWorkflowStepIndexDto : EntityDto
    {
        public string ActionName { get; set; }
        public int Order { get; set; }
    }
}
