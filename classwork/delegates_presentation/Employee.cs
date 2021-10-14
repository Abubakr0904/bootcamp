using System;
using System.Collections.Generic;

namespace delegates_presentation
{
    public partial class Employeea
    {
        public static void PromoteEmployee(List<Employee> employeeList, IsPromotable isEligibleToPromote)
        {
            foreach (var employee in employeeList)
            {
                if(isEligibleToPromote.Invoke(employee))
                {
                    Console.WriteLine($"{employee.Name} promoted");
                }
            }
        }
    }
}