using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.RuleEngine
{
    /// <summary>
    /// Factory class responsible for producing Game of life rule engine applicable instance.
    /// </summary>
    public class RuleEngineFactory : IRuleEngineFactory
    {
        /// <summary>
        /// Method responsible for creating a applicable rule instance.
        /// </summary>
        /// <param name="aliveNeighbours">Count of alive neighbours.</param>
        /// <param name="currentState">Current state of the cell.</param>
        /// <returns>RuleEngine instance.</returns>
        public IRuleEngine GetApplicabaleRule(short aliveNeighbours, bool currentState)
        {
            /* 
             * Ideally this work will be done via Ioc framework and  concreate objects code can removed. 
             */
            
            List<IRuleEngine> ruleEngines = new List<IRuleEngine>();

            ruleEngines.Add(new BornElementRule(aliveNeighbours, currentState));
            ruleEngines.Add(new LiveElementRule(aliveNeighbours, currentState));
            ruleEngines.Add(new DeadElementRule(aliveNeighbours, currentState));

            // Iterates all the rule engines and applicable rule engine will be returned. 
            foreach (IRuleEngine rule in ruleEngines)
            {
                if (rule.IsRuleApplicable())
                {
                    return rule;
                }
            }

            throw new ArgumentException("Rule not supported.");
        }
    }
}
