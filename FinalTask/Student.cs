namespace FinalTask
{
    [Serializable]
    internal class Student
    {
        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Student(string nameParam, string groupParam, DateTime dateOfBirthParam)
        {
            Name = nameParam;
            Group = groupParam;
            DateOfBirth = dateOfBirthParam;
        }
    }
}
