using System.Collections.Generic;

namespace delegates_presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee> ();

            empList.Add(new Employee(100, "Peter", 5000, 5));
            empList.Add(new Employee(200, "John", 3000, 4));
            empList.Add(new Employee(300, "Isabell", 7000, 6));
            empList.Add(new Employee(400, "Mike", 2000, 3));

            Employee.PromoteEmployee(empList);

            // IsPromotable isPromotable = new IsPromotable(Promote);
            // Employee.PromoteEmployee(empList, isPromotable);
        }
        // public static bool Promote(Employee emp) => emp.Experience >= 5;
    }

}






















            