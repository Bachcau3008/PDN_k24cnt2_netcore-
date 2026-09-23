using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PdnLesson09.Models.DataViewModels
{
    public class PdnMemberRegister
    {
        public int PdnMemberId { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không được để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tên đăng nhập phải từ 3 đến 20 ký tự")]
        public string PdnUserName { get; set; }
        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string PdnPassword { get; set; }
        public string PdnEmail { get; set; }
        public string PdnPhoneNumber { get; set; }
        public string PdnFullName { get; set; }
        public DateTime PdnBirthday { get; set; }
    }
}
