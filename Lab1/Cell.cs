using System.Collections.Generic;

namespace Lab1
{
    public class Cell
    {
        public Cell(string position)
        {
            this.position = position;
        }

        public string position { get; set; }
        public List<Cell> Dependencies = new List<Cell>();
        public List<Cell> TemporaryDependencies = new List<Cell>();
        public string Expression { get; set; }
    }
    
    public class CellEqualityComparer : IEqualityComparer<Cell>
    {
        #region IEqualityComparer<Cell> cells

        public bool Equals(Cell cell1, Cell cell2)
        {
            return cell1.position == cell2.position;
        }

        public int GetHashCode(Cell cell)
        {
            return cell.position.GetHashCode();
        }

        #endregion
    }
    
}
