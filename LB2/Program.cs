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
    
    static void task2()
    {
        double[] x_ = { 2, 10, -10 };
        foreach (double x in x_)
        {
            double y = Math.Pow(2, x);
            double sum = 1;
            double term = Math.Log(2) * x;
            int i = 1;

            while (Math.Abs(term) >= 1e-6)
            {
                sum += term;
                i++;
                term *= (x * Math.Log(2)) / i;
            }

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

    static int hint(int health, int wight, int answer)
    {
        char hint_;

        Console.WriteLine("Want a hint(1 damage)?(y/n)");
        hint_ = char.Parse(Console.ReadLine());
        if (hint_ == 'y')
        {
            health--;
            if (wight > answer)
                Console.WriteLine("num > answer");
            if (wight < answer)
                Console.WriteLine("num < answer");
        }

        return health;
    }

    static int geussMyNumber(int xMax, int round, int hp)
    {
        var random = new Random();
        int points = 0;
        int health;
        int answer;
        bool correctAnswer;
        for (int i = 1; i <= round; i++)
        {
            health = hp;
            int wight = random.Next(0, xMax);
            correctAnswer = false;
            Console.WriteLine($"Guess a number between 1 and 10. Round {i}");
            while (correctAnswer == false)
            {
                Console.Write("Enter number: ");
                answer = Convert.ToInt32(Console.ReadLine());
                if (answer == wight)
                {
                    correctAnswer = true;
                    points += health * 5;
                    Console.WriteLine($"You won. With {points} points.");
                }
                else
                {
                    health -= 1;
                    correctAnswer = checkHealth(health);
                    Console.WriteLine($"Wrong answer. Your health is {health}");
                    if (health > 1)
                        health = hint(health, wight, answer);
                    else
                        Console.WriteLine("You can't use the hint, your health level is too low");
                }
            }
        }

        return points;
    }

    static void task3()
    {
        Console.WriteLine("Guess a number, lvl 1.");
        int points = geussMyNumber(10, 3, 5);
        Console.WriteLine($"Your points is {points}. Lvl 2 in 5 seconds");
        Thread.Sleep(5000);
        if (points >= 1)
        {
            Console.Clear();
            Console.WriteLine("Guess a number, lvl 2.");
            points += geussMyNumber(100, 2, 25);
            Console.WriteLine($"You win with {points} points.");
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
        //task2();
        task3();
        Console.ReadKey();
    }
}