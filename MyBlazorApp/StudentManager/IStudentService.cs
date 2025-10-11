namespace MyBlazorApp.StudentManager;

public interface IStudentService
{
    List<Student> getAllStudents();
    void AddStudent(Student student);
    void DeleteStudent(int id);
    void sortByName(string name);
    void sortByGrade(double grade);
}