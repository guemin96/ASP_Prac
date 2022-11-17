using System.ComponentModel.DataAnnotations;

namespace BOARD_ASP_CORE.Models {
    public class UserM {
        
        public int Num { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ChkPassword { get; set; }
        [Required] 
        public string Name { get; set; }
        [Required] 
        public string Birthday { get; set; }
        
        [Required]
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
