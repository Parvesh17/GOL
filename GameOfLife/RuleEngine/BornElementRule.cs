using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.RuleEngine
{
    /// <summary>
    /// Born Rule class handles the logic for cell born condition.
    /// </summary>
    public class BornElementRule : BaseElementRule, IRuleEngine
    {
        public BornElementRule(short aliveNeighbours, bool currentState)
            : base(aliveNeighbours, currentState)
        { }

        /// <summary>
        /// Gets new state.
        /// </summary>
        /// <returns></returns>
        public bool NewState()
        {
            return true;
        }

        /// <summary>
        /// This method will verify that a class can handle the particular request.
        /// </summary>
        /// <returns>True is yes else false.</returns>
        public bool IsRuleApplicable()
        {
            if (!this.currentState)
            {
                if (this.aliveNeighbours == 3)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
