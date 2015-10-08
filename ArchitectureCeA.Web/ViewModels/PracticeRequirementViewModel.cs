using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArchitectureCeA.Web.ViewModels
{
    public class PracticeRequirementViewModel
    {
        public int Id { get; set; }
        public Nullable<int> PracticeId { get; set; }

        [Required]
        public string RequirementDescription { get; set; }
    }
}