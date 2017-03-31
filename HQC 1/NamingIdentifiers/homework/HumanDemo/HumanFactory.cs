namespace WellNamedRefactoring
{
    public class HumanFactory
    {        
        public void CreateHuman(int age)
        {
            var human = new Human();
            human.Age = age;
            if (age % 2 == 0)
            {
                human.Name = "Pesho";
                human.Gender = GenderType.Male;
            }
            else
            {
                human.Name = "Penka";
                human.Gender = GenderType.Female;
            }
        }
    }
}
