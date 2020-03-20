using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System;
using System.Reflection;

namespace DynamicTest
{
    public class TryInvokeMemberTest
    {
        public static void RunTest()
        {
            Console.WriteLine("------------------Viendo con se manejan los llamados a funciones ------------------");
            dynamic @dynamic = new NameMethodTest();
            @dynamic.Print();
            var a = @dynamic.InnerTest();
            @dynamic.fafafaf();

            Console.WriteLine("------------------Viendo con se manejan los parametros y la info funciones ------------------");
            dynamic @dynamic1 = new ParameterMethodTest();
            int? @int = @dynamic1.Enterito(1,"aaaaaa",3.4);
            string @string = @dynamic1.Stringsito(1,"aaaaaa",3.4);
            var @null = @dynamic1.Varsito(
                entero : 3,
                cadena : "aaaa",
                doble  : 3.2
            );


        }

        class NameMethodTest : DynamicObject
        {
            Test innerTest = new Test();
            
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                Type dictType = typeof(Test);
                try
                {
                    //forma mas extensible medante reflection usar los metodos de clases internas
                    result = dictType.InvokeMember(
                                 binder.Name,
                                 BindingFlags.InvokeMethod,
                                 null, innerTest, args);
                    return true;
                }
                catch
                {
                    Console.WriteLine("Me imprimo siempre que no sepa que hacer al llamar a un metodo");
                    result = null;
                    return true;
                }
            }
            public void Print() => Console.WriteLine("Da preferencia a sus metodos sobre TryInvokeMember"); 
            class Test
            {
                public void InnerTest() => Console.WriteLine("aqui tu sabes trankilamente siendo DynamicObject.Test.InnerTest()");
            }
        }
        class ParameterMethodTest : DynamicObject
        {
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                Console.WriteLine($"El metodo {binder.Name} con valor de retorno {binder.ReturnType}");
                Console.WriteLine("fue llamado con los parametros:");
                Console.Write("Names :");
                foreach (var names in binder.CallInfo.ArgumentNames)
                {
                    Console.Write(names + ", ");
                }
                Console.WriteLine();
                Console.Write("Values :");
                foreach (var item in args)
                {
                    Console.Write(item + " : " + item.GetType() +   ", ");
                }
                Console.WriteLine();
                result = null;
                return true;
            }
        }

    }
}