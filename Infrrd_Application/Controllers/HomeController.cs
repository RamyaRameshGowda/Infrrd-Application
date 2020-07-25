using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Infrrd_Application.Models;
using Business.Contract;
using DataAccess.Implementation;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Model;
using static Infrrd.ValueObjects.ApplicationEnumarations;
using Infrrd.ValueObjects;

namespace Infrrd_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryBizManager _categoryBizManager;
        private readonly IDepartmentDetailsBizManager _departmentDetailsBiz;

        public HomeController(ILogger<HomeController> logger, ICategoryBizManager categoryBizManager, IDepartmentDetailsBizManager departmentDetailsBiz)
        {
            _logger = logger;
            _categoryBizManager = categoryBizManager;
            _departmentDetailsBiz = departmentDetailsBiz;
        }

        /// <summary>
        /// Action to get department details on load
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var departmentDetails = _departmentDetailsBiz.GetDepartmentDetails();
            return View(departmentDetails);
        }

        /// <summary>
        /// Action will trigger on click of create button
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public IActionResult Create(DepartmentDetailsView details)
        {
            details.Categories = _categoryBizManager.GetCategoryList().Select(category =>
            new SelectListItem
            {
                Text = category.CategoryName,
                Value = category.Id.ToString()
            });           
            details.Years = Enum.GetValues(typeof(EnumYear)).Cast<EnumYear>().Select(v => new SelectListItem
            {
                Text = ((int)v).ToString(),
                Value = ((int)v).ToString()
            });
            return View(details);
        }

        /// <summary>
        /// Action to save the details
        /// </summary>
        /// <param name="details"></param>
        /// <returns></returns>
        public IActionResult PostDepartmentDetails(DepartmentDetailsView details)
        {
            DepartmentDetails departmentDetails = new DepartmentDetails
            {
                Id=0,
                CategoryId=details.CategoryId,
                Amount=details.Amount,
                Year=details.Year
            };
            _departmentDetailsBiz.SaveDetails(departmentDetails);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
