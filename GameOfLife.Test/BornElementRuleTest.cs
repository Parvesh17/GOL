using GameOfLife.RuleEngine;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Test
{
    [TestFixture]
    public class BornElementRuleTest
    {
        [TestCase(2, false, false)]
        [TestCase(1, false, false)]
        [TestCase(3, true, false)]
        [TestCase(3, false, true)]
        [TestCase(5, true, false)]
        public void IsRuleApplicableTest(short aliveNeighbourCount, bool currentState, bool expectedResult)
        {
            // Act
            BornElementRule rule = new BornElementRule(aliveNeighbourCount, currentState);

            // Arrange
            bool returnValue = rule.IsRuleApplicable();

            // Assert
            Assert.That(expectedResult == returnValue, String.Format("Is Rule Applicable test failed expected {0}, actual {1} ", expectedResult, returnValue));

        }
    }
}
