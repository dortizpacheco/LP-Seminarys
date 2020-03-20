using System;
using System.Reflection;
using System.Collections.Generic;
using TestClass;
using CShap35;
using CShap40;
using System.Text;
using ReflectionTest;
using DynamicTest;
using System.Dynamic;

namespace CShapDLS
{
    class Program
    {
        static void Main(string[] args)
        {
            DefaultConfigAnalize.RunTest();

        }
        class A : DynamicObject
        {
            public override bool TryGetMember(GetMemberBinder binder, out object result)
            {
                result = new B();
                return true;
            }
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                Console.WriteLine("Me Fuiiiiiii");
                result = null;
                return true;
            }

        }
        class B: DynamicObject
        {
            public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
            {
                for (int i = 0; i < binder.CallInfo.ArgumentCount; i++)
                {
                    Console.WriteLine($"{binder.CallInfo.ArgumentNames[i]} : {args[i]} : {args[i].GetType()}");
                }

                result = null;
                return true;
            }
        }

    }
}