//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArchitectureCeA.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class EvaluationPractice
    {
        public EvaluationPractice()
        {
            this.ActionPlan = new HashSet<ActionPlan>();
        }
    
        public int Id { get; set; }
        public Nullable<int> EvaluationId { get; set; }
        public string EvaluationPracticeStatus { get; set; }
        public string EvaluationPracticeNote { get; set; }
        public Nullable<int> EvaluationPracticeId { get; set; }
    
        public virtual ICollection<ActionPlan> ActionPlan { get; set; }
        public virtual Evaluation Evaluation { get; set; }
        public virtual Practice Practice { get; set; }
    }
}