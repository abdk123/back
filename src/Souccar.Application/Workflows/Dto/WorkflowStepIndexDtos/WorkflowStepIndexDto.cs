using Abp.Application.Services.Dto;

namespace Souccar.Workflows.Dto.WorkflowStepIndexDtos
{
    public class WorkflowStepIndexDto : EntityDto
    {
        public string ActionName { get; set; }
        public int Order { get; set; }
    }
}
