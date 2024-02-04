using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppr_zal_gr3_zaklad
{
    public class Employee
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public DateTime birthDate { get; set; }
        public string occupation { get; set; }
        public decimal hourlyRate { get; set; }
        public decimal fullTimeSallary { get; set; }
    }
}
