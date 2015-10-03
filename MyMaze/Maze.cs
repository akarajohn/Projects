using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMaze
{


    class Maze
    {
        int width , height;
        string _width, _height;
        int StartX, StartY, EndX, EndY;
        int[,] MyTable;
        bool[,] Visited;
        Random r;
        Queue<Path> correctPath = new Queue<Path>();

        public void DefineDemensions()
        { 
            Console.Write("Choose the maze's width(min value 2 , max value 100):");
            _width = Console.ReadLine();
            Console.Write("Choose the maze's height(min value 2 , max value 100):");
            _height = Console.ReadLine();
        }
        public void Initialize()
        {
            //Validate input value
            do 
            {
                DefineDemensions();
            } while (!int.TryParse(_width, out width) || !int.TryParse(_height, out height) || width < 2 || width >100 || height < 2 || height > 100 );

                MyTable = new int[width, height];
                Visited = new bool[width, height];
            
            r = new Random();

            //Random coordinates for Start and Goal
                while (StartX == EndX || StartY == EndY)
                {
                    StartX = r.Next(0, width);
                    StartY = r.Next(0, height);
                    EndX = r.Next(0, width);
                    EndY = r.Next(0, height);
                }
        }
        //1 for walls, 0 for doors
        public int[,] Create() 
        {
            int i = 0;
            
            for (int z = 0; z < width; z++)
            {
                for (int j = 0; j < height; j++)
                {
                    MyTable.SetValue(0, z, j);
                }
            }
            //Random number of walls
            int NumberOfWalls = r.Next(width / 2, width); 

            while(i <= NumberOfWalls){
                int x = r.Next(0,width);
                int y = r.Next(0,height);
                MyTable.SetValue(1, x, y);
                i++;
            }

            MyTable.SetValue(0, StartX, StartY);
            MyTable.SetValue(0, EndX, EndY);

            return MyTable;
        }

            public void Solve()
            {
                MyTable = Create();
                for(int p=0;p< width ;p++)
                {
                    for(int j=0;j < height;j++)
                    {
                        Visited[p,j] = false;
                    }  
                }
                
                bool b = RecursiveSolve(StartX,StartY);
            }

        public bool RecursiveSolve(int x ,int y)
        {
            int flag = 0;
            if (x == StartX && y == StartY && flag==0)
            {
                // Check if it's start
                Path path = new Path { XPoint = x, YPoint = y }; 
                correctPath.Enqueue(path);
                flag++;
                return true;
            }
            //If it's wall or you were here
            if (MyTable[x, y] == 1 || Visited[x, y]) 
                return false;
                Visited[x,y] =true;
                //Checks if not on left edge
            if(x!=0) 
            {
                if(RecursiveSolve(x-1 , y)){
                    Path path = new Path { XPoint = x, YPoint = y };
                    correctPath.Enqueue(path);

                return true;}
            }
            //Checks if not on right edge
            if(x!=width-1) 
            {
                if(RecursiveSolve(x+1,y)){
                    Path path = new Path { XPoint = x, YPoint = y };
                    correctPath.Enqueue(path);
                return true;}
            }
            //Checks if not on top edge
            if(y!=0) 
            {
                if(RecursiveSolve(x,y-1)){
                    Path path = new Path { XPoint = x, YPoint = y };
                    correctPath.Enqueue(path);
                return true;}
            }
            //Checks if not on bottom edge
            if(y!=height-1) 
            {
                if(RecursiveSolve(x,y+1)){
                    Path path = new Path { XPoint = x, YPoint = y };
                    correctPath.Enqueue(path);
                return true;}
            }
            //If you reached the end
            if (x == EndX && y == EndY) 
            {
                Path path = new Path { XPoint = x, YPoint = y };
                correctPath.Enqueue(path);
                return true;
            }
            return false;
        }

        public void Print()
        {
            if (RecursiveSolve(EndX, EndY) == true)
            {
                Console.WriteLine("The path you should follow is: ");

                Path ordertoProcess = correctPath.Dequeue();
                ordertoProcess.Process();

                foreach (var path in correctPath)
                {
                    Console.WriteLine(path.ShowIt());
                }

                Console.WriteLine("\nMaze is solved!");
            }
            else Console.WriteLine("Maze cannot be solved.");
        }                        
        }
    }

