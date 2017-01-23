namespace StudentGroups
{
    public class Group
    {    
        public Group(int numberOfGroup, string nameOfDepartament)
        {
            this.GroupNumber = numberOfGroup;
            this.DepartamentName = nameOfDepartament;
        }

        public string DepartamentName { get; set; }
        public int GroupNumber { get; set; }
    }
}
