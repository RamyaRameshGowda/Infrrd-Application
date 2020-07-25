using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Contract
{
    public interface IDepartmentDetailsDataManager
    {
        List<DepartmentDetails> GetDepartmentDetails();
        void SaveDetails(DepartmentDetails departmentDetails);
    }
}
