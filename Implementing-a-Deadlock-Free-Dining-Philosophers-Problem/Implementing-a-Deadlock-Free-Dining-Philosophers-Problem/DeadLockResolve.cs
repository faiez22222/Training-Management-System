using System;
using System.Threading;

class DiningPhilosophers
{
    private readonly object[] forks = new object[5];

    public DiningPhilosophers()
    {
        for (int i = 0; i < forks.Length; i++)
        {
            forks[i] = new object();
        }
    }

    public void Philosopher(int id)
    {
        int leftFork = id;
        int rightFork = (id + 1) % 5;

        while (true)
        {
            Console.WriteLine($"Philosopher {id} is thinking.");
            Thread.Sleep(new Random().Next(100, 1000)); // Thinking

            if (id % 2 == 0)
            {
                // Even philosophers pick up left fork first
                lock (forks[leftFork])
                {
                    Console.WriteLine($"Philosopher {id} picked up left fork {leftFork}.");
                    Thread.Sleep(100); // Simulate time to pick up fork

                    lock (forks[rightFork])
                    {
                        Console.WriteLine($"Philosopher {id} picked up right fork {rightFork} and is eating.");
                        Thread.Sleep(new Random().Next(100, 1000)); // Eating
                    }

                    Console.WriteLine($"Philosopher {id} put down right fork {rightFork}.");
                }

                Console.WriteLine($"Philosopher {id} put down left fork {leftFork}.");
            }
            else
            {
                // Odd philosophers pick up right fork first
                lock (forks[rightFork])
                {
                    Console.WriteLine($"Philosopher {id} picked up right fork {rightFork}.");
                    Thread.Sleep(100); // Simulate time to pick up fork

                    lock (forks[leftFork])
                    {
                        Console.WriteLine($"Philosopher {id} picked up left fork {leftFork} and is eating.");
                        Thread.Sleep(new Random().Next(100, 1000)); // Eating
                    }

                    Console.WriteLine($"Philosopher {id} put down left fork {leftFork}.");
                }

                Console.WriteLine($"Philosopher {id} put down right fork {rightFork}.");
            }
        }
    }

    public static void Main(string[] args)
    {
        DiningPhilosophers diningPhilosophers = new DiningPhilosophers();

        Thread[] philosophers = new Thread[5];
        for (int i = 0; i < 5; i++)
        {
            int id = i;
            philosophers[i] = new Thread(() => diningPhilosophers.Philosopher(id));
            philosophers[i].Start();
        }

        foreach (var philosopher in philosophers)
        {
            philosopher.Join();
        }
    }
}
