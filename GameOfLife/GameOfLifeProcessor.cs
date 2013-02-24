using GameOfLife.Model;
using GameOfLife.NeighbourFinder;
using GameOfLife.RuleEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Main Processing class.
    /// </summary>
    public class GameOfLifeProcessor : IGameOfLifeProcessor
    {
        private INeighbourFinder neighbourFinder;
        private IRuleEngineFactory ruleFactory;
        
        public GameOfLifeProcessor(INeighbourFinder neighbourFinder, IRuleEngineFactory ruleFactory)
        {
            neighbourFinder.ValidateElementForNull("Neighbour Finder is null.");
            ruleFactory.ValidateElementForNull("Rule Factory is null.");

            this.neighbourFinder = neighbourFinder;
            this.ruleFactory = ruleFactory;
        }

        public bool IsElementAlive(Element element)
        {
            try
            {
                short aliveNeighBourCount = this.neighbourFinder.GetLiveNeighboursCount(element);

                if (aliveNeighBourCount > 0)
                {
                    IRuleEngine ruleEngine = this.ruleFactory.GetApplicabaleRule(aliveNeighBourCount, element.IsAlive);
                    element.SetAlive = ruleEngine.NewState();
                    return element.IsAlive;
                }
            }
            catch (Exception)
            {
                // Log it.
                throw;
            }

            return false;
        }
    }
}
