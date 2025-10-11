namespace MyBlazorApp.StudentManager;

public class StudentService : IStudentService
{
    private List<Student> students = new List<Student>
    {
        new Student("Alice", 1, 60),
        new Student("Sara", 2, 70)
    };
    public List<Student> getAllStudents()
    {
        return students;
    }
    public void AddStudent(Student student)
    {
        throw new NotImplementedException();
    }

    public void DeleteStudent(int id)
    {
        throw new NotImplementedException();
    }
    public void sortByName(string name)
    {
        throw new NotImplementedException();
    }
    public void sortByGrade(double grade)
    {
        throw new NotImplementedException();
    }
  
    
    
}
