using System;

namespace UniversitySystem
{
    delegate void ShowAllInfos();
    
    interface IPrintable
    {
        void Info();
        void ShowFullInfo();
        void ShowShortInfo();
        void ShortestInfo();
    }
    abstract class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string University { get; set; } = "BSUIR";
        public int EducationLength { get; set; } = 4;
        
        public int ID { get; private set; }
        private static int Count { get; set; }

        public Student()
        {

        }

        public Student(Student other)
        {
            Name = other.Name;
            Surname = other.Surname;
            Age = other.Age;
            Sex = other.Sex;
            University = other.University;
            EducationLength = other.EducationLength;
            ID = Count;
            Count++;
        }

        public Student(string _name, string _surname, int _age, string _sex, string _university, int _educlength)
        {
            Name = _name;
            Surname = _surname;
            Age = _age;
            Sex = _sex;
            University = _university;
            EducationLength = _educlength;
            ID = Count;
            Count++;
        }
        public void Info()
        {
            Console.WriteLine($"Sex {Sex}\nAge {Age}\nUniversity name {University}\nEducation Length {EducationLength} year(s)\nID {ID}");
        }

        virtual public void Enter()
        {
            Console.WriteLine("POKA STUDENT");
        }

        virtual public void ShortestInfo()
        {
            Console.WriteLine($"{Name} {Surname} {Age}");
        }
        abstract public void ShowFullInfo();
        abstract public void ShowShortInfo();
    }

    class Bachelor : Student, IPrintable, IComparable<Bachelor>
    {
        public string Specialty { get; set; }
        public string DiplomaTheme { get; set; }
        public double EducationCost { get; set; }
        public int Course { get; set; } = 1;
        public bool IsScienceWork { get; set; } = false;

        public Bachelor(string _name, string _surname, int _age, int _course)
        {
            Name = _name;
            Surname = _surname;
            Age = _age;
            Course = _course;
        }
        public struct Science
        {
            public string Field { get; set; }
            public string Theme { get; set; }
            public int NumberOfParticipants { get; set; }
        }
        public Science ScienceWork { get; set; }

        public Bachelor(string _name, string _surname, int _age, string _sex, string _university, int _educlength, string _specialty,
            string _diplomatheme, double _educationcost, int _course) : base(_name, _surname, _age, _sex, _university, _educlength)
        {
            Specialty = _specialty;
            DiplomaTheme = _diplomatheme;
            EducationCost = _educationcost;
            Course = _course;
        }

        public Bachelor(Bachelor other): base(other.Name, other.Surname, other.Age, other.Sex, other.University, other.EducationLength)
        {
            Name = other.Name;
            Surname = other.Surname;
            Age = other.Age;
            Sex = other.Sex;
            University = other.University;
            EducationLength = other.EducationLength;
            DiplomaTheme = other.DiplomaTheme;
            EducationCost = other.EducationCost;
            Course = other.Course;
        }

        override public void ShowFullInfo()
        {
            Console.WriteLine($"Information about Bachelor Student {Name} {Surname}");
            Info();
            Console.WriteLine($"Student Specialty: {Specialty}");
            Console.WriteLine($"Diploma Theme: {DiplomaTheme}");
            if (EducationCost == 0) Console.WriteLine($"This bachelor Student has free education");
            else Console.WriteLine($"Education Cost {EducationCost}");
            Console.WriteLine($"Course {Course}");
            if (IsScienceWork)
            {
                Console.WriteLine("This student is engaged in scientific activities");
                Console.WriteLine($"Science work field: {ScienceWork.Field}");
                Console.WriteLine($"Science work theme: {ScienceWork.Theme}");
                Console.WriteLine($"Science work number of patricipants: {ScienceWork.NumberOfParticipants}");
            }
        }

        override public void ShowShortInfo()
        {
            Console.WriteLine($"Short information about bachelor student {Name} {Surname}");
            Console.WriteLine($"Student Specialty: {Specialty}");
            Console.WriteLine($"Diploma Theme: {DiplomaTheme}");
            if (EducationCost == 0) Console.WriteLine($"This bachelor Student has free education");
            else Console.WriteLine($"Education Cost {EducationCost}");
            Console.WriteLine($"Course {Course}");
        }

        override public void ShortestInfo()
        {
            Console.WriteLine($"{Name} {Surname} {Age}, Course {Course}");
        }

        public int CompareTo(Bachelor other)
        {
            if (Course == other.Course)
            {
                if (Age == other.Age) return 0;
                return Age - other.Age;
            }
            return Course - other.Course;
        }
    }

    class Master : Student, IPrintable, IComparable<Master>
    {
        public enum Degree
        {
            Arts,
            Science,
            BussinessAdministration,
            Laws,
            PublicAdministration,
            FinancialTechnicalAnalysis,
            Engineering,
            Divinity,
            Theology,
            SocialWork,
            Philosophy,
            Letters
        }
        public double EducationCost {get; set;}
        public string DissertationTheme { get; set; }
        public Degree MasterDegree { get; set; }

        public Master(Student father, double _educcost, string _dissertation, Degree _degree): base(father)
        {
            EducationCost = _educcost;
            DissertationTheme = _dissertation;
            MasterDegree = _degree;
        }

        public Master(Student father, string _dissertation, Degree _degree) : base(father)
        {
            DissertationTheme = _dissertation;
            MasterDegree = _degree;
        }

        override public void ShowFullInfo()
        {
            Console.WriteLine($"Information about Master Student {Name} {Surname}");
            Info();
            Console.WriteLine("Student Degree: Master Degree of");
            switch (MasterDegree)
            {
                case Degree.Arts: Console.WriteLine("Arts"); break;
                case Degree.Science: Console.WriteLine("Science"); break;
                case Degree.BussinessAdministration: Console.WriteLine("Bussiness Administration"); break;
                case Degree.Laws: Console.WriteLine("Laws"); break;
                case Degree.PublicAdministration: Console.WriteLine("Public Administration"); break;
                case Degree.FinancialTechnicalAnalysis: Console.WriteLine("Financial Technical Analysis"); break;
                case Degree.Engineering: Console.WriteLine("Engineering"); break;
                case Degree.Divinity: Console.WriteLine("Divinity"); break;
                case Degree.Theology: Console.WriteLine("Theology"); break;
                case Degree.SocialWork: Console.WriteLine("Social Work"); break;
                case Degree.Philosophy: Console.WriteLine("Philosophy"); break;
                case Degree.Letters: Console.WriteLine("Letters"); break;
            }
            Console.WriteLine($"Dissertation Theme: {DissertationTheme}");
            if (EducationCost == 0) Console.WriteLine($"This master Student has free education");
            else Console.WriteLine($"Education Cost {EducationCost}");
        }
        override public void ShowShortInfo()
        {
            Console.WriteLine("Student Degree: Master Degree of");
            switch (MasterDegree)
            {
                case Degree.Arts: Console.WriteLine("Arts"); break;
                case Degree.Science: Console.WriteLine("Science"); break;
                case Degree.BussinessAdministration: Console.WriteLine("Bussiness Administration"); break;
                case Degree.Laws: Console.WriteLine("Laws"); break;
                case Degree.PublicAdministration: Console.WriteLine("Public Administration"); break;
                case Degree.FinancialTechnicalAnalysis: Console.WriteLine("Financial Technical Analysis"); break;
                case Degree.Engineering: Console.WriteLine("Engineering"); break;
                case Degree.Divinity: Console.WriteLine("Divinity"); break;
                case Degree.Theology: Console.WriteLine("Theology"); break;
                case Degree.SocialWork: Console.WriteLine("Social Work"); break;
                case Degree.Philosophy: Console.WriteLine("Philosophy"); break;
                case Degree.Letters: Console.WriteLine("Letters"); break;
            }
            Console.WriteLine($"Dissertation Theme: {DissertationTheme}");
            if (EducationCost == 0) Console.WriteLine($"This master Student has free education");
            else Console.WriteLine($"Education Cost {EducationCost}");
        }

        override public void ShortestInfo()
        {
            Console.WriteLine($"{Name} {Surname} {Age}, Education cost {EducationCost}");
        }

        public int CompareTo(Master other)
        {
            if (Age == other.Age)
            {
                if (EducationCost > other.EducationCost) return 1;
                if (EducationCost < other.EducationCost) return -1;
                return 0;
            }
            return Age - other.Age;
        }
    }

    class Aspirant : Student, IPrintable
    {
        public string DissertationTheme { get; set; }
        public string TeachingSpecialty { get; set; }

        public Aspirant(Student father, string _dissert, string _teaching) : base(father)
        {
            DissertationTheme = _dissert;
            TeachingSpecialty = _teaching;
        }

        override public void ShowFullInfo()
        {
            Console.WriteLine($"Information about Aspirant Student{Name} {Surname}");
            Info();
            Console.WriteLine($"Dissertation Theme: {DissertationTheme}");
            Console.WriteLine($"This Aspirant Student is teaching bachelor students of {TeachingSpecialty} specialty");
        }
        override public void ShowShortInfo()
        {
            Console.WriteLine($"Dissertation Theme: {DissertationTheme}");
            Console.WriteLine($"This Aspirant Student is teaching bachelor students of {TeachingSpecialty} specialty");
        }

        override public void Enter()
        {
            Console.WriteLine("POKA ASPIRANT");
        }
    }

    class Program
    {
        static public void add(Student st)
        {
            st.Enter();
        }
        static void Main(string[] args)
        {
            Bachelor st = new Bachelor("Ivan", "Petrov", 18, "Male", "BSUIR", 4, "Informatics", "Programming Languages Types", 3200, 1);
            st.ShowFullInfo();
            Console.WriteLine();
            Student st2 = new Bachelor(st);
            st2.Info();

            Aspirant st4 = new Aspirant(st, "IOT", "IITP 2020");
            st4.Name = "Andrey";
            st4.Surname = "Orlov";
            st4.ShowFullInfo();
            
            if (st4 is Aspirant) Console.WriteLine($"{st4.Name} {st4.Surname} is ASPIRANT");
            if (st4 is Student) Console.WriteLine($"{st4.Name} {st4.Surname} is STUDENT");

            Console.WriteLine();
            Master st3 = new Master(st, "Programming", Master.Degree.BussinessAdministration);
            st3.ShowFullInfo();
            Console.WriteLine();


            Bachelor compSt = new Bachelor("Andrey", "Petrov", 18, 1);
            Bachelor compSt1 = new Bachelor("Vasiliy", "Gnomov", 19, 2);
            Bachelor compSt2 = new Bachelor("Kostya", "Komov", 20, 3);
            Bachelor[] bachelors = new Bachelor[] { compSt, compSt2, compSt1 };

            Console.WriteLine("Before sorting: ");
            foreach (Bachelor i in bachelors)
            {
                i.ShortestInfo();
            }


            Array.Sort(bachelors);

            Console.WriteLine("\nAfter sorting:");
            foreach (Bachelor i in bachelors)
            {
                i.ShortestInfo();
            }

            Console.WriteLine("\n\n\nWorking with delegates:\n");

            ShowAllInfos bachInfo = st.ShowFullInfo;
            bachInfo += st.ShowShortInfo;
            bachInfo += st.ShortestInfo;

            bachInfo?.Invoke();
        }
    }
}
