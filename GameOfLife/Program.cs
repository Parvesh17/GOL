using GameOfLife.Model;
using GameOfLife.NeighbourFinder;
using GameOfLife.RuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program
    {
        private static Matrix matrix;
        static void Main(string[] args)
        {
            /************************************************************************
             * Solution written in VS 2012.
             * 
             * Rule followed.
             * Element (displayed as " X " on screen) is born when it has 3 neighbours alive.
             * Element (displayed as " X " on screen) lives when it has 2 0r 3 neighbours alive.
             * Element (displayed as "---" on screen) is dead when element has less than 3 or greater than 4 neighbours alive.
             * 
             *  
             * Limitations.
             * Not implemented: Recursive probing of neighbours when element state gets changed.
             * 
             * Unit Testing
             * Nunit lib have been used.
             * Rhino mock lib used.
             * 
             * Futher improvement.
             * Using Multithreading.
             * Ioc framework.
             * Recursive Probing of neighbours elements.
             * More unit test coverage.
             * 
             *********************************************************************************/

            matrix = new Matrix(new Dimension { ColumnCount = 8, RowCount = 8 });
            Information();
            GetInputSetAlive();

           IGameOfLifeProcessor game = CreateGameOfLifeProcessor(matrix);

            StringBuilder sb = new StringBuilder();
            for (int intRow = 0; intRow < matrix.dimension.RowCount; intRow++)
            {
                for (int iCol = 0; iCol < matrix.dimension.ColumnCount; iCol++)
                {
                    if (game.IsElementAlive(matrix[intRow, iCol]))
                    {
                        sb.Append(" X ");
                    }
                    else
                    {
                        sb.Append(" - ");
                    }
                }
                sb.AppendLine();
            }
            Console.WriteLine();
            Console.WriteLine(sb.ToString());
            Console.ReadLine();
        }

        private static void Information()
        {
            
            Console.WriteLine("Please specify the cells that needs to be set alive\n");
            Console.WriteLine("Please note, row number and column number starts with 0 \n");
            Console.WriteLine(@"Format <row, col>|<row, col> example: 2,3|4,5 ");
         
            Console.WriteLine();
        }

        private static void GetInputSetAlive()
        {
            string userSelection  = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userSelection))
            {
                throw new ArgumentException("InValid user entry.");
            }

            string[] elementString = userSelection.Split('|');

            for (int i = 0; i < elementString.Length; i++)
            {
                string[] splitElement = elementString[i].Split(',');
                if (splitElement.Length != 2)
                {
                    splitElement.Length.ValidateElementForNull("InValid user entry.");           
                }
                int rownum;
                int colnum;
                if (!Int32.TryParse(splitElement[0], out rownum))
                {
                    throw new Exception("InValid user entry.");
                }
                if (!Int32.TryParse(splitElement[1], out colnum))
                {
                    throw new Exception("InValid user entry.");
                }
                matrix[rownum, colnum].SetAlive = true;
                
            }
            
        }

        private static IGameOfLifeProcessor CreateGameOfLifeProcessor(Matrix matrix)
        {
            INeighbourFinder neighBourFinder = new Neighbour(matrix, new Search(), new SearchPattern { SearchCoordinates = SearchPattern() });
            IRuleEngineFactory ruleEngineFactory = new RuleEngineFactory();

            return new GameOfLifeProcessor(neighBourFinder, ruleEngineFactory);
        }

        private static IEnumerable<SearchCoordinate> SearchPattern()
        {
            List<SearchCoordinate> coodinates = new List<SearchCoordinate>();

            coodinates.Add(new SearchCoordinate { Y = -1 }); // Up Search
            coodinates.Add(new SearchCoordinate { Y = 1 }); // Down Search
            coodinates.Add(new SearchCoordinate { X = -1 }); // Left Search
            coodinates.Add(new SearchCoordinate { X = 1 }); // Right Search
            coodinates.Add(new SearchCoordinate { Y = 1, X = -1 }); // Diagonal Down left Search
            coodinates.Add(new SearchCoordinate { Y = 1, X = 1 }); //  Diagonal Down left right
            coodinates.Add(new SearchCoordinate { Y = -1, X = 1 }); //  Diagonal up 
            coodinates.Add(new SearchCoordinate { Y = -1, X = -1 }); //  Diagonal up 

            return coodinates;

        }
    }
}
