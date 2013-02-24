using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.NeighbourFinder
{
    /// <summary>
    /// Interface for Search Pattern.
    /// </summary>
    public interface ISearchPattern
    {
        /// <summary>
        /// List of all coordinates to search.
        /// </summary>
        IEnumerable<SearchCoordinate> SearchCoordinates { get; set; }
    }
}
