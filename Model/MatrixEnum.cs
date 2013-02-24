using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model
{
    public class MatrixEnum : IEnumerator<Element>
    {
        int rowPosition = 0;
        int colPosition = 0;

        private Matrix matrix;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="matrix"></param>
        public MatrixEnum(Matrix matrix)
        {
            this.matrix = matrix;
        }


        /// <summary>
        /// Gets current element.
        /// </summary>
        public Element Current
        {
            get
            {
                try
                {
                    return this.matrix[rowPosition, colPosition];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        object System.Collections.IEnumerator.Current
        {
            get { return Current; }
        }

        public bool MoveNext()
        {
            bool retval;
            if (rowPosition >= matrix.dimension.RowCount - 1 && colPosition >= matrix.dimension.ColumnCount - 1)
            {
                retval = false;
            }
            else
            {
                colPosition++;
                if (colPosition == matrix.dimension.ColumnCount)
                {
                    colPosition++;
                    colPosition = 0;
                }
                retval = true;
            }
            return retval;
        }

        public void Reset()
        {
            rowPosition = 0;
        }
    }
}
