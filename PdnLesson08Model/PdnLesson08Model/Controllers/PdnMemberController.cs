using Microsoft.AspNetCore.Mvc;
using PdnLesson08Model.Models;

namespace PdnLesson08Model.Controllers
{
    public class PdnMemberController : Controller
    {
        private static List <PdnMember> _members = new List<PdnMember>()
        {
            
                
                new PdnMember
                {
                    PdnMemberId = Guid.NewGuid().ToString(),
                    PdnUserName = "Nguyenpd",
                    PdnPassword = "Password123!",
                    PdnFullName = "Phạm Đình Nguyên",
                    PdnEmail = "nguyen.pdn@example.com"
                },
                new PdnMember
                {
                    PdnMemberId = Guid.NewGuid().ToString(),
                    PdnUserName = "thanhtrung",
                    PdnPassword = "SecurePass456#",
                    PdnFullName = "Phạm Thanh Trung",
                    PdnEmail = "trung.pdn@example.com"
                },
                new PdnMember
                {
                    PdnMemberId = Guid.NewGuid().ToString(),
                    PdnUserName = "minhanh",
                    PdnPassword = "Pdn@2026Strong",
                    PdnFullName = "Nguyễn Minh Anh",
                    PdnEmail = "anh.minh@example.com"
                },
                new PdnMember
                {
                    PdnMemberId = Guid.NewGuid().ToString(),
                    PdnUserName = "hoangkim",
                    PdnPassword = "KimHoangPass789",
                    PdnFullName = "Trần Hoàng Kim",
                    PdnEmail = "kim.th@example.com"
                }
        };
        public IActionResult Index()
        {
            return View(_members);
        }

        [HttpGet]
        public IActionResult PdnCreate()
        {   
            var member = new PdnMember();   
            return View(member);
        }
        [HttpPost]
        public IActionResult PdnCreate(PdnMember pdnMember)
        {
            pdnMember .PdnMemberId = Guid.NewGuid().ToString();
            _members.Add(pdnMember);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult PdnEdit(string id)
        {
            var member =_members.Where(x => x.PdnMemberId.Equals(id)).FirstOrDefault()   ;
            return View(member);
        }
        [HttpPost]
        public IActionResult PdnEdit(string id, PdnMember pdnMember)
        {
            //var member = _members.Where(x => x.PdnMemberId.Equals(id)).FirstOrDefault();
            for(int i=0; i < _members.Count; i++)
            {
                if (_members[i].PdnMemberId.Equals(id))
                {
                    _members[i].PdnUserName = pdnMember.PdnUserName;
                    _members[i].PdnPassword = pdnMember.PdnPassword;
                    _members[i].PdnFullName = pdnMember.PdnFullName;
                    _members[i].PdnEmail = pdnMember.PdnEmail;

                    return RedirectToAction("Index");
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult PdnDetails(string id)
        {
            var member = _members.Where(x => x.PdnMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }
        [HttpGet]
        public IActionResult PdnDelete(string id)
        {
            var member = _members.Where(x => x.PdnMemberId.Equals(id)).FirstOrDefault();
            return View(member);
        }
        [HttpPost]
        public IActionResult PdnDeleted(string id)
        {
            foreach (var item in _members)
            {   
                if(item.PdnMemberId.Equals(id))
                {
                    _members.Remove(item);
                    return RedirectToAction("Index");
                }
            }
           return View("PdnDelete");
        }

    }
}
