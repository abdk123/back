using AutoMapper;
using Souccar.Workflows.Dto.WorkflowStepIndexDtos;

namespace Souccar.Workflows.Map
{
    public class WorkflowStepIndexMapProfile : Profile
    {
        public WorkflowStepIndexMapProfile()
        {
            CreateMap<WorkflowStepIndex, WorkflowStepIndexDto>();
            CreateMap<CreateWorkflowStepIndexDto, WorkflowStepIndex>();
            CreateMap<UpdateWorkflowStepIndexDto, WorkflowStepIndex>();
            CreateMap<WorkflowStepIndex, UpdateWorkflowStepIndexDto>();
            CreateMap<WorkflowStepIndex, WorkflowStepIndexForDropdownDto>();
        }
    }
}
