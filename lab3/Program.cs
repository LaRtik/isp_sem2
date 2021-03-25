using System;

namespace lab3
{
    class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        protected double Money { get; set; }

        public int ID { get; private set; }
        private static int Count;

        public Human() : this("Ivan", "Petrov", "Male", 18, 0) { ID = Count; Count++; }

        public Human(Human other)
        {
            Name = other.Name;
            Surname = other.Surname;
            Sex = other.Sex;
            Age = other.Age;
            Money = other.Money;
            ID = Count;
            Count++;
        }

        public Human(string name, string surname, string sex, int age, double money)
        {
            Name = name;
            Surname = surname;
            Sex = sex;  
            Age = age;
            Money = money;
            ID = Count;
            Count++;
        }
        public Human(string name, string surname, string sex, int age)
        {
            Name = name;
            Surname = surname;
            Sex = sex;
            Age = age;
            ID = Count;
            Count++;
        }

        public void BaseInfo()
        {
            Console.WriteLine($"Name: {Name}\nSurname: {Surname}\nSex: {Sex}\nAge: {Age}\nMoney: {Money}$");
        }

        public void ShortBaseInfo()
        {
            Console.WriteLine($"{Name} {Surname}, {Sex} {Age}, ID = {ID}");
        }

        public void GetCount()
        {
            Console.WriteLine(Count);
        }
    }

    class Student : Human
    {
        public string University { get; set; }
        
        public int Course { get; set; }
        public double Stipend { get; set; }

        public Student() { University = "BSUIR"; Course = 1; Stipend = 0;}

        public Student(Human father) : base(father) { }

        public Student(Human father, string university, int course, double stipend) : base(father)
        {
            University = university;
            Course = course;
            Stipend = stipend;
        }

        public Student(Human father, string university, int course) : base (father)
        {
            University = university;
            Course = course;
            Stipend = 0;
        }

        public void GetStipend()
        {
            if (Stipend == 0)
            {
                Console.WriteLine($"That's sad =(. Student {Name} {Surname} has no stipend.");
            }
            else
            {
                Money += Stipend;
                Console.WriteLine($"Student {Name} {Surname} succesfully got stipend ({Stipend}$)! New balance: {Money}$");
            }
        }

        public void StudentInfo()
        {
            Console.WriteLine($"University: {University}\nCourse: {Course}\nStipend: {Stipend}");
        }
    }

    class SpecialtyStudents
    {
        public string Specialty { get; set; }

        Student[] students;

        public SpecialtyStudents(int count)
        {
            students = new Student[count]; 
        }
        
        public Student this [int index]
        {
            get
            {
                return students[index];
            }

            set
            {
                students[index] = value;
            }
        }

        public void AllInfo()
        {
            Console.WriteLine($"Information about all {Specialty} students:");
            for (int i = 0; i<students.Length; i++)
            {
                if (students[i] == null) continue;
                students[i].ShortBaseInfo();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Student st = new Student();
            st.BaseInfo(); // Ivan Petrov, Male 18, money 0
            st.StudentInfo(); // BSUIR, course 1, stipend 0
            st.GetStipend(); // ivan petrov has no stipend
            st.Stipend += 100; 
            st.GetStipend(); // ivan petrov has given a stipend
            st.BaseInfo(); // ivan petrov, male 18, money 100
            Human man = new Human("Semen", "Yakovlel", "Male", 19);
            Student st1 = new Student(man, "BSUIR", 2);
            Student st2 = new Student(new Human("Masha", "Veras", "Female", 20));

            SpecialtyStudents informatics = new SpecialtyStudents(3);
            informatics[0] = st;
            informatics[1] = st1;
            informatics[2] = st2;
            informatics.Specialty = "Informatics";
            informatics.AllInfo();
        }
    }
}
