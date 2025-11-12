using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackOverflowClone.Models
{
    public class Answer
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; } = default!;
        public string PostedBy { get; set; } = default!;
        public DateTime PostedDate { get; set; } = DateTime.Now;
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public virtual Question? Question { get; set; }

    }
}
