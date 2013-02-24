using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.RuleEngine
{
    /// <summary>
    /// Interface for all Game of life rules.
    /// </summary>
    public interface IRuleEngine
    {
        /// <summary>
        /// This method will verify that a class can handle the particular request.
        /// </summary>
        /// <returns>True is yes else false.</returns>
        bool IsRuleApplicable();

        /// <summary>
        /// Gets new state.
        /// </summary>
        /// <returns></returns>
        bool NewState();
    }
}
