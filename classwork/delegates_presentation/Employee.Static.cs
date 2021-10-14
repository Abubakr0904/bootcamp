using System;
using System.Collections.Generic;

namespace delegates_presentation
{
    public partial class Employee
    {
        public static void PromoteEmployee(List<Employee> employeeList)
        {
            foreach (var employee in employeeList)
            {
                if(employee.Experience >= 5)
                {
                    Console.WriteLine($"{employee.Name} promoted");
                }
            }
        }
    }
}