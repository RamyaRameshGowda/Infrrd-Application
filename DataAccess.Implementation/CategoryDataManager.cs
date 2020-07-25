using DataAccess.Contract;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Implementation
{
    public class CategoryDataManager : ICategoryDataManager
    {
        private readonly EfDbContext _efDbContext;
        public CategoryDataManager(EfDbContext efDbContext)
        {
            _efDbContext = efDbContext;
        }
        public List<Category> GetCategoryList()
        {
            //return _efDbContext.Category.ToList();
            if (_efDbContext != null)
            {
                if (_efDbContext.Category != null)
                {
                    return _efDbContext.Category.ToList();
                }
            }
            return null;
        }
    }
}
