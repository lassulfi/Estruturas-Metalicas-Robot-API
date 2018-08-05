using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonoviaRobot.model
{
    class Bar
    {
        public int id { get; set; }
        public Node startNode { get; set; }
        public Node endNode { get; set; }

        public Bar() { }

        public Bar(int id, Node start, Node end)
        {
            this.id = id;
            this.startNode = start;
            this.endNode = end;
        }
    }
}
