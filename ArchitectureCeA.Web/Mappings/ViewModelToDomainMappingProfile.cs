using ArchitectureCeA.Model;
using ArchitectureCeA.Web.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ArchitectureCeA.Web.Mappings
{

    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<ProcessPerspectiveViewModel, ProcessPerspective>();
            Mapper.CreateMap<PracticeViewModel, Practice>();
            Mapper.CreateMap<PracticeRequirementViewModel, PracticeRequirement>();
        }
    }

}