using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotOM;
using MonoviaRobot.model;

namespace MonoviaRobot.controller
{
    class Structure
    {
        //Atributes
        static IRobotApplication robApp;
        static IRobotStructure str;
        Node[] nodes;
        Bar[] bars;
        int numberOfFrames;
        double frameSpam, frameHeigth, frameOffset;

        public Structure(int frames, double spam, double heigth, double offset)
        {

            //Parsing the main parameters
            this.numberOfFrames = frames;
            this.frameSpam = spam;
            this.frameHeigth = heigth;
            this.frameOffset = offset;

            //Start application
            robApp = RobotController.getRobot();

            //Create a project
            RobotProjectController.createProject(robApp);

            //Create a structure
            str = robApp.Project.Structure;
        }
        
        public IRobotStructure getStructure()
        {
            //Create a structure
            return str;
        }

        public void generateNodes(IRobotStructure str, Node[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                str.Nodes.Create(nodes[i].id, nodes[i].xCoord, nodes[i].yCoord, nodes[i].zCoord);
            }
        }

        public void generateBars(IRobotStructure str, Bar[] bars)
        {
            for(int i = 0; i < bars.Length; i++)
            {
                str.Bars.Create(bars[i].id, bars[i].startNode.id, bars[i].endNode.id);
            }
        }

        private Node[] generateNodeFromData()
        {
            int numberOfNodes = 4 * numberOfFrames;
            Node[] nodes = new Node[numberOfNodes];

            for(int i = 0; i < numberOfFrames; i++)
            {
                nodes[4 * i - 4] = new Node(4 * i - 3, 0, i * frameOffset / 1000 , 0);
                nodes[4 * i - 3] = new Node(4 * i - 2, 0, i * frameOffset / 1000, frameHeigth / 1000);
                nodes[4 * i - 2] = new Node(4 * i - 1, frameSpam / 1000, i * frameOffset / 1000, frameHeigth / 1000);
                nodes[4 * i - 1] = new Node(4 * i, frameSpam / 1000, i * frameOffset / 1000, 0);
            }

            return nodes;
        }

        private Bar[] generateGeometry()
        {
            int numberOfBars = numberOfFrames * 3;
            int numberOfNodes = numberOfBars * 4;

            Node[] nodes = generateNodeFromData();

            Bar[] bars = new Bar[numberOfBars];

            int lineIndex = 1;

            for(int i = 0; i < numberOfBars; i++)
            {
                bars[i] = new Bar();
                bars[i].id = i + 1;

            }

            return bars;
        }
    }
}
