using EmployeeManagement.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class PhoneBook
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ID { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Display(Name = "Contact Name", Prompt = "Contact Name")]
        [Required(ErrorMessage = "Contact Name is Required")]
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string NickName { get; set; }
        public string? Email { get; set; }
    }

    public class PhoneBookRequest
    {
        public string UserId { get; set; }
        public string ContactName { get; set; }
        public string PhoneNumber { get; set; }
        public string NickName { get; set; }
    }
}
