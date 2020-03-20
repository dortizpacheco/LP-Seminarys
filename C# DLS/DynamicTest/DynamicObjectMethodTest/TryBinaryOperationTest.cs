using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;
using System;

namespace DynamicTest
{
    public class TryBinaryOperationTest
    {
        public static void RunTest()
        {
            dynamic @dynamic = new DynamicTest(){Value = 4, Text = "Four"};
            var @dynamic2 = new DynamicTest(){Value = 2, Text = "Two"};

            //Note que basta con que uno este marcado con dynamic para que se realice un enlaca tardio 
            Console.WriteLine("------------------Marcando el primero como dynamic-----------------");
            var res = @dynamic + @dynamic2;
            Console.WriteLine($" + : {res.Value}  , {res.Text}");
            res = @dynamic - @dynamic2;
            Console.WriteLine($"-  : {res.Value}  , {res.Text}");
            res = @dynamic * @dynamic2;
            Console.WriteLine($" * : {res.Value}  , {res.Text}");
            res = @dynamic / @dynamic2;
            Console.WriteLine($" / : {res.Value}  , {res.Text}");
            res = @dynamic & @dynamic2;
            Console.WriteLine($" & : {res.Value}  , {res.Text}");
            res = @dynamic | @dynamic2;
            Console.WriteLine($" | : {res.Value}  , {res.Text}");

            var @dynamic1 = new DynamicTest(){Value = 4, Text = "Four"};
            dynamic @dynamic3 = new DynamicTest(){Value = 2, Text = "Two"};

            Console.WriteLine("------------------Marcando el segundo como dynamic-----------------");
            res = @dynamic1 + @dynamic3;
            Console.WriteLine($" + : {res.Value}  , {res.Text}");
            res = @dynamic1 - @dynamic3;
            Console.WriteLine($"-  : {res.Value}  , {res.Text}");
            res = @dynamic1 * @dynamic3;
            Console.WriteLine($" * : {res.Value}  , {res.Text}");
            res = @dynamic1 / @dynamic3;
            Console.WriteLine($" / : {res.Value}  , {res.Text}");
            res = @dynamic1 & @dynamic3;
            Console.WriteLine($" & : {res.Value}  , {res.Text}");
            res = @dynamic1 | @dynamic3;
            Console.WriteLine($" | : {res.Value}  , {res.Text}");

        }

        class DynamicTest : DynamicObject
        {
            public  int Value {get;set;}
            public string Text {get;set;}
            public override bool TryBinaryOperation(BinaryOperationBinder binder, object arg, out object result)
            {
                result = new DynamicTest();
                ConstantExpression left = Expression.Constant(this.Value);
                ConstantExpression right = Expression.Constant(((DynamicTest)arg).Value); 
                BinaryExpression exp = Expression.MakeBinary(binder.Operation,left,right);
                Expression<Func<int>> lam = Expression.Lambda<Func<int>>(exp);
                Func<int> fun = lam.Compile();
                ((DynamicTest)result).Value = fun();


                //forma inicial e intuitiva de implementar este metodo
                //ademas no encontre rapido como trabajar el arbol para string de forma generica
                switch(binder.Operation)
                {
                    case ExpressionType.Add:
                        ((DynamicTest)result).Text = this.Text + "+" + ((DynamicTest)arg).Text;
                        break;
                    case ExpressionType.Subtract:
                        ((DynamicTest)result).Text = this.Text + "-" + ((DynamicTest)arg).Text;
                        break;
                    case ExpressionType.Multiply:
                        ((DynamicTest)result).Text = this.Text + "*" + ((DynamicTest)arg).Text;
                        break;
                    case ExpressionType.Divide:
                        ((DynamicTest)result).Text = this.Text + "/" + ((DynamicTest)arg).Text;
                        break;     
                    default:
                        ((DynamicTest)result).Text = "operation isn't defined for string";
                        break;
                }   
                return true;
            }
        }
    }
}