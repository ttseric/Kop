using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kop.Web.Models
{
    public class RegisterModel
    {
        [DisplayName("登入名稱")]
        [Required(ErrorMessage = "登入名稱必須輸入")]
        public string LoginName { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼必須輸入")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("密碼確認")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "密碼確認錯誤")]
        public string ConfirmPassword { get; set; }

        [DisplayName("來自")]
        [Required(ErrorMessage = "請輸入你來自的地區")]
        public string SelectedCountry { get; set; }

        public List<SelectListItem> CountryList { get; set; }
    }
}