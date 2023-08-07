using Ajaxcrud.Data;
using Ajaxcrud.Models;
using Ajaxcrud.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Ajaxcrud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IRepository _repository;
        private readonly Applicationdb _context;
        public EmployeeController(IRepository repository, Applicationdb context)
        {
            _repository = repository;
            _context = context;

        }
        //get employee
        public IActionResult Index()
        {
            return View();
        }
        //get ajax
        [HttpGet]
        public JsonResult GetAll()
        {
            return Json(_repository.GetAll());

        }
        [HttpPost]
        public JsonResult Add([FromBody] Employee empObj)
        {
           
            return Json(_repository.Add(empObj));
        }
        public JsonResult GetbyId(int Id)
        {
            var Employee = _repository.GetAll().Find(x => x.EmployeeId.Equals(Id));
            return Json(Employee);
        }
        [HttpPost]
        public JsonResult Update([FromBody] Employee empObj)
        {
            return Json(_repository.Update(empObj));
        }
        public JsonResult Delete(int Id)
        {
            return Json(_repository.Delete(Id));
        }
    }
}
