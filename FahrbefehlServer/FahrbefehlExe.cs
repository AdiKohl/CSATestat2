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
            double valueL;
            double valueA;
            int count = this.befehlArray.Count; 
            try
            {
                for(int i = 0; i< count; i++)
                {
                    Splitted = ((String)befehlArray[i]).Split(' ');
                    //i++;
                    switch (Splitted[0])
                    {
                        case "Start":
                            dl = new DataLogger();
                            dl.myRobot = robot;
                            new Thread(dl.Log).Start();
                            robot.Drive.Power = true;
                            Thread.Sleep(300);
                            break;

                        case "TrackLine":
                            valueL = Convert.ToDouble(Splitted[1]);
                            // Ausführen fahrt
                            robot.Drive.RunLine((float)valueL, 0.5f, 0.5f);
                            break;
                        case "TrackTurnLeft":
                            valueA = Convert.ToDouble(Splitted[1]);
                            robot.Drive.RunTurn((float)valueA, 0.5f, 0.3f);
                            break;
                        case "TrackTurnRight":
                            valueA = Convert.ToDouble(Splitted[1]);
                            robot.Drive.RunTurn((float)valueA * -1, 0.5f, 0.3f);
                            break;
                        case "TrackArcLeft":
                            valueA = Convert.ToDouble(Splitted[1]);
                            valueL = Convert.ToDouble(Splitted[2]);
                            robot.Drive.RunArcLeft((float)valueL,(float) valueA, 0.5f, 0.3f);

                            break;
                        case "TrackArcRight":
                            valueA = Convert.ToDouble(Splitted[1]);
                            valueL = Convert.ToDouble(Splitted[2]);
                            robot.Drive.RunArcRight((float)valueL, (float)valueA, 0.5f, 0.3f);

                            break;

                        default:
                            break;
                    }
                    while (!robot.Drive.Done)
                    {
                        //warten bis done
                    }
                }
            }
            finally
            {
                robot.Drive.Power = false;
                robot.Drive.Halt();
                dl.Stop();
                
            }

        }
    }

}
