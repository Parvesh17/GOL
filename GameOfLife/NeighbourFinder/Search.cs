using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.NeighbourFinder
{
    /// <summary>
    /// This class is responsible for searching.
    /// </summary>
    public class Search : ISearcher
    {
        /// <summary>
        /// This method conatins the logic to identify alive status.
        /// </summary>
        /// <param name="matrix">The matrix contains all rows.</param>
        /// <param name="element">Selected element.</param>
        /// <returns>Verifies that element is alive.</returns>
       public bool IsNeighbourAlive(Matrix matrix, Element element)
        {
            return matrix[element.RowIndex, element.ColumnIndex].IsAlive;
        }
    }
}
