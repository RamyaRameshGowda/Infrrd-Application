using DataAccess.Model;
using System;
using System.Collections.Generic;

namespace DataAccess.Contract
{
    public interface ICategoryDataManager
    {
        List<Category> GetCategoryList();
    }
}
