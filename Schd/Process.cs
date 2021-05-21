using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Schd
{
    class Process
    {
        public int processID;
        public int arriveTime;
        public int runTime;
        public int burstTime;
        public int waitingTime;
        public int priority;
   
        public Process(int processID, int arriveTime, int burstTime, int priority)
        {
            this.processID = processID;
            this.arriveTime = arriveTime;
            this.burstTime = burstTime;
            this.priority = priority;
        }
        
        public Process(int processID, int runTime, int burstTime, int waitingTime, int priority)
        {
            this.processID = processID;
            this.runTime = runTime;
            this.burstTime = burstTime;
            this.waitingTime = waitingTime;
            this.priority = priority;
        }
    }
}

//if (currentProcess == 0)
//{
//    if (readyQueue.Count != 0)
//    {
//        getHighestPriority_rq(readyQueue);
//        ReadyQueueElement rq = readyQueue.ElementAt(highPriIndex);

//        resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime));
//        cpuDone = rq.burstTime;
//        cpuTime = 0;
//        currentProcess = rq.processID;

//        processTemp.processID = rq.processID;
//        processTemp.runTime = runTime;
//        processTemp.burstTime = rq.burstTime;
//        processTemp.waitingTime = rq.waitingTime;
//        processTemp.priority = rq.priority;

//        readyQueue.RemoveAt(highPriIndex);
//    }
//}
//else
//{
//    if(readyQueue.Count != 0)
//    {
//        getHighestPriority_rq(readyQueue);
//        ReadyQueueElement rq = readyQueue.ElementAt(highPriIndex);
//        if (readyQueue.Count > 1)
//        {
//            if (readyQueue.ElementAt(highPriIndex).priority > processTemp.priority)
//            {
//                resultList.RemoveAt(resultList.Count - 1);
//                resultList.Add(new Result(rq.processID, runTimeTemp, rq.burstTime, rq.waitingTime));
//                runTimeTemp = 0;

//                processTemp.processID = rq.processID;
//                processTemp.runTime = runTimeTemp;
//                processTemp.burstTime = rq.burstTime;
//                processTemp.waitingTime = rq.waitingTime;
//                processTemp.priority = rq.priority;
//            }
//        }
//        runTimeTemp++;
//    }
//    if (cpuTime == cpuDone)
//    {
//        currentProcess = 0;
//        continue;
//    }
//}