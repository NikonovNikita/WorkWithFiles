class Program
{
    static void Main(string[] args)
    {
        string[] groupsExample = { "N-105", "G-101", "G-101", "N-105", "N-102", "G-151", "N-102", "G-100", "N-105", "G-500"};
        string[] mainGroups = new string[groupsExample.Length];
        for(int i = 0; i < groupsExample.Length; i++)
        {
            int counter = 0;
            
            for(int j = 0; j < mainGroups.Length; j++)
            {
                if (groupsExample[i] == mainGroups[j])
                    counter++;
            }
            
            for(int k = 0; k < mainGroups.Length; k++)
            {
                if (counter == 0 && mainGroups[k] == null)
                {
                    mainGroups[k] = groupsExample[i];
                    break;
                } 
            }
        }
        for(int i = 0; i < mainGroups.Length; i++)
        {
            if (mainGroups[i] == null)
                Array.Resize(ref mainGroups, i);
        }
        foreach(var value in mainGroups)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine(mainGroups.Length);
    }
}
