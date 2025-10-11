namespace MyBlazorApp.StudentManager;

public class Student
{
    public string Name { get; set; }
    public int ID { get; set; }
    public double Grade { get; set; }

    public Student(string name, int id, double grade)
    {
        Name = name;
        ID = id;
        Grade = grade;
    }
}