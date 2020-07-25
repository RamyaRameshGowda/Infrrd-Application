using Business.Contract;
using DataAccess.Contract;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Implementation
{
    public class CategoryBizManager : ICategoryBizManager
    {
        private readonly ICategoryDataManager _categoryDataManager;
        public CategoryBizManager(ICategoryDataManager categoryDataManager)
        {
            _categoryDataManager = categoryDataManager;
        }
        public List<Category> GetCategoryList()
        {
            return _categoryDataManager.GetCategoryList();
        }
    }
}
