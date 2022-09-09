namespace Assignment1;

public class Student : Person, IComparable<Student>
{
    private int studentID;

    public Student(string name, int age, int studentID) : base(name, age)
    {
        this.studentID = studentID;
    }

    public int CompareTo(Student? other)
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