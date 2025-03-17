using System.Numerics;
using System.Security;

namespace LB2;

class Program
{
    static void task1()
    {
        double xmin = 0;
        double xmax = 3;
        double dx = 0.1;
        double a = 0.5;
        double da = 0.25;
        double x = 0;
        double y;
        double denomerator, numerator;

        for (double i = 0; i < xmax; i += dx)
        {
            denomerator = Math.Atan(x / (2 * a));
            numerator = Math.Pow(x, 2) + 2 * a;
            if (Math.Abs(numerator) > 0)
            {
                y = denomerator / numerator;
                Console.WriteLine(y);
            }
            else
                Console.WriteLine("numerator = 0");

            x += dx;
            a += da;
        }
    }

    static double factorial(int n)
    {
        if (n == 0 || n == 1) return 1;
        double result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    static void suma()
    {
        double[] x_ = { 2, 10, -10 };
        foreach (double x in x_)
        {
            double y = Math.Pow(2, x);
            double sum = 1;
            double term;
            int i = 1;

            do
            {
                term = (Math.Pow(x, i) * Math.Pow(Math.Log(2), i)) / factorial(i);
                sum += term;
                i++;
            } while (Math.Abs(term) >= 1e-6);

            Console.WriteLine($"x = {x}, S(x) = {sum}, y(x) = {y}");
        }
    }

    static bool checkHealth(int hp)
    {
        if (hp <= 0)
        {
            Console.WriteLine("You lose");
            return true;
        }

        return false;
    }

    static int geussMyNumber(int xMax, int round)
    {
        var random = new Random();
        int damage = 1;
        int points = 0;
        int health;
        bool correctAnswer;
        for (int i = 1; i <= round; i++)
        {
            if (round <= 3) health = 5;
            else health = 25;
            int wight = random.Next(0,xMax);
            int answer;
            char hint;
            correctAnswer = false;
            Console.WriteLine($"Guess a number between 1 and 10. Round {i}");
            do
            {
                Console.Write("Enter number: ");
                answer = Convert.ToInt32(Console.ReadLine());
                if (answer != wight)
                {
                    health -= damage;
                    correctAnswer = checkHealth(health);
                    Console.WriteLine($"Wrong answer. Your health is {health}");
                    if (health > 1)
                    {
                        Console.WriteLine("Want a hint(1 damage)?(y/n)");
                        hint = char.Parse(Console.ReadLine());
                        if (hint == 'y')
                        {
                            health -= damage;
                            if (wight > answer)
                                Console.WriteLine("num > answer");
                            if (wight < answer)
                                Console.WriteLine("num < answer");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You can't use the hint, your health level is too low");
                    }
                }

                if (answer == wight)
                {
                    correctAnswer = true;
                    Console.WriteLine("You won.");
                    points += health * 5;
                    Console.Write($"With {points} points.");
                }
                
            } while (correctAnswer == false);

            
        }

        if (points > 1)
        {
            Console.WriteLine($"You won in game, with {points} points.");
            return 1;
        }
        else
        {
            Console.WriteLine("You lose");
            return 0;
        }
    }

    static void task3()
    {
        Console.WriteLine("Guess a number, lvl 1.");
        int nextLvl = geussMyNumber(10,3);
        if (nextLvl == 1)
        {
            Console.Clear();
            Console.WriteLine("Guess a number, lvl 2.");
            geussMyNumber(100, 2);
        }
        else
        {
            Console.Clear();
            Console.WriteLine("You cant play lvl 2.");
        }
    }
    static void Main(string[] args)
    {
        //task1();
        //suma();
        task3();
        Console.ReadKey();
    }
}