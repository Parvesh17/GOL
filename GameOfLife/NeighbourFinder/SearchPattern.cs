using GameOfLife.NeighbourFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.NeighbourFinder
{
    /// <summary>
    /// Interface for Search Pattern.
    /// </summary>
    public class SearchPattern : ISearchPattern
    {
        /// <summary>
        /// List of all coordinates to search.
        /// </summary>
        public IEnumerable<Model.SearchCoordinate> SearchCoordinates { get; set; }
    }
}
