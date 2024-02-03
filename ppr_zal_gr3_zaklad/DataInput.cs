using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ppr_zal_gr3_zaklad
{
    public static class DataInput
    {
        public static List<Employee> GetEmployees()
        {
            var path = Directory.GetCurrentDirectory() + "\\employee_list.json";
            var data = File.ReadAllText(path);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<List<Employee>>(data, options);
        }
    }
}
