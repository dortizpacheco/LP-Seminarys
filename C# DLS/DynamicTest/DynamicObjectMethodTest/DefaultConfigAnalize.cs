using System;
using System.Dynamic;

namespace DynamicTest
{
    public class DefaultConfigAnalize
    {
        public static void RunTest()
        {
            Console.WriteLine("----------if A do override TryGetMember and TryInvokeMember && B do override TryInvoke------------ ");
            dynamic a = new A();
            Console.Write("a.Property() -->");
            a.Property();
            Console.WriteLine("End");
            Console.WriteLine("----------if C do override TryGetMember && B do override TryInvoke------------ ");
            dynamic c = new C();
            Console.Write("c.Property() -->");
            c.Property();
            Console.WriteLine("End");
            Console.WriteLine("----------if B do override TryInvoke------------ ");
            dynamic b = new B();
            Console.Write("b.Property() -->");
            b.Property();
            Console.WriteLine("End");

        }
    }
    class A : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Console.Write("A.TryGetMember --> ");
            result = new  B();
            return true;
        }
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            Console.Write("A.TryInvokeMember --> ");
            result = new B();
            return true;
        }
    }
    class B : DynamicObject
    {
        public override bool TryInvoke(InvokeBinder binder, object[] args, out object result)
        {
            Console.Write("B.TryInvoke --> ");
            result = null;
            return true;
        }
    }
    class C : DynamicObject
    {
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            Console.Write("C.TryGetMember --> ");
            result = new B();
            return true;
        }
    }
}