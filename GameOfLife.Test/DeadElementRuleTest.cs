using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino;
using Rhino.Mocks;
using GameOfLife.RuleEngine;
namespace GameOfLife.Test
{
    [TestFixture]
    public class DeadElementRuleTest
    {
        [TestCase(2, false, true)]
        [TestCase(1, false, true)]
        [TestCase(1, true, true)]
        [TestCase(3, true, false)]
        [TestCase(4, true, true)]
        [TestCase(5, true, true)]
        public void IsRuleApplicableTest(short aliveNeighbourCount, bool currentState, bool expectedResult)
        {
            // Act
            DeadElementRule rule = new DeadElementRule(aliveNeighbourCount, currentState);

            // Arrange
            bool returnValue = rule.IsRuleApplicable();

            // Assert
            Assert.That(expectedResult ==  returnValue, String.Format("Is Rule Applicable test failed expected {0}, actual {1} ", expectedResult, returnValue));

        }
    }
}
