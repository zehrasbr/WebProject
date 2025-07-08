using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public string DateTime { get; set; }
        public string Message { get; set; }
    }
}
