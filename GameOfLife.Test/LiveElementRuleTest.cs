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
    public class LiveElementRuleTest
    {
        [TestCase(2, false, false)]
        [TestCase(1, false, false)]
        [TestCase(1, true,  false)]
        [TestCase(3, true,  true)]
        [TestCase(2, true,  true)]
        [TestCase(4, true,  false)]
        [TestCase(5, true,  false)]
        public void IsRuleApplicableTest(short aliveNeighbourCount, bool currentState, bool expectedResult)
        {
            // Act
            LiveElementRule rule = new LiveElementRule(aliveNeighbourCount, currentState);

            // Arrange
            bool returnValue = rule.IsRuleApplicable();

            // Assert
            Assert.That(expectedResult == returnValue, String.Format("Is Rule Applicable test failed expected {0}, actual {1} ", expectedResult, returnValue));

        }
    }
}
