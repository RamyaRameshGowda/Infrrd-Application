using DataAccess.Model;
using Infrrd.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Contract
{
    public interface IDepartmentDetailsBizManager
    {
        List<DepartmentDetailsView> GetDepartmentDetails();
        void SaveDetails(DepartmentDetails departmentDetails);
    }
}
