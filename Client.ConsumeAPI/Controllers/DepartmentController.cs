using Core.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using Client.ConsumeAPI.APIClient;

namespace Client.ConsumeAPI.Controllers
{
    public class DepartmentController : Controller
    {
        private IAPIClientService<Department> _iAPIClientService;

        public DepartmentController(IAPIClientService<Department> iAPIClientService)
        {
            _iAPIClientService = iAPIClientService;
        }
        public async Task<IActionResult> Index()
        {
            string _subURL = "Department/GetAll";
            var members = await _iAPIClientService.GetAll(_subURL);
            return View(members);
        }
        public async Task<IActionResult> Details(Int64 id)
        {
            string _subURL = "Department/GetById/";
            var _Department = await _iAPIClientService.GetById(id, _subURL);
            return View(_Department);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department Department)
        {
            if (ModelState.IsValid)
            {
                string _subURL = "Department/Add";
                var resut = await _iAPIClientService.Add(Department, _subURL);
                return RedirectToAction(nameof(Index));
            }
            return View(Department);
        }

        public async Task<IActionResult> Edit(Int64 id)
        {
            string _subURL = "Department/GetById/";
            var _Department = await _iAPIClientService.GetById(id, _subURL);
            return View(_Department);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Department Department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string _subURL = "Department/Update";
                    var resut = await _iAPIClientService.Update(Department, _subURL);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Department);
        }
        public async Task<IActionResult> Delete(Int64 id)
        {
            string _subURL = "Department/GetById/";
            var _Department = await _iAPIClientService.GetById(id, _subURL);
            return View(_Department);
        }

        [HttpDelete, ActionName("DeleteConfirmed")]
        public async Task<IActionResult> DeleteConfirmed(Int64 id)
        {
            string _subURL = "Department/Delete/";
            var resut = await _iAPIClientService.Delete(id, _subURL);
            return RedirectToAction(nameof(Index));
        }
    }
}
