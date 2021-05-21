using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schd
{
    class Result
    {
        public int processID;
        public int startP;
        public int burstTime;
        public int waitingTime;
        public int runTime = 0;

        public Result(int processID, int startP, int burstTime, int waitingTime)
        {
            this.processID = processID;
            this.startP = startP;
            this.burstTime = burstTime;
            this.waitingTime = waitingTime;
        }
        public Result(int runTime) {
            this.runTime = runTime;
        }
    }
}
