using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.RuleEngine
{
    /// <summary>
    /// Alive rule class handles Game of life alive cell rules.
    /// </summary>
    public class LiveElementRule: BaseElementRule, IRuleEngine
    {
        public LiveElementRule(short aliveNeighbours, bool currentState)
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
           if (this.currentState)
           {
               if (this.aliveNeighbours == 2 || this.aliveNeighbours == 3)
               {
                   return true;
               }
           }

           return false;
       }
    }
}
