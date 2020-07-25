using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Infrrd.ValueObjects
{
    public class DepartmentDetailsView
    {
        public int Id { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Please Select Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please Select Year")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Please Enter Amount")]
        public string Amount { get; set; }
        public string CategoryName { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public IEnumerable<SelectListItem> Years { get; set; }


        public string YearOne { get; set; }
        public string YearTwo { get; set; }
        public string YearThree { get; set; }
        public string YearFour { get; set; }
        public string YearFive { get; set; }
        public string TotalAmount { get; set; }

        public long SumOfYearBefore2018 { get; set; }
        public long SumOfYear2018 { get; set; }
        public long SumOfYear2019 { get; set; }
        public long SumOfYear2020 { get; set; }
        public long SumOfYearAfter2020 { get; set; }

        public long TotalYearSum { get; set; }
    }
}
