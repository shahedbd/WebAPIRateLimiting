using Core.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Client.ConsumeAPI.APIClient;

namespace Client.ConsumeAPI.Controllers
{
    public class BranchesController : Controller
    {
        private IAPIClientService<Branch> _iAPIClientService;

        public BranchesController(IAPIClientService<Branch> iAPIClientService)
        {
            _iAPIClientService = iAPIClientService;
        }
        public async Task<IActionResult> Index()
        {
            string _subURL = "Branch/GetAll";
            var members = await _iAPIClientService.GetAll(_subURL);
            return View(members);
        }
        public async Task<IActionResult> Details(Int64 id)
        {
            string _subURL = "Branch/GetById/";
            var _Branch = await _iAPIClientService.GetById(id, _subURL);
            return View(_Branch);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Branch branch)
        {
            if (ModelState.IsValid)
            {
                string _subURL = "Branch/Add";
                var resut = await _iAPIClientService.Add(branch, _subURL);
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        public async Task<IActionResult> Edit(Int64 id)
        {
            string _subURL = "Branch/GetById/";
            var _Branch = await _iAPIClientService.GetById(id, _subURL);
            return View(_Branch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Branch branch)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string _subURL = "Branch/Update";
                    var resut = await _iAPIClientService.Update(branch, _subURL);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }
        public async Task<IActionResult> Delete(Int64 id)
        {
            string _subURL = "Branch/GetById/";
            var _Branch = await _iAPIClientService.GetById(id, _subURL);
            return View(_Branch);
        }

        [HttpDelete, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(Int64 id)
        {
            string _subURL = "Branch/Delete/";
            var resut = await _iAPIClientService.Delete(id, _subURL);
            return RedirectToAction(nameof(Index));
        }
    }
}
