using System;
using System.Reflection;
using System.Collections.Generic;

namespace ReflectionTest
{
    public class AnonymClass
    {
        public static void RunTest()
        {
            var ac = new {
                id = 2, 
                name = "AAAA", 
                fun_property = (Func<int>)(() => 4),
                //method = Method2,
                method_rest = Method(),
                list = new List<int>()
                };

            Console.WriteLine(ac.GetType().Name);
            foreach ( MemberInfo item in ac.GetType().GetMembers())
            {
                if(item.MemberType == MemberTypes.Property)
                    Console.WriteLine($"{item.Name} : {item.MemberType} : {ac.GetType().GetProperty(item.Name).PropertyType} ");
                else
                    Console.WriteLine($"{item.Name} : {item.MemberType} ");

            }
        }
        public static Func<int> Method(object a = null) => () => 4;
        public static int Method2() => 1;

    }
}