using Business.Contract;
using DataAccess.Contract;
using DataAccess.Model;
using Infrrd.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Infrrd.ValueObjects.ApplicationEnumarations;

namespace Business.Implementation
{
    public class DepartmentDetailsBizManager : IDepartmentDetailsBizManager
    {
        private readonly IDepartmentDetailsDataManager _departmentDetails;
        private readonly ICategoryBizManager _categoryBizManager;
        public DepartmentDetailsBizManager(IDepartmentDetailsDataManager departmentDetails, ICategoryBizManager categoryBizManager)
        {
            _departmentDetails = departmentDetails;
            _categoryBizManager = categoryBizManager;
        }

        /// <summary>
        /// Method will return details
        /// </summary>
        /// <returns></returns>
        public List<DepartmentDetailsView> GetDepartmentDetails()
        {
            List<DepartmentDetailsView> departmentDetailsViews = new List<DepartmentDetailsView>();
            var departmentDetails = _departmentDetails.GetDepartmentDetails();
            if (departmentDetails != null)
            {
                foreach (var item in departmentDetails)
                {
                    if (departmentDetailsViews.FirstOrDefault(x => x.CategoryId == item.CategoryId) == null)
                    {
                        DepartmentDetailsView departmentDetailsView = GetViewObject(departmentDetails, item);
                        GetAmountByCategory(departmentDetailsView);
                        departmentDetailsViews.Add(departmentDetailsView);
                    }
                }
                GetAmountByYear(departmentDetailsViews);
            }
            return departmentDetailsViews;
        }

        /// <summary>
        /// Method to save data
        /// </summary>
        /// <param name="departmentDetails"></param>
        public void SaveDetails(DepartmentDetails departmentDetails)
        {
            _departmentDetails.SaveDetails(departmentDetails);
        }

        /// <summary>
        /// Method to convert db object to view objects
        /// </summary>
        /// <param name="departmentDetails"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        private DepartmentDetailsView GetViewObject(List<DepartmentDetails> departmentDetails, DepartmentDetails item)
        {
            return new DepartmentDetailsView
            {
                Id = item.Id,
                CategoryName = _categoryBizManager.GetCategoryList()?.Where(x => x.Id == item.CategoryId)?.Select(x => x.CategoryName)?.FirstOrDefault(),
                Amount = item.Amount,
                Year = item.Year,
                CategoryId = item.CategoryId,
                YearOne = GetSumOfAmountBasedOnCategory(departmentDetails, item.CategoryId, (int)EnumYear.YearFour, true, false),
                YearTwo = GetSumOfAmountBasedOnCategory(departmentDetails, item.CategoryId, (int)EnumYear.YearFour, false, false),
                YearThree = GetSumOfAmountBasedOnCategory(departmentDetails, item.CategoryId, (int)EnumYear.YearFive, false, false),
                YearFour = GetSumOfAmountBasedOnCategory(departmentDetails, item.CategoryId, (int)EnumYear.YearSix, false, false),
                YearFive = GetSumOfAmountBasedOnCategory(departmentDetails, item.CategoryId, (int)EnumYear.YearSix, false, true),
                SumOfYearBefore2018 = GetSumOfAmountByYear(departmentDetails, (int)EnumYear.YearFour, true, false),
                SumOfYear2018 = GetSumOfAmountByYear(departmentDetails, (int)EnumYear.YearFour, false, false),
                SumOfYear2019 = GetSumOfAmountByYear(departmentDetails, (int)EnumYear.YearFive, false, false),
                SumOfYear2020 = GetSumOfAmountByYear(departmentDetails, (int)EnumYear.YearSix, false, false),
                SumOfYearAfter2020 = GetSumOfAmountByYear(departmentDetails, (int)EnumYear.YearSix, false, true),
            };
        }

        /// <summary>
        /// Method to add the amount for all the year to get total
        /// </summary>
        /// <param name="departmentDetailsView"></param>
        private static void GetAmountByYear(List<DepartmentDetailsView> departmentDetailsView)
        {
            departmentDetailsView[0].TotalYearSum = departmentDetailsView.Select(x => Convert.ToInt32(x.TotalAmount)).Sum();
        }

        /// <summary>
        /// Method to add the amount based on category to get total
        /// </summary>
        /// <param name="departmentDetailsView"></param>
        private static void GetAmountByCategory(DepartmentDetailsView departmentDetailsView)
        {
            departmentDetailsView.TotalAmount = (Convert.ToInt64(departmentDetailsView.YearOne) + Convert.ToInt64(departmentDetailsView.YearTwo)
                                        + Convert.ToInt64(departmentDetailsView.YearThree) + Convert.ToInt64(departmentDetailsView.YearFour)
                                        + Convert.ToInt64(departmentDetailsView.YearFive)).ToString();
        }

        /// <summary>
        /// Method to get sum of year amount for same category and same year
        /// </summary>
        /// <param name="departmentDetails"></param>
        /// <param name="year"></param>
        /// <param name="lessThan"></param>
        /// <param name="greaterThan"></param>
        /// <returns></returns>
        public long GetSumOfAmountByYear(List<DepartmentDetails> departmentDetails, int year, bool lessThan, bool greaterThan)
        {
            var sumOfAmount = 0;
            var Object = new List<DepartmentDetails>();
            if (departmentDetails != null)
            {
                if (lessThan)
                {
                    Object = departmentDetails.Where(x => x.Year < year).ToList();
                }
                else if (greaterThan)
                {
                    Object = departmentDetails.Where(x => x.Year > year).ToList();
                }
                else
                {
                    Object = departmentDetails.Where(x => x.Year == year).ToList();
                }

                if (Object != null)
                {
                    sumOfAmount = Object.Select(x => Convert.ToInt32(x.Amount)).Sum();
                }
            }
            return sumOfAmount;
        }

        /// <summary>
        /// Method to get sum of year amount for same category
        /// </summary>
        /// <param name="departmentDetails"></param>
        /// <param name="year"></param>
        /// <param name="lessThan"></param>
        /// <param name="greaterThan"></param>
        /// <returns></returns>
        /// <returns></returns>
        public string GetSumOfAmountBasedOnCategory(List<DepartmentDetails> departmentDetails, int categoryId, int year, bool lessThan, bool greaterThan)
        {
            var amount = 0;
            var amountData = new List<DepartmentDetails>();
            if (departmentDetails != null)
            {
                if (lessThan)
                {
                    amountData = departmentDetails.Where(x => x.CategoryId == categoryId && x.Year < year).ToList();
                }
                else if (greaterThan)
                {
                    amountData = departmentDetails.Where(x => x.CategoryId == categoryId && x.Year > year).ToList();
                }
                else
                {
                    amountData = departmentDetails.Where(x => x.CategoryId == categoryId && x.Year == year).ToList();
                }

                if (amountData != null)
                {
                    amount = amountData.Select(x => Convert.ToInt32(x.Amount)).Sum();
                }
            }
            return amount.ToString();
        }
    }
}
