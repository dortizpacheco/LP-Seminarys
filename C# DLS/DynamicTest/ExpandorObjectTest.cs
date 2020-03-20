using System;
using System.Dynamic;
using System.Collections.Generic;
using System.Reflection;

namespace DynamicTest
{
    public class ExpandorObjectTest
    {
        public static void RunTest()
        {
            // var no reconoces object dynamic
            //var @dynamic = new ExpandoObject();
            //@dynamic.Method = Method;
            //@dynamic.A = "aaaa";

            //Esto tampoco funciona
            //ExpandoObject  expan = new ExpandoObject();
            //expan.Method = Method;
            //expan.A = "aaaa";

            dynamic @dynamic = new ExpandoObject();
            @dynamic.Method = (Action)Method;
            @dynamic.property = "Una propiedadddddddddd";

           // public sealed class ExpandoObject : IDictionary<string, object>
            ((IDictionary<string,object>)@dynamic).Add("dicProperty","una propiedad metia a la fuerza"); 

            Console.WriteLine(@dynamic.property);
            Console.WriteLine(@dynamic.dicProperty);
            @dynamic.Method();

            //buen funcionamiento del paradigma dinamico
            Console.WriteLine(@dynamic.GetType());

            
            //reflection no encuantra las propiedades dinamicas
            foreach(var property in @dynamic.GetType().GetMembers(BindingFlags.NonPublic | BindingFlags.Instance))
                Console.WriteLine($"{property.Name}");            

            // public sealed class ExpandoObject : ICollection<KeyValuePair<string, object>
            foreach(KeyValuePair<string,object> tuple in @dynamic)
                Console.WriteLine($"{tuple.Key} -- {tuple.Value}");

        }
        public static void Method() => Console.WriteLine("Un metodoooooo");
    }
}