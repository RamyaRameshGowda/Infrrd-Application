using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Model
{
    public class DepartmentDetails
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Amount { get; set; }
        public int Year { get; set; }

        public virtual Category Category { get; set; }
    }
}
