using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Reflection;

namespace CShap40
{
    class Test
    {
        static public void Run()
        {
            //Atributos definidos dinamicamente
            Console.WriteLine("-------------Atributos definidos dinamicamente-------------");
            var person = Factory.New.Person(
                FirstName: "Andy",
                LastName: "Sanchez",
                Manager: Factory.New.Person(
                    FirstName: "Bertrand",
                    LastName: "Le Roy"
                ));
            Console.WriteLine($"FirstName: {person.FirstName}, LastName: {person.LastName}");
            Console.WriteLine($"Manager FirstName: {person.Manager.FirstName}, Manager LastName: {person.Manager.LastName}");

            //Inicializar a traves de New cualquir tipo
            Console.WriteLine("-------------Inicializar a traves de New cualquier tipo-------------");
            var auto = Factory.New.Car;
            auto.Mark = "Audi";
            auto.Color = "Black";
            Console.WriteLine($"Mark: {auto.Mark}, Color: {auto.Color}");
        }
    }
}