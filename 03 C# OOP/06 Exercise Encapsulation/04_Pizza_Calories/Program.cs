namespace _04_Pizza_Calories
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string[] arrInput;
            Pizza pizza = null;
            Dough dough = null;
            Topping topping = null;

            while((arrInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries))[0] != "END"){
                try{
                    if(arrInput[0] == "Pizza"){
                        if(arrInput.Length > 1){
                            pizza = new Pizza(arrInput[1]);
                        }
                        else{
                            pizza = new Pizza("");
                        }
                    }
                    if(arrInput[0] == "Dough"){
                        dough = new Dough(arrInput[1], arrInput[2], double.Parse(arrInput[3]));
                        pizza.Dough = dough;
                        //Console.ForegroundColor = ConsoleColor.Blue;
                        //Console.WriteLine(dough.ToString());
                        //Console.ResetColor();
                    }
                    else if(arrInput[0] == "Topping"){
                        topping = new Topping(arrInput[1], double.Parse(arrInput[2]));
                        pizza.AddTopping(topping);
                        //Console.ForegroundColor = ConsoleColor.Blue;
                        //Console.WriteLine(topping.ToString());
                        //Console.ResetColor();
                    }
                }
                catch(Exception e){
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(e.Message);
                    Console.ResetColor();
                    return;
                }
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(pizza.ToString());
            Console.ResetColor();

        }
    }
}
