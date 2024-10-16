using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{

    public interface IWorker
    {
        void Work();
    }

    public interface IPart
    {
        string GetName();
    }



    public class House
    {
        public Basement Basement { get; set; }
        public Walls Walls { get; set; }
        public Door Door { get; set; }
        public Window[] Windows { get; set; }
        public Roof Roof { get; set; }

        public void Build()
        {
            Console.WriteLine("House building started");
            Basement.Build();
            Walls.Build();
            Door.Build();
            foreach (Window window in Windows)
            {
                window.Build();
            }
            Roof.Build();
            Console.WriteLine("House building completed");
        }
    }

    public class Basement : IPart
    {
        public string GetName() => "Basement";
        public void Build()
        {
            Console.WriteLine("Building basement");
        }
    }

    public class Walls : IPart
    {
        public string GetName() => "Walls";
        public void Build()
        {
            Console.WriteLine("Building walls");
        }
    }

    public class Door : IPart
    {
        public string GetName() => "Door";
        public void Build()
        {
            Console.WriteLine("Building door");
        }
    }

    public class Window : IPart
    {
        public string GetName() => "Window";
        public void Build()
        {
            Console.WriteLine("Building window");
        }
    }

    public class Roof : IPart
    {
        public string GetName() => "Roof";
        public void Build()
        {
            Console.WriteLine("Building roof");
        }
    }

    public class Team
    {
        public Worker[] Workers { get; set; }
        public TeamLeader TeamLeader { get; set; }

        public void StartBuilding()
        {
            foreach (Worker worker in Workers)
            {
                worker.Work();
            }
        }
    }

    public class Worker : IWorker
    {
        public void Work()
        {
            
            Console.WriteLine("Worker is working");
        }
    }

    public class TeamLeader : IWorker
    {
        public void Work()
        {
 
            Console.WriteLine("Team leader is generating report");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
   
            Basement basement = new Basement();
            Walls walls = new Walls();
            Door door = new Door();
            Window[] windows = new Window[4];
            for (int i = 0; i < 4; i++)
            {
                windows[i] = new Window();
            }
            Roof roof = new Roof();


            House house = new House
            {
                Basement = basement,
                Walls = walls,
                Door = door,
                Windows = windows,
                Roof = roof
            };


            Worker[] workers = new Worker[5];
            for (int i = 0; i < 5; i++)
            {
                workers[i] = new Worker();
            }
            TeamLeader teamLeader = new TeamLeader();
            Team team = new Team
            {
                Workers = workers,
                TeamLeader = teamLeader
            };

            team.StartBuilding();
            Console.WriteLine("House built:");
            Console.WriteLine("  Basement: " + basement.GetName());
            Console.WriteLine("  Walls: " + walls.GetName());
            Console.WriteLine("  Door: " + door.GetName());
            Console.WriteLine("  Windows: " + string.Join(", ", windows.Select(w => w.GetName())));
            Console.WriteLine("  Roof: " + roof.GetName());
        }
    }
}