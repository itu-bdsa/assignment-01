namespace Assignment1;

public class Person : IComparable<Person>
{
    private string name;
    private int studentID;

    public Person(string name, int age)
    {
        this.name = name;
        this.studentID = age;
    }

    public int CompareTo(Person? other)
    {
        if (other == null)
        {
            throw new ArgumentNullException("Cannot compare to null person");
        }

        if (studentID < other.studentID)
        {
            return -1;
        }
        else if (studentID > other.studentID)
        {
            return 1;
        }
        return 0;
    }
}