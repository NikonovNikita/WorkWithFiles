[Serializable]
internal class Student
{
    private string name;
    private string group;
    private DateTime dayOfBirth;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public string Group
    {
        get
        {
            return group;
        }
        set
        {
            group = value;
        }
    }
    public DateTime DayOfBirth
    {
        get
        {
            return dayOfBirth;
        }
        set
        {
            dayOfBirth = value;
        }
    }
    public Student(string nameParam, string groupParam, DateTime dayOfBirthParam)
    {
        Name = nameParam;
        Group = groupParam;
        DayOfBirth = dayOfBirthParam;
    }
}
