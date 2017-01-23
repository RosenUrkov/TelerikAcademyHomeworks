namespace SchoolSystem
{
    public abstract class Person
    {
        public Person(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}
