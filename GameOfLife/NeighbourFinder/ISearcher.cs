using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.NeighbourFinder
{
    /// <summary>
    /// Interface for searcher validation process.
    /// </summary>
    public interface ISearcher
    {
        bool IsNeighbourAlive(Matrix matrix, Element element);
    }
}
