using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Kop.Web.Models
{
    public class LoginModel
    {
        [DisplayName("登入名稱")]
        [Required(ErrorMessage = "登入名稱必須輸入")]
        public string LoginName { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必須輸入")]
        public string Password { get; set; }
    }
}