//  ## Task 7 (Optional)
//     - Apply the encapsulation concept for the Student and Staff classes
//     b) Using Properties

using System;
namespace Task7_b;

public class Person
{

    private string _name;
    public string Name 
    { 
        get { return _name;} 
        set
        {
            if(value == null || value == "" || value.Length >= 32)
            {
                throw new Exception("invalid name");
            }
            _name = value;
        } 
    }

    private int _age;
    public int Age 
    {
        get => _age; 
        set
        {
            if(value <= 0 || value > 128)
            {
                throw new Exception("invalid age");
            }
            _age = value;
        } 
    }

    public Person(string name , int age)
    {
        Name = name;
        Age = age;
    }
    public virtual void Print()
    {
        Console.WriteLine($"My name is {Name}, my age is {Age}");
    }
}

public class Student : Person
{
    private int _year;
    public int Year
    {
        get { return _year;} 
        set
        {
            if(value < 1 || value > 5)
            {
                throw new Exception("invalid Year");
            }
            _year = value;
        } 
    }

    private float _gpa;
    public float Gpa
    {
        get => _gpa;
        set
        {
            if(value <= 0 || value > 4)
            {
                throw new Exception("invalid Gpa");
            }
            _gpa = value;
        }
    }
    


    public Student(string name , int age,  int year, float gpa) : base(name , age)
    {
        Year = year;
        Gpa = gpa;
    }
    public override void Print()
    {
        Console.WriteLine($"My name is {Name}, my age is {Age}, and gpa is {Gpa}");
    }
}

public class Staff : Person
{

    private double _salary;
    public double Salary
    {
        get => _salary;
        set
        {
            if(value <= 0 || value > 120000)
            {
                throw new Exception("invalid Salary");
            }
            _salary = value;
        }
    }

    private int _joinYear;
    public int JoinYear
    {
        get => _joinYear;
        set
        {
            if( value - Age <= 21 )
            {
                throw new Exception("invalid JoinYear");
            }
            _joinYear = value;
        }
    }
    
    public Staff (string name , int age , double salary , int joinYear) : base(name , age)
    {
        Salary=salary;
        JoinYear=joinYear;
    }
    public override void Print()
    {
        Console.WriteLine($"My name is {Name}, my age is {Age}, and my salary is {Salary}");
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

public  class Program7_b
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
                    student.Gpa = 10;
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
                    person.Name = null ;
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


