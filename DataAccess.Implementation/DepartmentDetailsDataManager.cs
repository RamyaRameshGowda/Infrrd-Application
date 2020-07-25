using DataAccess.Contract;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Implementation
{
    public class DepartmentDetailsDataManager : IDepartmentDetailsDataManager
    {
        private readonly EfDbContext _efDbContext;
        public DepartmentDetailsDataManager(EfDbContext efDbContext)
        {
            _efDbContext = efDbContext;
        }

        /// <summary>
        /// Method to get data from database
        /// </summary>
        /// <returns></returns>
        public List<DepartmentDetails> GetDepartmentDetails()
        {
            return _efDbContext.DepartmentDetails.ToList();
        }

        /// <summary>
        /// Method to save the data to db
        /// </summary>
        /// <param name="departmentDetails"></param>
        public void SaveDetails(DepartmentDetails departmentDetails)
        {
            _efDbContext.DepartmentDetails.Add(departmentDetails);
            _efDbContext.SaveChanges();
        }
    }
}
