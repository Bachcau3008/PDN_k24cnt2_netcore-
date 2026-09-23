using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdnLesson09.Models.DataModels;
using PdnLesson09.Models.DataViewModels;

namespace PdnLesson09.Controllers
{
    public class PdnMemberController : Controller
    {   
        private static List<PdnMember> _pdnMembers = new List<PdnMember>();
        // GET: PdnMemberController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PdnMemberController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PdnMemberController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PdnMemberController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PdnMemberRegister pdnMember)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(pdnMember);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PdnMemberController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PdnMemberController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PdnMemberController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PdnMemberController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
