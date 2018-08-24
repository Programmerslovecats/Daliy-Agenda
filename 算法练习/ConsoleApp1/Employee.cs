namespace ConsoleApp1
{
    public  class Employee
    {
        public string Name { get; private set; }
        public int value { get; private set; }

        public Employee(string name, int value)
        {
            this.Name = name;
            this.value = value;
        }
    }
}