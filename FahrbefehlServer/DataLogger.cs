using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using RobotCtrl;
using RobotIO;

namespace FileServer
{
    class DataLogger
    {
        private bool Status = false; //false = stopp, True = run
        public Robot myRobot;

        public void Log()
        {
            Status = true;//run Baby run!!
            if (File.Exists(@"Temp\DataFile.txt"))
            {
                File.Delete(@"Temp\DataFile.txt"); //wegg mit dem alten
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Temp\DataFile.txt", true))
            {
                file.WriteLine("Data of Testat2: ");
                file.WriteLine(" ");
                while (Status) {
                    Thread.Sleep(200);
                    file.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm:ss.fff") + ";" + myRobot.Drive.DriveInfo.Position.X.ToString() + ";"+ myRobot.Drive.DriveInfo.Position.Y.ToString());
                }
                file.Close();
            }
        }

        public void Stop()
        {
            Status = false;
            
        }

    }
}
