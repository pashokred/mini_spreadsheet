using System.Collections.Generic;

namespace Lab1
{
    public class Cell
    {
        public Cell(string position)
        {
            this.Position = position;
        }

        public string Position { get; set; }
        public List<Cell> Dependencies = new List<Cell>();
        public string Expression { get; set; }
    }
    
    public class CellEqualityComparer : IEqualityComparer<Cell>
    {
        #region IEqualityComparer<Cell> cells

        public bool Equals(Cell cell1, Cell cell2)
        {
            if (cell2 != null && cell1 != null)
            {
                return cell1.Position == cell2.Position;
            }
            return false;
        }

        public int GetHashCode(Cell cell)
        {
            return cell.Position.GetHashCode();
        }

        #endregion
    }
    
}
