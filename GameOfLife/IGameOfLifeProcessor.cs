using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    /// <summary>
    /// Interface for Game of life class.
    /// </summary>
    public interface IGameOfLifeProcessor
    {
        bool IsElementAlive(Element element);
    }
}
