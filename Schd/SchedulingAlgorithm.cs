using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Schd
{
    class ReadyQueueElement
    {
        public int processID;
        public int burstTime;
        public int waitingTime;
        public int priority;
        public bool switched;

        public ReadyQueueElement(int processID, int burstTime, int waitingTime)
        {
            this.processID = processID;
            this.burstTime = burstTime;
            this.waitingTime = waitingTime;
        }

        public ReadyQueueElement(int processID, int burstTime, int waitingTime, bool switched)
        {
            this.processID = processID;
            this.burstTime = burstTime;
            this.waitingTime = waitingTime;
            this.switched = switched;
        }

        public ReadyQueueElement(int processID, int burstTime, int waitingTime,int priority, bool switched)
        {
            this.processID = processID;
            this.burstTime = burstTime;
            this.waitingTime = waitingTime;
            this.priority = priority;
            this.switched = switched;
        }
    }

    class SchedulingAlgorithm_FCFS
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            int currentProcess = 0;
            int cpuTime = 0;
            int cpuDone = 0;
            int runTime = 0;

            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    if (frontJob.arriveTime == runTime)
                    {
                        readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0));
                        jobList.RemoveAt(0);
                    }
                    else
                        break;
                }

                if (currentProcess == 0)
                {
                    if (readyQueue.Count != 0)
                    {
                        ReadyQueueElement rq = readyQueue.ElementAt(0);
                        resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime));
                        cpuDone = rq.burstTime;
                        cpuTime = 0;
                        currentProcess = rq.processID;
                        readyQueue.RemoveAt(0);
                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {
                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                    readyQueue.ElementAt(i).waitingTime++;

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }

    class SchedulingAlgorithm_SJF
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            int currentProcess = 0;
            int cpuTime = 0;
            int cpuDone = 0;
            int runTime = 0;
            int shortestBurstIndex_rq = 0;
            int shortestBurstTemp;

            void getShortestBurst_rq(List<ReadyQueueElement> rq)
            {
                shortestBurstTemp = rq.ElementAt(0).burstTime;
                for (int i = 0; i < rq.Count; i++)
                {
                    if (rq.ElementAt(i).burstTime <= shortestBurstTemp)
                    {
                        shortestBurstTemp = rq.ElementAt(i).burstTime;
                        shortestBurstIndex_rq = i;
                    }
                }
            }

            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    if (frontJob.arriveTime == runTime)
                    {
                        readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0));
                        jobList.RemoveAt(0);
                    }
                    else
                        break;
                }

                if (currentProcess == 0)
                {
                    if (readyQueue.Count != 0)
                    {
                        getShortestBurst_rq(readyQueue);
                        ReadyQueueElement rq = readyQueue.ElementAt(shortestBurstIndex_rq);
                        resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime));
                        cpuDone = rq.burstTime;
                        cpuTime = 0;
                        currentProcess = rq.processID;
                        readyQueue.RemoveAt(shortestBurstIndex_rq);
                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {
                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                    readyQueue.ElementAt(i).waitingTime++;

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }

    class SchedulingAlgorithm_SRTF
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            int currentProcess = 0;
            int cpuTime = 0;
            int cpuDone = 0;
            int runTime = 0;
            int shortestBurstIndex_jl = 0;
            int shortestBurstTemp;
            int chkRqCntChng = 0;
            int cntTemp = 0;

            //void getShortestBurst_rq(List<ReadyQueueElement> rq)
            //{
            //    shortestBurstTemp = rq.ElementAt(0).burstTime;
            //    for (int i = 0; i < rq.Count; i++)
            //    {
            //        if (rq.ElementAt(i).burstTime <= shortestBurstTemp)
            //        {
            //            shortestBurstTemp = rq.ElementAt(i).burstTime;
            //            shortestBurstIndex_rq = i;
            //        }
            //    }
            //}

            void getShortestBurst_jl(List<Process> jl)
            {
                shortestBurstTemp = jl.ElementAt(0).burstTime;
                for (int i = 0; i < jl.Count; i++)
                {
                    if (jl.ElementAt(i).burstTime <= shortestBurstTemp)
                    {
                        shortestBurstTemp = jl.ElementAt(i).burstTime;
                        shortestBurstIndex_jl = i;
                    }
                }
            }

            bool isRqChanged(List<ReadyQueueElement> rq)
            {
                if (chkRqCntChng == rq.Count)
                    return false;
                else
                    return true;
            }

            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    if (frontJob.arriveTime == runTime)
                    {
                        readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0));
                        if (readyQueue.Count > 1)
                        {
                            readyQueue.Sort(delegate (ReadyQueueElement x, ReadyQueueElement y)
                            {
                                if (x.burstTime > y.burstTime) return 1;
                                else if (x.burstTime < y.burstTime) return -1;
                                return 0;
                            });
                        }
                        jobList.RemoveAt(0);
                        chkRqCntChng = readyQueue.Count;
                    }
                    else
                        break;
                }

                if (currentProcess == 0)
                {
                    if (readyQueue.Count != 0)
                    {
                        ReadyQueueElement rq = readyQueue.ElementAt(0);
                        
                        if(jobList.Count < 1)
                        {
                            resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime));
                            cpuDone = rq.burstTime;
                            cpuTime = 0;
                            currentProcess = rq.processID;
                            readyQueue.RemoveAt(0);
                        }
                        else
                        {
                            if(rq.burstTime <= jobList.ElementAt(0).burstTime)
                            {
                                resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime));
                                cpuDone = rq.burstTime;
                                cpuTime = 0;
                                currentProcess = rq.processID;
                                readyQueue.RemoveAt(0);
                            }
                            else
                            {
                                resultList.Add(new Result(rq.processID, runTime, runTime - resultList.ElementAt(resultList.Count).runTime, rq.waitingTime));
                                readyQueue.Add(new ReadyQueueElement(rq.processID, (rq.burstTime - (runTime - resultList.ElementAt(resultList.Count).runTime)), 0 - jobList.ElementAt(0).arriveTime, true));
                                cpuDone = (rq.burstTime - (runTime - resultList.ElementAt(resultList.Count).runTime));
                                cpuTime = 0;
                                currentProcess = rq.processID;
                                readyQueue.RemoveAt(0);
                            }
                        }
                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {
                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                    readyQueue.ElementAt(i).waitingTime++;

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }

    class SchedulingAlgorithm_Priority
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList)
        {
            int currentProcess = 0;
            int cpuTime = 0;
            int cpuDone = 0;
            int runTime = 0;
            int highPriIndex = 0;
            int highPriTemp;

            void getHighestPriority_rq(List<ReadyQueueElement> rq)
            {
                highPriTemp = rq.ElementAt(0).priority;
                for (int i = 0; i < rq.Count; i++)
                {
                    if (rq.ElementAt(i).priority <= highPriTemp)
                    {
                        highPriTemp = rq.ElementAt(i).priority;
                        highPriIndex = i;
                    }
                }
            }

            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    if (frontJob.arriveTime == runTime)
                    {
                        readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, frontJob.priority, false));
                        jobList.RemoveAt(0);
                    }
                    else
                        break;
                }

                if (currentProcess == 0)
                {
                    if (readyQueue.Count != 0)
                    {
                        getHighestPriority_rq(readyQueue);
                        ReadyQueueElement rq = readyQueue.ElementAt(highPriIndex);
                        resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime));
                        cpuDone = rq.burstTime;
                        cpuTime = 0;
                        currentProcess = rq.processID;
                        readyQueue.RemoveAt(highPriIndex);
                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {
                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                    readyQueue.ElementAt(i).waitingTime++;

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }

    class SchedulingAlgorithm_RoundRobin
    {
        public static List<Result> Run(List<Process> jobList, List<Result> resultList, int timeSlice)
        {
            int currentProcess = 0;
            int cpuTime = 0;
            int cpuDone = 0;
            int runTime = 0;
            int slice = timeSlice;
            int cntTemp = 0;

            List<ReadyQueueElement> readyQueue = new List<ReadyQueueElement>();
            do
            {
                while (jobList.Count != 0)
                {
                    Process frontJob = jobList.ElementAt(0);
                    if (frontJob.arriveTime == runTime)
                    {
                        readyQueue.Add(new ReadyQueueElement(frontJob.processID, frontJob.burstTime, 0, false));
                        jobList.RemoveAt(0);
                    }
                    else
                        break;
                }

                if (currentProcess == 0)
                {
                    if (readyQueue.Count != 0)
                    {
                        ReadyQueueElement rq = readyQueue.ElementAt(0);

                        if (rq.burstTime <= slice)
                        {
                            resultList.Add(new Result(rq.processID, runTime, rq.burstTime, rq.waitingTime));
                            cpuDone = rq.burstTime;
                            cpuTime = 0;
                            currentProcess = rq.processID;
                            readyQueue.RemoveAt(0);
                        }
                        else
                        {
                            resultList.Add(new Result(rq.processID, runTime, slice, rq.waitingTime));
                            cpuDone = slice;
                            cpuTime = 0;
                            currentProcess = rq.processID;
                            readyQueue.RemoveAt(0);
                            if (cntTemp == 0)
                            {
                                for (int i = 0; i < jobList.Count; i++)
                                {
                                    if (jobList.ElementAt(0).arriveTime <= slice)
                                    {
                                        readyQueue.Add(new ReadyQueueElement(jobList.ElementAt(0).processID, jobList.ElementAt(0).burstTime, 0 - jobList.ElementAt(0).arriveTime, true));
                                        jobList.RemoveAt(0);
                                        cntTemp++;
                                    }
                                }
                            }
                            readyQueue.Add(new ReadyQueueElement(rq.processID, rq.burstTime - slice, rq.waitingTime - slice));
                        }
                    }
                }
                else
                {
                    if (cpuTime == cpuDone)
                    {
                        currentProcess = 0;
                        continue;
                    }
                }

                cpuTime++;
                runTime++;

                for (int i = 0; i < readyQueue.Count; i++)
                    readyQueue.ElementAt(i).waitingTime++;

            } while (jobList.Count != 0 || readyQueue.Count != 0 || currentProcess != 0);

            return resultList;
        }
    }
}