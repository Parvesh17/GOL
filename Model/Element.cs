using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model
{
   public class Element
    {
       private bool isAlive;
      
       public Element(int rowIndex, int columnIndex)
       {
           this.RowIndex = rowIndex;
           this.ColumnIndex = columnIndex;
       }

       public int RowIndex { get; set; }
       public int ColumnIndex { get; set; }
       public bool IsAlive { get { return isAlive;} }
       public bool SetAlive { set { isAlive = value; } }
       //public bool HoldTempAliveState
    }
}
