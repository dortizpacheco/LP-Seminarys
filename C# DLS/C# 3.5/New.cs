using System;
using System.Dynamic;
using TestClass;

namespace CShap35
{

    public class New
    {
        public Person Person 
        {
            get
            {
                return new Person();
            }
        }

    }
    static public class NewExtension
    {
        static public Person Person(this New n,string FirstName,string LastName,Person Manager = null) => new Person(FirstName,LastName,Manager);
    }

}