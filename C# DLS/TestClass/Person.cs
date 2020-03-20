using System;
using System.Collections.Generic;

namespace TestClass
{
    public class Person
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public Person Manager {get;set;}

        public Person() {}
        public Person(string FirstName,string LastName,Person Manager = null)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Manager = Manager;
        } 

        public string this[string index]
        {
            get
            {
                switch(index)
                {
                    case "FirstName":
                        return this.FirstName;
                    case "LastName":
                        return this.LastName;
                    default:
                        throw new KeyNotFoundException(); 
                }
            }
            set
            {
                switch(index)
                {
                    case "FirstName":
                        this.FirstName = value;
                        break;
                    case "LastName":
                        this.LastName = value;
                        break;
                    default:
                        throw new KeyNotFoundException(); 
                }  
            }
        }
    }

    static public class PersonExtension
    {
        static public Person FirstName(this Person p,string name)
        {
            p.FirstName = name;
            return p;
        }
        static public Person LastName(this Person person,string name)
        {
            person.LastName = name;
            return person;
        }
        static public void Print(this Person p,string messenger = null)
        {
            if(messenger != null){ 
            Console.WriteLine("Les presentamos a esta persona creada de manera: " + messenger);
            Console.Write("Saluden a : ");
            }
            Console.Write(p.FirstName + " " + p.LastName);
            if(p.Manager != null)
            {
                Console.Write(" y su manager : ");
                Print(p.Manager);
                return;
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    
}