using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RobotOM;

namespace MonoviaRobot.controller
{
    class RobotController
    {

        static IRobotApplication robApp = new RobotApplicationClass();

        RobotController()
        {
            makeVisible();
        }

        void makeVisible()
        {
            if(robApp.Visible == 0)
            {
                robApp.Interactive = 1;
                robApp.Visible = 1;
            }
        }

        public static IRobotApplication getRobot()
        {
            return robApp;
        }
    }
}
