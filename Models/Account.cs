using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Day7.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [
            Display(Name ="Họ và tên"),
            Required(ErrorMessage ="Không được để trống"),
            StringLength (35, ErrorMessage =   "Tên không được dài quá 35 ký tự")
        ]
        public string FullName { get; set; }

        [
            Display(Name ="Địa chỉ email"),
            Required(ErrorMessage ="Email không được để trống"),
            EmailAddress(ErrorMessage ="Email không đúng định dạng")
        ]
        public string Email { get; set; }

        [
            Display(Name ="Số điện thoại"),
            DataType(DataType.PhoneNumber),
            //RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage ="Số điện thoại không đúng định dạng"),
            Required(ErrorMessage ="Số điện thoại không được bỏ trống"),
            Remote(action:"VerifyPhone", controller:"Account")
            
        ]
        public string Phone {  get; set; }

        [
            Display(Name ="Địa chỉ thường chú"),
            Required(ErrorMessage ="Địa chỉ không được bỏ trống"),
            StringLength(35, ErrorMessage ="Địa chỉ không được vượt qua 35 ký tự")
        ]
        public string Address {  get; set; }

        [Display(Name ="Ảnh đại diện")]
        public string? Avatar {  get; set; }

        [
            Display(Name ="Ngày sinh"),
            Required(ErrorMessage ="Ngày sinh không được bỏ trống"),
            DataType (DataType.Date)
        ]
        public DateTime BirthDay { get; set; }

        [Display(Name ="Giới tính")]
        public string? Gender { get; set; }

        [Display(Name ="Mật khẩu")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [
            Display(Name ="Link facebook cá nhân"),
            Required(ErrorMessage ="Link facebook không được bỏ trống"),
            Url(ErrorMessage ="Url không đúng định dạng")
        ]
        public string Facebook {  get; set; }
    }
}
