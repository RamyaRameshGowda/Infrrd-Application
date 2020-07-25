using System;
using System.ComponentModel.DataAnnotations;

namespace Infrrd.ValueObjects
{
    public class ApplicationEnumarations
    {
        public enum EnumYear
        {
            [Display(Name = "2015")]
            YearOne = 2015,
            [Display(Name = "2016")]
            YearTwo = 2016,
            [Display(Name = "2017")]
            YearThree = 2017,
            [Display(Name = "2018")]
            YearFour = 2018,
            [Display(Name = "2019")]
            YearFive = 2019,
            [Display(Name = "2020")]
            YearSix = 2020,
            [Display(Name = "2021")]
            YearSeven = 2021
        }
    }
}
