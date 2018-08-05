using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotOM;
using MonoviaRobot.controller;

namespace MonoviaRobot.model
{
    class RobotLabels
    {

        IRobotStructure str;
        static RobotLabelServer labels;

        public RobotLabels()
        {
            Structure structure = new Structure();
            str = structure.getStructure();
            labels = str.Labels;
        }

        public RobotLabelServer getLabelServer()
        {
            return labels;
        }

        public static IRobotLabel createLabel(IRobotLabelType lblType, string labelName)
        {
            return labels.Create(lblType, labelName);
        }


    }
}
