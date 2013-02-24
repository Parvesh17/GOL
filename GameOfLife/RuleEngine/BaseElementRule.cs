using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife.RuleEngine
{
    /// <summary>
    /// Abstract class for the Game of life rules.
    /// </summary>
    public abstract class BaseElementRule
    {
        protected short aliveNeighbours;
        protected bool currentState;

        /// <summary>
        /// Base constructor.
        /// </summary>
        /// <param name="aliveNeighbours">Alive neighbours count.</param>
        /// <param name="currentState">Cell current state.</param>
        protected BaseElementRule(short aliveNeighbours, bool currentState)
        {
            this.aliveNeighbours = aliveNeighbours;
            this.currentState = currentState;
        }

        
    }
}
