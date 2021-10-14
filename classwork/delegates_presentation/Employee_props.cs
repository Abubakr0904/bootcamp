namespace delegates_presentation
{
    public partial class Employee
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public int Salary { get; private set; }
        public int Experience { get; private set; }

        public Employee(int id, string name, int salary, int experience)
        {
            ID = id;
            Name = name;
            Salary = salary;
            Experience = experience;
        }
    }
}