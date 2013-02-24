using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.RuleEngine
{
    /// <summary>
    /// Dead rule class handles Game of life dead cell rules.
    /// </summary>
    public class DeadElementRule : BaseElementRule, IRuleEngine
    {
        /// <summary>
        /// DiedRule class constrctor.
        /// </summary>
        /// <param name="aliveNeighbours"></param>
        public DeadElementRule(short aliveNeighbours, bool currentState)
            : base(aliveNeighbours, currentState)
        {
        }

        /// <summary>
        /// Gets new state.
        /// </summary>
        /// <returns></returns>
        public bool NewState()
        {
            return false;
        }

        /// <summary>
        /// This method will verify that a class can handle the particular request.
        /// </summary>
        /// <returns>True is yes else false.</returns>
        public bool IsRuleApplicable()
        {
            //if (currentState)
            //{
                if (this.aliveNeighbours < 3 || this.aliveNeighbours > 3)
                {
                    return true;
                }
            //}
          
            return false;
        }
    }
}
