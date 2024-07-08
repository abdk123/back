using AutoMapper;
using Souccar.Workflows.Dto.WorkflowDtos;

namespace Souccar.Workflows.Map
{
    public class WorkflowMapProfile : Profile
    {
        public WorkflowMapProfile()
        {
            CreateMap<Workflow, WorkflowDto>();
            CreateMap<CreateWorkflowDto, Workflow>();
            CreateMap<UpdateWorkflowDto, Workflow>();
            CreateMap<Workflow, UpdateWorkflowDto>();
            CreateMap<Workflow, WorkflowForDropdownDto>();
        }
    }
}
