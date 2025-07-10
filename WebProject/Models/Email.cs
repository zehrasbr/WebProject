using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Email
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Mail { get; set; }

        [Required]
        public string Subject { get; set; }        
        [Required]
        public string SubjectType { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
