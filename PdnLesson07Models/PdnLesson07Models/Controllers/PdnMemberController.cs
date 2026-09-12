using Microsoft.AspNetCore.Mvc;
using PdnLesson07Models.Models.DataModels;  

namespace PdnLesson07Models.Controllers
{
    public class PdnMemberController : Controller
    {

        protected static List<PdnMember> _members = new List<PdnMember>
        {
            new PdnMember
            {
                PdnMemberId = Guid.NewGuid().ToString(),
                PdnUserName = "Nguyenpd",
                PdnPassword = "Pdn123",
                PdnFullName = "Phạm Đình Nguyên",
                PdnEmail = "phamdinhnguyen2006hp@gmail.com"
            },
            new PdnMember
            {
                PdnMemberId = Guid.NewGuid().ToString(),
                PdnUserName = "Linhth",
                PdnPassword = "Linh123",
                PdnFullName = "Trần Thị Hoàng Linh",
                PdnEmail = "tranthihoanglinh@gmail.com"
            },
            new PdnMember
            {
                PdnMemberId = Guid.NewGuid().ToString(),
                PdnUserName = "Minhle",
                PdnPassword = "Minh123",
                PdnFullName = "Lê Hoàng Minh",
                PdnEmail = "lehoangminh@gmail.com"
            },
            new PdnMember
            {
                PdnMemberId = Guid.NewGuid().ToString(),
                PdnUserName = "Trangvt",
                PdnPassword = "Trang123",
                PdnFullName = "Vũ Thị Thu Trang",
                PdnEmail = "vuthithutrang@gmail.com"
            },
            new PdnMember
            {
                PdnMemberId = Guid.NewGuid().ToString(),
                PdnUserName = "Dungpham",
                PdnPassword = "Dung123",
                PdnFullName = "Phạm Tiến Dũng",
                PdnEmail = "phambatiendung@gmail.com"
            }

        };
        public IActionResult Index()
        {
            return View(_members);
        }
        public IActionResult GetMember()
        {
            var member = new Models.DataModels.PdnMember
            {
                PdnMemberId = Guid.NewGuid().ToString(),
                PdnUserName = "Nguyenpd",
                PdnPassword = "Pdn123",
                PdnFullName = "Phạm Đình Nguyên",
                PdnEmail = "phamdinhnguyen2006hp@gmail.com"
            };
            ////ViewBag.Member = member;
            return View(member);
        }
        public IActionResult GetMembers()
        {
            ViewBag.Members = _members;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(PdnMember member)
        {
            if (ModelState.IsValid)
            {
                member.PdnMemberId = Guid.NewGuid().ToString();
                _members.Add(member);
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }
    }
}   
