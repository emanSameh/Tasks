using System;
namespace Task2;

public class Person
{
    public string Name;
    public int Age;

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
    public int Year;
    public float Gpa;

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
    public double Salary;
    public int JoinYear;
    
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

public  class Program3
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

                var student = new Student(name,age,year,gpa);

                database.AddStudent(student);

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
            
                var staff =new Staff(name,age,salary,joinyear);
            
                database.AddStaff(staff);
        
            break;
                
            case 3:

                Console.Write("Name: ");
                name=Console.ReadLine();

                Console.Write("Age: ");
                age =Convert.ToInt32(Console.ReadLine());

                var person= new Person(name , age);

                database.AddPerson(person);

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