using System;
namespace Task7_a;

//  ## Task 7 (Optional)
//     - Apply the encapsulation concept for the Student and Staff classes
//     a) Use Getter/Setter methods

public class Person
{
    private string _name;
    private int _age;

    public Person(string name , int age)
    {

        if(name == null || name == "" || name.Length >= 32)
        {
            throw new Exception("invalid name");
        }

        if(age <= 0 || age > 128)
        {
            throw new Exception("invalid age");
        }

        _name = name;
        _age = age;
    }

    public string GetName() => _name ;
    public int GetAge() => _age ;

    public void SetName(string name)
    {
        if(name == null || name == "" || name.Length >= 32)
        {
            throw new Exception("invalid name");
        }
        _name = name ;
    }

    public virtual void Print()
    {
        Console.WriteLine($"My name is {GetName()}, my age is {GetAge()}");
    }
}

public class Student : Person
{
    private int _year;
    private float _gpa;

    public Student(string name , int age,  int year, float gpa) : base(name , age)
    {
        if(year < 1 || year > 5)
        {
            throw new Exception("invalid Year");
        }

        if(gpa < 0 || gpa > 4)
        {
            throw new Exception("invalid Gpa");
        }

        _year = year;
        _gpa = gpa;
    }

    public int GetYear() => _year ;
    public float GetGpa() => _gpa ;

    public void SetGpa(float gpa)
    {
        if(gpa < 0 || gpa > 4)
        {
            throw new Exception("invalid Gpa");
        }
    }
    public override void Print()
    {
        Console.WriteLine($"My name is {GetName()}, my age is {GetAge()}, and gpa is {GetGpa()}");
    }
}

public class Staff : Person
{

    private double _salary;
    private int _joinYear;
    
    public Staff (string name , int age , double salary , int joinYear) : base(name , age)
    {

        if(salary <= 0 || salary > 120000)
        {
            throw new Exception("invalid Salary");
        }

        if( joinYear - age <= 21 )
        {
            throw new Exception("invalid JoinYear");
        }

        _salary=salary;
        _joinYear=joinYear;
    }

    public double GetSalary() => _salary;
    public int GetJoinYear() => _joinYear;

    public void SetSalary(double salary)
    {
        if(salary <= 0 || salary > 120000)
        {
            throw new Exception("invalid Salary");
        }
        _salary = salary;
    }
    public override void Print()
    {
        Console.WriteLine($"My name is {GetName()}, my age is {GetAge()}, and my salary is {GetSalary()}");
    }

}

public class Database
{

    private int _currentIndex;

    public Person[] People=new Person[50];
    
    public void AddStudent(Student student)
    {
        People[_currentIndex++]=student;
    }
    public void AddStaff(Staff staff)
    {
        People[_currentIndex++]=staff;
    }
    public void AddPerson(Person person)
    {
        People[_currentIndex++]=person;
    }
    public void PrintAll()
    {
        for(int i=0 ; i<_currentIndex ; i++)
        {
            People[i].Print();
        }
    }
}

public  class Program7_a
{

private static void Main(){
    
    var database=new Database();

    while (true)
    {
        Console.WriteLine("Enter a Number 1-Student , 2-Staff , 3-Is Person but (Not Staff and Not Student) , 4-Print all peaple");

        Console.Write("Option: ");
        var option = Convert.ToInt32(Console.ReadLine());

        switch (option)
        {
            case 1:

                Console.Write("Name: ");
                var name=Console.ReadLine();

                Console.Write("Age: ");
                var age =Convert.ToInt32(Console.ReadLine());

                Console.Write("Year: ");
                var year =Convert.ToInt32(Console.ReadLine());

                Console.Write("Gpa: ");
                var gpa = Convert.ToSingle(Console.ReadLine());

                try
                {
                    var student = new Student(name,age,year,gpa);
                    database.AddStudent(student);
                    student.SetGpa(5);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            break;
                
            case 2:

                Console.Write("Name: ");
                name=Console.ReadLine();

                Console.Write("Age: ");
                age =Convert.ToInt32(Console.ReadLine());
            
                Console.Write("Salary: ");
                var salary = Convert.ToDouble(Console.ReadLine());
            
                Console.Write("JoinYear: ");
                var joinyear = Convert.ToInt32(Console.ReadLine());
            
                try
                {
                    var staff =new Staff(name,age,salary,joinyear);
                    database.AddStaff(staff);
                    // staff.SetSalary(0);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
        
            break;
                
            case 3:

                Console.Write("Name: ");
                name=Console.ReadLine();

                Console.Write("Age: ");
                age =Convert.ToInt32(Console.ReadLine());

                try
                {
                    var person= new Person(name , age);
                    database.AddPerson(person);
                    person.SetName(null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            break;

            case 4:

                database.PrintAll();

            break;

            default:
                return;
        }
    }

}
}
