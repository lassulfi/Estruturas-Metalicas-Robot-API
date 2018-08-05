using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotOM;

namespace MonoviaRobot.model
{
    class Node
    {
        public int id { get; }
        public double xCoord { get; }
        public double yCoord { get; }
        public double zCoord { get; }

        public Node(int id, double xCoord, double yCoord, double zCoord)
        {
            this.id = id;
            this.xCoord = xCoord;
            this.yCoord = yCoord;
            this.zCoord = zCoord;
        }

        public override string ToString()
        {
            return "Node id: " + id
                    + ", x coordinate: " + xCoord
                    + ", y coordinate: " + yCoord
                    + ", z coordinate: " + zCoord; 
        }
    }
}
