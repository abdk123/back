using AutoMapper;
using Souccar.Workflows.Dto.WorkflowStepGroupDtos;

namespace Souccar.Workflows.Map
{
    public class WorkflowStepGroupMapProfile : Profile
    {
        public WorkflowStepGroupMapProfile()
        {
            CreateMap<WorkflowStepGroup, WorkflowStepGroupDto>();
            CreateMap<CreateWorkflowStepGroupDto, WorkflowStepGroup>();
            CreateMap<UpdateWorkflowStepGroupDto, WorkflowStepGroup>();
            CreateMap<WorkflowStepGroup, UpdateWorkflowStepGroupDto>();
        }
    }
}
