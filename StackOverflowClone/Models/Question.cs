using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace StackOverflowClone.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required, MaxLength(200)]
        public string Title { get; set; } = default!;
        [Required, AllowHtml]
        
        public string Body { get; set; } = default!;
        public string PostedBy { get; set; } = default!;
        public DateTime PostedDate { get; set; } = DateTime.Now;
        public virtual ICollection<Answer>? Answers { get; set; }


    }
}
