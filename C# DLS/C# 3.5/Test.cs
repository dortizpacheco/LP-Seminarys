using TestClass;

namespace CShap35
{
    static class Test
    {
        static public void Run()
        {
            var p1 = Factory.New.Person;
            p1.FirstName = "Alexander";
            p1.LastName = "ProfeDeLP";
            p1.Print("Normal");

            var p2 = Factory.New.Person(
                        FirstName: "Alexander",
                        LastName: "EstaALBerro",
                        Manager: Factory.New.Person(
                                    FirstName: "Tito",
                                    LastName: "ElTizaPorSIEstaMirando"
                                )
                        );
            p2.Print("Json Style en C#");
            

            var p3 = Factory.New.Person
                        .FirstName("Alexander")
                        .LastName("NoTeMetasEnELSeminario");
            p3.Print("Fluent Interface");

            var p4 = Factory.New.Person;
            p4["FirstName"] = "Alexander";
            p4["LastName"] = "VuelveAHablarPaQueVeas";
            p4.Print("Dictionary Style");
        }
    }
}