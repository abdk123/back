using AutoMapper;
using Souccar.Workflows.Dto.WorkflowStepDtos;

namespace Souccar.Workflows.Map
{
    public class WorkflowStepMapProfile : Profile
    {
        public WorkflowStepMapProfile()
        {
            CreateMap<WorkflowStep, WorkflowStepDto>();
            CreateMap<CreateWorkflowStepDto, WorkflowStep>();
            CreateMap<UpdateWorkflowStepDto, WorkflowStep>();
            CreateMap<WorkflowStep, UpdateWorkflowStepDto>();
        }
    }
}
