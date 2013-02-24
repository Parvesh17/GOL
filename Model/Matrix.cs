using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model
{
    public class Matrix
    {
        Element[][] element;
        public Dimension dimension { get; private set; }

        public Matrix(Dimension dimension)
        {
            // Validate 
            dimension.RowCount.ValidateGreaterThenZero("Dimension's are not set.");
            dimension.ColumnCount.ValidateGreaterThenZero("Dimension's are not set.");
            this.dimension = dimension;
            BuildMatrix();
       }


        //Returns the element on the position.
        public Element this[int rowIndex, int columnIndex]
        {
            get
            {
                return this.element[rowIndex][columnIndex];
            }
        }

        public MatrixEnum GetEnumerator()
        {
            return new MatrixEnum(this);
        }

        private void BuildMatrix()
        {
            this.element = new Element[this.dimension.RowCount][];
            for (int iRow = 0; iRow < this.dimension.RowCount; iRow++)
            {
                this.element[iRow] = new Element[this.dimension.ColumnCount];

                for (int iCol = 0; iCol < this.dimension.ColumnCount; iCol++)
                {
                    this.element[iRow][iCol] = new Element(iRow, iCol);
                }
            }
        }
    }
}
