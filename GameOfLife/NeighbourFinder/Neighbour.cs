using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.NeighbourFinder
{
    /// <summary>
    /// Class responsible for searching neighbours.
    /// The class evaluate the neighbours on the basis of a search pattern.
    /// </summary>
    public class Neighbour : INeighbourFinder
    {
        private Matrix matrix;
        private ISearcher searcher;
        private ISearchPattern searchPattern;

        /// <summary>
        /// Neighbour class contructor.
        /// Class external dependency are resolved via DI.
        /// </summary>
        /// <param name="matrix">The populated matrix.</param>
        /// <param name="searcher">The searcher class.</param>
        /// <param name="searchPattern">The search pattern algorithm.</param>
        public Neighbour(Matrix matrix, ISearcher searcher, ISearchPattern searchPattern)
        {
            matrix.ValidateElementForNull("Matrix is null.");
            searcher.ValidateElementForNull("Searcher is null.");
            searchPattern.ValidateElementForNull("Search Pattern is null.");

            this.matrix = matrix;
            this.searcher = searcher;
            this.searchPattern = searchPattern;
        }

        public short GetLiveNeighboursCount(Element element)
        {
            element.ValidateElementForNull("Element passed is null.");
            short aliveNeighbourCount = 0;

            try
            {
                Element selectedelement = this.matrix[element.RowIndex, element.ColumnIndex];
                Element neighbour;

                if (selectedelement != null)
                {
                    foreach (SearchCoordinate coordinate in this.searchPattern.SearchCoordinates)
                    {
                        bool applyYCoordinate = true;
                        bool applyXCoordinate = true;

                        if ((element.RowIndex == 0 && coordinate.Y == -1) || (element.RowIndex == this.matrix.dimension.RowCount - 1 && coordinate.Y == 1))
                        {
                            applyYCoordinate = false;
                        }

                        if ((element.ColumnIndex == 0 && coordinate.X == -1) || (element.ColumnIndex == this.matrix.dimension.ColumnCount - 1 && coordinate.X == 1))
                        {
                            applyXCoordinate = false;
                        }

                        if (applyYCoordinate && applyXCoordinate)
                        {
                            neighbour = this.matrix[element.RowIndex + coordinate.Y, element.ColumnIndex + coordinate.X ];

                            if (searcher.IsNeighbourAlive(this.matrix, neighbour))
                            {
                                aliveNeighbourCount++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Actual exception will be handled here. 
                // Logging task can be added.
                throw ex;
            }

            return aliveNeighbourCount;
        }
     
    }
}
