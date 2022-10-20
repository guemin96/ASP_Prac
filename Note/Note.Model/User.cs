using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note.Model
{
    public class User
    {
        [Key]
        public int UserNo { get; set; }
        [Required]
        public string   UserId { get; set; }
        [Required]
        public string UserPassword { get; set; }
        [Required]
        public string UserName { get; set; }    
    }
}
