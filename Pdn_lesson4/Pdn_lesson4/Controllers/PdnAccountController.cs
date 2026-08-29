using Microsoft.AspNetCore.Mvc;
using Pdn_lesson4.Models;

namespace Pdn_lesson4.Controllers
{
    public class PdnAccountController : Controller
    {
        private readonly List<PdnAccount> pdnAccounts = new()
        {

                    new PdnAccount
                    {
                        Id = 1,
                        Name = "Nguyễn Văn Anh",
                        Email = "nguyenvananh@gmail.com",
                        Phone = "0903123456",
                        Avatar = "/images/1.png",
                        Address = "123 Nguyễn Huệ, Phường Bến Nghé, Quận 1, TP. Hồ Chí Minh",
                        Bio = "Lập trình viên C# / .NET Core, yêu thích công nghệ và đọc sách.",
                        Gender = 1, // 1: Nam
                        Birthday = new DateTime(1995, 5, 20)
                    },
                    new PdnAccount
                    {
                        Id = 2,
                        Name = "Trần Thị Phương",
                        Email = "tranthiphuong.dev@gmail.com",
                        Phone = "0918234567",
                        Avatar = "/images/2.png",
                        Address = "456 Hoàng Quốc Việt, Phường Nghĩa Tân, Quận Cầu Giấy, Hà Nội",
                        Bio = "Chuyên viên thiết kế giao diện UI/UX và phát triển ứng dụng Web.",
                        Gender = 0, // 0: Nữ
                        Birthday = new DateTime(1998, 9, 15)
                    },
                    new PdnAccount
                    {
                        Id = 3,
                        Name = "Lê Hoàng Nam",
                        Email = "lehoangnam.sys@gmail.com",
                        Phone = "0925345678",
                        Avatar = "/images/3.png",
                        Address = "78 Lạch Tray, Phường Đông Thọ, Quận Ngô Quyền, Hải Phòng",
                        Bio = "Kỹ sư quản trị hệ thống và hạ tầng mạng doanh nghiệp.",
                        Gender = 1,
                        Birthday = new DateTime(1992, 11, 8)
                    },
                    new PdnAccount
                    {
                        Id = 4,
                        Name = "Phạm Minh Thư",
                        Email = "phamminhthu.qa@gmail.com",
                        Phone = "0934456789",
                        Avatar = "/images/4.png",
                        Address = "12 Nguyễn Văn Linh, Phường Nam Dương, Quận Hải Châu, Đà Nẵng",
                        Bio = "Kiểm thử phần mềm (QA/QC Engineer) với 3 năm kinh nghiệm.",
                        Gender = 0,
                        Birthday = new DateTime(2000, 3, 25)
                    },
                    new PdnAccount
                    {
                        Id = 5,
                        Name = "Đỗ Quốc Bảo",
                        Email = "baodo.dev@gmail.com",
                        Phone = "0945678901",
                        Avatar = "/images/5.png",
                        Address = "56 Quang Trung, Phường Quang Trung, Thành phố Vinh, Nghệ An",
                        Bio = "Lập trình viên Mobile (Flutter & React Native), đam mê công nghệ mới.",
                        Gender = 1, 
                        Birthday = new DateTime(1997, 7, 18)
                    }

              };
           



        public IActionResult PdnIndex()
        {
            ViewBag.PdnAccount = pdnAccounts;
            return View();
        }

        [Route ("ho-so-cua-toi", Name = "PdnProfile")]
        public IActionResult PdnProfile(int? id)
        {
            PdnAccount pdnAccount = new PdnAccount()
            {
                Id = 5,
                Name = "Đỗ Quốc Bảo",
                Email = "baodo.dev@gmail.com",
                Phone = "0945678901",
                Avatar = "/images/5.png",
                Address = "56 Quang Trung, Phường Quang Trung, Thành phố Vinh, Nghệ An",
                Bio = "Lập trình viên Mobile (Flutter & React Native), đam mê công nghệ mới.",
                Gender = 1,
                Birthday = new DateTime(1997, 7, 18)
            };
            if (id != null )
             pdnAccount = pdnAccounts.FirstOrDefault(x => x.Id == id);

            ViewBag.PdnAccount = pdnAccount;
            return View();
        }
    }
 }
