using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PorticoManual.util;

namespace PorticoManual.model
{
    class Bar
    {
        public int id { get; set; }
        public Node startNode { get; set; }
        public Node endNode { get; set; }
        public MemberType type { get; set; }
        public string sectionLabel { get; set; }

        public Bar() { }

        public Bar(int id, Node start, Node end, MemberType type)
        {
            this.id = id;
            this.startNode = start;
            this.endNode = end;
            this.type = type;
        }

        public Bar(int id, Node start, Node end, MemberType type, string section)
        {
            this.id = id;
            this.startNode = start;
            this.endNode = end;
            this.type = type;
            this.sectionLabel = section;
        }

        public override string ToString()
        {
            return "Bar id: " + id 
                    + ", start node: " + startNode.ToString()
                    + ", end node: " + endNode.ToString()
                    + ", member type: " + type
                    + "section : " + sectionLabel;
        }
    }
}
