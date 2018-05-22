using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using RobotCtrl;
using RobotIO;
using System.Threading;

namespace FileServer
{

    class FahrbefehlExe
    {
        private ArrayList befehlArray;
        private String[] Splitted;
        private Robot robot;
        private DataLogger dl;

        public FahrbefehlExe(ArrayList befehlArray)
        {
            this.befehlArray = befehlArray;
            robot = new Robot();
        }

        public void DoExe()
        {

            //Abarbeiten der Fahrbefehle im befehlArray
            int i = 0;
            double valueL;
            int valueA;
            while (befehlArray[i] != null)
            {
                Splitted = ((String)befehlArray[i]).Split(' ');
                switch (Splitted[0])
                {
                    case "Start":
                        dl = new DataLogger();
                        new Thread(dl.Log).Start();
                        break;

                    case "TrackLine":
                        valueL = Convert.ToDouble(Splitted[1]);
                        // Ausführen fahrt
                        robot.Drive.RunLine((float)valueL, 0.2f, 0.2f);
                        break;
                    case "TrackTurnLeft":
                        valueA = Convert.ToInt16(Splitted[1]);
                        robot.Drive.RunTurn((float)valueA, 0.2f, 0.2f);
                        break;
                    case "TrackTurnRight":
                        valueA = Convert.ToInt16(Splitted[1]);
                        robot.Drive.RunTurn(-(float)valueA, 0.2f, 0.2f);
                        break;
                    case "TurnArcLeft":
                        valueA = Convert.ToInt16(Splitted[1]);
                        valueL = Convert.ToDouble(Splitted[2]);
                        robot.Drive.RunArcLeft((float)valueL, (float)valueA, 0.2f, 0.2f);

                        break;
                    case "TurnArcRight":
                        valueA = Convert.ToInt16(Splitted[1]);
                        valueL = Convert.ToDouble(Splitted[2]);
                        robot.Drive.RunArcRight((float)valueL, (float)valueA, 0.2f, 0.2f);

                        break;

                    default:
                        break;
                }
            }



        }
    }

}
