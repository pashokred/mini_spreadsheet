using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class Cell
    {
        public string position;
        public List<string> Dependencies = new List<string>();

        public void AddDependency(string dependency)
        {
            Dependencies.Add(dependency);
        }

    }
}
