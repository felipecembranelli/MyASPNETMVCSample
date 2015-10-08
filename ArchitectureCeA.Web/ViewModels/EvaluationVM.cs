using ArchitectureCeA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ArchitectureCeA.Web.ViewModels
{
    public class EvaluationVM
    {
        [Key]
        public int EvaluationId { get; set; }
        public int EvaluationPracticeId { get; set; }
        public int PerspectiveId { get; set; }

        public IEnumerable<EvaluationPractice> EvaluationPractice { get; set; }
    }
}
