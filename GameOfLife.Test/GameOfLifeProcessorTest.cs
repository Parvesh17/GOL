using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Rhino;
using Rhino.Mocks;
using GameOfLife.NeighbourFinder;
using GameOfLife.RuleEngine;
using GameOfLife.Model;
namespace GameOfLife.Test
{
    [TestFixture]
    public class GameOfLifeProcessorTest
    {
        private INeighbourFinder mockNeighBourFinder;
        private IRuleEngineFactory mockRuleEngineFactory;
        private IRuleEngine mockRuleEngine;

        [SetUp]
        public void SetUp()
        {
            mockNeighBourFinder = MockRepository.GenerateStub<INeighbourFinder>();
            mockRuleEngineFactory = MockRepository.GenerateStub<IRuleEngineFactory>();
            mockRuleEngine = MockRepository.GenerateStub<IRuleEngine>();
            
        }

        [Test]
        public void IsElementAliveWhenAliveNeighbourCountIsZeroTest()
        {
            // Act
            mockRuleEngine.Stub(s=> s.NewState()).Return(true);
            mockRuleEngineFactory.Stub(s => s.GetApplicabaleRule(Arg<short>.Is.Anything, Arg<bool>.Is.Anything)).Return(mockRuleEngine);
            mockNeighBourFinder.Stub(s => s.GetLiveNeighboursCount(Arg<Element>.Is.Anything)).Return(0);

            GameOfLifeProcessor processor = new GameOfLifeProcessor(mockNeighBourFinder, mockRuleEngineFactory);
            
            // Arrange
           bool returnValue =  processor.IsElementAlive(new Element(2, 1));

            // Assert
            Assert.IsFalse(returnValue);
            mockRuleEngineFactory.AssertWasNotCalled(s=> s.GetApplicabaleRule(Arg<short>.Is.Anything, Arg<bool>.Is.Anything));

        }

        [Test]
        public void IsElementAliveWhenAliveNeighbourCountIsGreaterThenZeroTest()
        {
            // Act
            mockRuleEngine.Stub(s => s.NewState()).Return(true);
            mockRuleEngineFactory.Stub(s => s.GetApplicabaleRule(Arg<short>.Is.Anything, Arg<bool>.Is.Anything)).Return(mockRuleEngine);
            mockNeighBourFinder.Stub(s => s.GetLiveNeighboursCount(Arg<Element>.Is.Anything)).Return(2);

            GameOfLifeProcessor processor = new GameOfLifeProcessor(mockNeighBourFinder, mockRuleEngineFactory);

            // Arrange
            bool returnValue = processor.IsElementAlive(new Element(2, 1));

            // Assert
            Assert.IsTrue(returnValue);
            mockRuleEngineFactory.AssertWasCalled(s => s.GetApplicabaleRule(2, false));

        }
    }
}
