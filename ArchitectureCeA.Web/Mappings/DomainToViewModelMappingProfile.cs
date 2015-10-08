using ArchitectureCeA.Model;
using ArchitectureCeA.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchitectureCeA.Web.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProcessPerspective, ProcessPerspectiveViewModel>();
            Mapper.CreateMap<Practice, PracticeViewModel>();
            Mapper.CreateMap<PracticeRequirement, PracticeRequirementViewModel>();
        }
    }
}