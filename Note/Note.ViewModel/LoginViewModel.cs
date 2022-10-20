using System;
using System.ComponentModel.DataAnnotations;

namespace Note.ViewModel
{
    //로그인을 위한 모델
    public class LoginViewModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string Password { get; set; }   

    }
}
