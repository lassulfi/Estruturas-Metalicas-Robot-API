using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotOM;

namespace MonoviaRobot.controller
{
    class RobotProjectController
    {

       public static void createProject(IRobotApplication app)
        {
            app.Project.New(IRobotProjectType.I_PT_FRAME_3D);
        }
    }
}
