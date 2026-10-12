using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Student_Managment_System_Console_App
{
    class Student {
        public int Studentid;
        public string StudentName;
        public int StudentAge;
        public List<Courses> courses;

        public Student(int studentid, string studentName, int studentAge)
        {
            Studentid = studentid;
            StudentName = studentName;
            StudentAge = studentAge;
            this.courses = new List<Courses>();
        }

       public bool EnrollCourse(Courses course)
        {
            courses.Add(course);
            return true;
        }

       public string PrintDetails()
        {
            
            string studentDetails = $"Student ID: {Studentid}, Student Name: {StudentName}, Student Age: {StudentAge}";
            for(int i = 0; i < courses.Count; i++)
            {
                studentDetails += $"\nCourse ID: {courses[i].CourseId}, Course Title: {courses[i].Coursetitle}, Instructor: {courses[i].instructor.InstructorName}";
              
            }
            return studentDetails;
        }

    }

    class Courses
    {
       public int CourseId;
        public string Coursetitle;
        public Instructor instructor;

        public Courses(int courseId, string coursetitle, Instructor instructor)
        {
           this. CourseId = courseId;
            this.Coursetitle = coursetitle;
            this.instructor = instructor;
        }

       public string PrintDetails()
        {
            return $"Course ID: {CourseId}, Course Title: {Coursetitle}, Instructor: {instructor.InstructorName}";
        }



    }

    class Instructor
    {
        public int InstructorId;
        public string InstructorName;
        public string Specialization;

        public Instructor(int instructorId, string instructorName, string specialization)
        {
            this.InstructorId = instructorId;
            this.InstructorName = instructorName;
            this.Specialization = specialization;
        }

       public string PrintDetails()
        {
            return $"Instructor ID: {InstructorId}, Instructor Name: {InstructorName}, Specialization: {Specialization}";
        }
    }

    class StudentManager
    { 
      public  List<Student> students;
       public List<Courses> courses;
       public List<Instructor> instructors;

        public StudentManager()
        {
            students = new List<Student>();
            courses = new List<Courses>();
            instructors = new List<Instructor>();
        }

       public bool AddStudent(Student student)
        {
            if(student == null)
            {
                return false;
            }
            students.Add(student);
            return true;
        }

        public bool AddCourse(Courses course)
        {
            if (course == null)
            {
                return false;
            }
            courses.Add(course);
            return true;
        }

        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null)
            {
                return false;
            }
            instructors.Add(instructor);
            return true;
        }

        public Student FindStudentbyId(int studentId)
        {
            for(int i = 0; i < students.Count; i++)
            {
                if (students[i].Studentid == studentId)
                {
                    return students[i];
                }
            }
            return null;
        }


        public Student FindStudentbyname(string studentName)
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].StudentName == studentName)
                {
                    return students[i];
                }
            }
            return null;
        }




        public Courses FindCoursebyId(int courseId)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].CourseId == courseId)
                {
                    return courses[i];
                }
            }
            return null;
        }


        public Courses FindCoursebyName(string courseName)
        {
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Coursetitle == courseName)
                {
                    return courses[i];
                }
            }
            return null;
        }

        public Instructor FindInstructor(int instructorId)
        {
            for (int i = 0; i < instructors.Count; i++)
            {
                if (instructors[i].InstructorId == instructorId)
                {
                    return instructors[i];
                }
            }
            return null;
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudentbyId(studentId);
            Courses course = FindCoursebyId(courseId);

            if (student == null || course == null)
            {
                return false;
            }

            student.courses.Add(course);
            return true;
        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
           int choice;
            StudentManager sm = new StudentManager();
            do
            {
                Console.WriteLine();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Instructor");
                Console.WriteLine("3. Add Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. Show All Students");
                Console.WriteLine("6. Show All Courses");
                Console.WriteLine("7. Show All Instructors");
                Console.WriteLine("8. Find the Student by id or name");
                Console.WriteLine("9. Find the course by id or name");
                Console.WriteLine("10. Exit");
                Console.WriteLine("11. Check if the student  enrolled in specific course");
                Console.WriteLine("12. Return Instructor name by course name");
                Console.WriteLine();  
                Console.Write("Enter Your Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                
                switch (choice)
                {
                    case 1:

                        Console.Write("please enter student id:");

                        int studentId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("please enter student name:");

                        string studentName = Console.ReadLine();

                        Console.Write("please enter student age:");

                        int studentAge = Convert.ToInt32(Console.ReadLine());

                        Student student = new Student (studentId, studentName, studentAge);

                        sm.AddStudent(student);

                        break;

                    case 2:
                       Console.WriteLine("please enter instructor id:");

                        int instructorId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("please enter instructor name:");

                        string instructorName = Console.ReadLine();

                        Console.WriteLine("please enter instructor specialization:");

                        string specialization = Console.ReadLine();

                        Instructor instructor = new Instructor(instructorId, instructorName, specialization);

                        sm.AddInstructor(instructor);

                        break;

                    case 3:

                        Console.WriteLine("please enter course id:");

                        int courseId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("please enter course title:");

                        string courseTitle = Console.ReadLine();

                        Console.WriteLine("please enter instructor id for the course:");

                        int courseInstructorId = Convert.ToInt32(Console.ReadLine());

                        Instructor courseInstructor = null;

                        for (int i = 0; i < sm.instructors.Count; i++)
                        {
                            if (sm.instructors[i].InstructorId == courseInstructorId)
                            {
                                courseInstructor = sm.instructors[i];
                                break;
                            }
                        }

                        if (courseInstructor == null)
                        {
                            Console.WriteLine("Instructor not found. Course not added.");
                        }

                        else
                        {
                            Courses course = new Courses(courseId, courseTitle, courseInstructor);
                            sm.AddCourse(course);
                        }
                            break;

                    case 4 :

                       Console.WriteLine("please enter student id:");

                        int enrollStudentId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("please enter course id:");

                        int enrollCourseId = Convert.ToInt32(Console.ReadLine());

                       bool enrolled = sm.EnrollStudentInCourse(enrollStudentId, enrollCourseId);

                        if (enrolled)
                        {
                            Console.WriteLine("Student enrolled in course successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to enroll student in course.");
                        }

                        break;

                    case 5:

                        if(sm.students.Count == 0)
                        {
                            Console.WriteLine("No students found.");
                            break;
                        }
                        for (int i = 0; i < sm.students.Count; i++)
                        {
                            Console.WriteLine(sm.students[i].PrintDetails());
                            Console.WriteLine("==============================================");
                        }
                        break;

                    case 6:

                        if(sm.courses.Count == 0)
                        {
                            Console.WriteLine("No courses found.");
                            break;
                        }
                        for (int i = 0; i < sm.courses.Count; i++)
                        {
                            Console.WriteLine(sm.courses[i].PrintDetails());
                            Console.WriteLine("==============================================");
                        }
                        break;

                    case 7:

                        if(sm.instructors.Count == 0)
                        {
                            Console.WriteLine("No instructors found.");
                            break;
                        }
                        for (int i = 0; i < sm.instructors.Count; i++)
                        {
                            Console.WriteLine(sm.instructors[i].PrintDetails());
                            Console.WriteLine("==============================================");
                        }
                        break;

                    case 8:

                       

                     Console.WriteLine("please enter student id or name:");

                       string inputType = Console.ReadLine();

                        if (inputType == "id")
                        {
                            Console.WriteLine("please enter student id:");

                            int studentid = Convert.ToInt32(Console.ReadLine());
                            
                            Student stud = sm.FindStudentbyId(studentid);

                            if (stud != null)
                            {
                                Console.WriteLine(stud.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                        }

                        else if(inputType == "name")
                        {
                            Console.WriteLine("please enter student name:");

                            string studentname = Console.ReadLine();

                            Student stud = sm.FindStudentbyname(studentname);

                            if (stud != null)
                            {
                                Console.WriteLine(stud.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                        }
                      
                        break;

                    case 9:

                        Console.WriteLine("please enter course id or name:");

                        string courseInputType = Console.ReadLine();

                        if(courseInputType == "id")
                        {
                            Console.WriteLine("please enter course id:");

                            int courseid = Convert.ToInt32(Console.ReadLine());

                            Courses course = sm.FindCoursebyId(courseid);

                            if (course != null)
                            {
                                Console.WriteLine(course.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Course not found.");
                            }
                        }
                        else if (courseInputType == "name")
                        {
                            Console.WriteLine("please enter course name:");

                            string coursename = Console.ReadLine();

                            Courses course = sm.FindCoursebyName(coursename);

                            if (course != null)
                            {
                                Console.WriteLine(course.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Course not found.");
                            }
                        }

                        break;

                    case 10:

                        Console.WriteLine("Exit.");

                        break;


                    case 11:

                        Console.WriteLine("Please enter student id to check enrollment:");

                        int checkStudentId = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Please enter course id to check enrollment:");

                        int checkCourseId = Convert.ToInt32(Console.ReadLine());

                        bool isEnrolled = false;

                        for (int i = 0; i < sm.students.Count; i++)
                        {
                            if (sm.students[i].Studentid == checkStudentId)
                            {
                                for (int j = 0; j < sm.students[i].courses.Count; j++)
                                {
                                    if (sm.students[i].courses[j].CourseId == checkCourseId)
                                    {
                                        Console.WriteLine($"Student with ID {checkStudentId} is enrolled in course with ID {checkCourseId}.");
                                        isEnrolled = true;
                                        break;
                                    }
                                }
                            }
                        }

                        if (!isEnrolled)
                        {
                            Console.WriteLine($"Student with ID {checkStudentId} is not enrolled in course with ID {checkCourseId}.");
                        }

                        break;

                     case 12:

                       Console.WriteLine("Please enter course name to find the instructor:");

                        string courseName = Console.ReadLine();

                        for(int i = 0; i < sm.courses.Count; i++)
                        {
                            if (sm.courses[i].Coursetitle == courseName)
                            {
                                Console.WriteLine($"Instructor for course '{courseName}'is {sm.courses[i].instructor.InstructorName}");
                                break;
                            }
                        }
                        
                        break;

                    default:

                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            } while (choice != 10);

        }
    }
}
