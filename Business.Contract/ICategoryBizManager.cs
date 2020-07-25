using DataAccess.Model;
using System;
using System.Collections.Generic;

namespace Business.Contract
{
    public interface ICategoryBizManager
    {
        List<Category> GetCategoryList();
    }
}
