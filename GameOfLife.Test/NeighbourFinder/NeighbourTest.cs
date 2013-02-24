using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit;
using NUnit.Framework;

using Rhino;
using Rhino.Mocks;
using GameOfLife.NeighbourFinder;
using GameOfLife.Model;

namespace GameOfLife.Test.NeighbourFinder
{
    [TestFixture]
    public class NeighbourTest
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NeighbourConstructorNullMatrixTest( )
        {
            // Act
            Neighbour neighbour = new Neighbour(null,null,null);
        
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyNeighbourConstructorNullSearcherTest()
        {
            // Act
            Neighbour neighbourSecondParamTest = new Neighbour(new Matrix(new Dimension { ColumnCount = 2, RowCount = 2 }), null, null);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void EmptyNeighbourConstructorNullSearchPatternTest()
        {
            // Act
            Neighbour neighbourThirdParamTest = new Neighbour(new Matrix(new Dimension { RowCount = 2, ColumnCount = 2 }), new Search(), null);
        }

        /// <summary>
        /// Test Case for the Metrics when its bounds ar 3-3.
        /// All elements in row 2 are alive.
        /// </summary>
        /// <param name="selectedRow"></param>
        /// <param name="selectedColumn"></param>
        /// <param name="expectedResult"></param>
        [TestCase(1, 1, 3)]
        [TestCase(0, 1, 0)]
        [TestCase(1, 0, 2)]
        [TestCase(1, 2, 2)]
        [TestCase(0, 0, 0)]
        public void GetAliveNeighbourCountSelectionSecondRowAllColumns(short selectedRow, short selectedColumn, short expectedResult)
        { 
            // Arrange 
            Matrix matrix = new Matrix(new Dimension { ColumnCount = 3, RowCount = 3 });

            matrix[2, 0].SetAlive = true;
            matrix[2, 1].SetAlive = true;
            matrix[2, 2].SetAlive = true;
            ISearcher search = new Search();

            Neighbour neighbour = new Neighbour(matrix, search, SearchPatern());
            short aliveNeighBour = neighbour.GetLiveNeighboursCount(matrix[selectedRow, selectedColumn]);
            // Act

            // Assert
            Assert.AreEqual(expectedResult, aliveNeighBour);
           // matrix.s
        }

        [TestCase(0, 1, 3)]
        [TestCase(0, 0, 2)]
        [TestCase(2, 0, 2)]
        [TestCase(2, 1, 3)]
        [TestCase(0, 0, 2)]
        public void GetAliveNeighbourCountSelectionFirstRowAllColumns(short selectedRow, short selectedColumn, short expectedResult)
        {
            // Arrange 
            Matrix matrix = new Matrix(new Dimension { ColumnCount = 3, RowCount = 3 });

            matrix[1, 0].SetAlive = true;
            matrix[1, 1].SetAlive = true;
            matrix[1, 2].SetAlive = true;
            ISearcher search = new Search();

            Neighbour neighbour = new Neighbour(matrix, search, SearchPatern());
            short aliveNeighBour = neighbour.GetLiveNeighboursCount(matrix[selectedRow, selectedColumn]);
            // Act

            // Assert
            Assert.AreEqual(expectedResult, aliveNeighBour);
            // matrix.s
        }

        private ISearchPattern SearchPatern()
        {
            ISearchPattern searchPattern = new SearchPattern();

            List<SearchCoordinate> coodinates = new List<SearchCoordinate>();

            coodinates.Add(new SearchCoordinate { Y = -1 }); // Up Search
            coodinates.Add(new SearchCoordinate { Y = 1 }); // Down Search
            coodinates.Add(new SearchCoordinate { X = -1 }); // Left Search
            coodinates.Add(new SearchCoordinate { X = 1 }); // Right Search
            coodinates.Add(new SearchCoordinate { Y = 1, X = -1 }); // Diagonal Down left Search
            coodinates.Add(new SearchCoordinate { Y = 1, X = 1 }); //  Diagonal Down left right
            coodinates.Add(new SearchCoordinate { Y = -1, X = 1 }); //  Diagonal up 
            coodinates.Add(new SearchCoordinate { Y = -1, X = -1 }); //  Diagonal up 

            searchPattern.SearchCoordinates = coodinates;
            return searchPattern;

        }

    }
}
