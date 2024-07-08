using AutoMapper;
using Souccar.Workflows.Dto.WorkflowStepActionDtos;

namespace Souccar.Workflows.Map
{
    public class WorkflowStepActionMapProfile : Profile
    {
        public WorkflowStepActionMapProfile()
        {
            CreateMap<WorkflowStepAction, WorkflowStepActionDto>();
            CreateMap<CreateWorkflowStepActionDto, WorkflowStepAction>();
            CreateMap<UpdateWorkflowStepActionDto, WorkflowStepAction>();
            CreateMap<WorkflowStepAction, UpdateWorkflowStepActionDto>();
        }
    }
}
