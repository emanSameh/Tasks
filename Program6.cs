using System;
namespace Task6;

public class Person
{
    public string Name;
    public int Age;

// ## Task (4)
// 1) Add Validation in the Person class to match the following: -
//     - Name should be not null, not empty, and no more than 32 characters
//     - Age should be more than zero and no more than 128


    public Person(string name , int age)
    {

        if(name == null || name == "" || name.Length >= 32)
        {
            //  ## Task (5)
          // 1) Use Exception to break the code execution if something goes wrong

            throw new Exception("invalid name");
        }

        if(age <= 0 || age > 128)
        {
            throw new Exception("invalid age");
        }

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

//     ## Task 6
//     1) Add Validation in the Student class to match the following: -
//     - Year should between 1 and 5
//     - Gpa should between 0 and 4
//     - Make sure not to create the object if there's any validation issue (Optional)

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


//     ## Task 6
//     2) Add Validation in the Staff class to match the following: -
//     - Salary should be more than zero and no more than 120,000
//     - JoinYear should be more than age by 21 years
//     - Make sure not to create the object if there's any validation issue (Optional)
    
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

public  class Program6
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

               try
               {
                 var person= new Person(name , age);

                database.AddPerson(person);
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