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
            dynamic person = Factory.New.DynamicPerson;
            person(
                FirstName: "Andy",
                LastName: "Sanchez",
                Manager: Factory.New.DynamicPerson(
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

            Console.WriteLine("----------Inicializar a traves de New cualquier tipo y implemetacion de index con reflection-------------");
            var p = Factory.New.PersonReflectionIndex;
            p["FirstName"] = "Eutelio";
            p["LastName"] = "Vesalle";
            Console.WriteLine($"FirstName: {p.FirstName}, LastName: {p.LastName}");
        }
    }
}