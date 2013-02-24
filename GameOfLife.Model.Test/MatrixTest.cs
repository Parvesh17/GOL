using System;
using NUnit.Framework;

namespace GameOfLife.Model.Test
{
    [TestFixture]
    public class MatrixTest
    {
        [TestCase(2, 2)]
        [TestCase(6, 6)]
        [TestCase(10, 8)]
        public void MatrixDimensionTest(int rows, int columns)
        {
            // Act
            Matrix matrix = new Matrix(new Dimension { RowCount = rows, ColumnCount = columns });
            
            // Arrange
            Element element = matrix[rows -1, columns -1];           

            // Assert
            Assert.That(element.RowIndex == rows -1 );
            Assert.That(element.ColumnIndex == columns -1);
        }
    }
}
