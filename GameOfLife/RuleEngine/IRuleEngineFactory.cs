using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.RuleEngine
{
    /// <summary>
    /// Interface for RuleEngineFactory class.
    /// </summary>
    public interface IRuleEngineFactory
    {
        /// <summary>
        /// Method responsible for creating a applicable rule instance.
        /// </summary>
        /// <param name="aliveNeighbours">Count of alive neighbours.</param>
        /// <param name="currentState">Current state of the cell.</param>
        /// <returns>RuleEngine instance.</returns>
        IRuleEngine GetApplicabaleRule(short aliveNeighbours, bool currentState);
    }
}
