using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArchitectureCeA.Web.ViewModels
{
    public class PracticeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLengthAttribute(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        public Nullable<int> PerspectiveId { get; set; }
    }
}