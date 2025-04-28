using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CpuSchedulingWinForms;
using Microsoft.VisualBasic;

namespace CpuSchedulingWinForms
{
    public static class Algorithms
    {

        public static void fcfsAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int npX2 = np * 2;

            double[] bp = new double[np];
            double[] wtp = new double[np];
            string[] output1 = new string[npX2];
            double twt = 0.0, awt;
            int num;

            DialogResult result = MessageBox.Show("First Come First Serve Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    //MessageBox.Show("Enter Burst time for P" + (num + 1) + ":", "Burst time for Process", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    //Console.WriteLine("\nEnter Burst time for P" + (num + 1) + ":");

                    string input =
                    Microsoft.VisualBasic.Interaction.InputBox("Enter Burst time: ",
                                                       "Burst time for P" + (num + 1),
                                                       "",
                                                       -1, -1);

                    bp[num] = Convert.ToInt64(input);

                    //var input = Console.ReadLine();
                    //bp[num] = Convert.ToInt32(input);
                }

                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        wtp[num] = 0;
                    }
                    else
                    {
                        wtp[num] = wtp[num - 1] + bp[num - 1];
                        MessageBox.Show("Waiting time for P" + (num + 1) + " = " + wtp[num], "Job Queue", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                awt = twt / np;
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + awt + " sec(s)", "Average Awaiting Time", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            else if (result == DialogResult.No)
            {
                //this.Hide();
                //Form1 frm = new Form1();
                //frm.ShowDialog();
            }
        }

        public static void sjfAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            double[] bp = new double[np];
            double[] wtp = new double[np];
            double[] p = new double[np];
            double twt = 0.0, awt;
            int x, num;
            double temp = 0.0;
            bool found = false;

            DialogResult result = MessageBox.Show("Shortest Job First Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    string input =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    bp[num] = Convert.ToInt64(input);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    p[num] = bp[num];
                }
                for (x = 0; x <= np - 2; x++)
                {
                    for (num = 0; num <= np - 2; num++)
                    {
                        if (p[num] > p[num + 1])
                        {
                            temp = p[num];
                            p[num] = p[num + 1];
                            p[num + 1] = temp;
                        }
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (p[num] == bp[x] && found == false)
                            {
                                wtp[num] = 0;
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time:", MessageBoxButtons.OK, MessageBoxIcon.None);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                bp[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (p[num] == bp[x] && found == false)
                            {
                                wtp[num] = wtp[num - 1] + p[num - 1];
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK, MessageBoxIcon.None);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                bp[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + (awt = twt / np) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void priorityAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            DialogResult result = MessageBox.Show("Priority Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                double[] bp = new double[np];
                double[] wtp = new double[np + 1];
                int[] p = new int[np];
                int[] sp = new int[np];
                int x, num;
                double twt = 0.0;
                double awt;
                int temp = 0;
                bool found = false;
                for (num = 0; num <= np - 1; num++)
                {
                    string input =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                           "Burst time for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    bp[num] = Convert.ToInt64(input);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    string input2 =
                        Microsoft.VisualBasic.Interaction.InputBox("Enter priority: ",
                                                           "Priority for P" + (num + 1),
                                                           "",
                                                           -1, -1);

                    p[num] = Convert.ToInt16(input2);
                }
                for (num = 0; num <= np - 1; num++)
                {
                    sp[num] = p[num];
                }
                for (x = 0; x <= np - 2; x++)
                {
                    for (num = 0; num <= np - 2; num++)
                    {
                        if (sp[num] > sp[num + 1])
                        {
                            temp = sp[num];
                            sp[num] = sp[num + 1];
                            sp[num + 1] = temp;
                        }
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (sp[num] == p[x] && found == false)
                            {
                                wtp[num] = 0;
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                temp = x;
                                p[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                    else
                    {
                        for (x = 0; x <= np - 1; x++)
                        {
                            if (sp[num] == p[x] && found == false)
                            {
                                wtp[num] = wtp[num - 1] + bp[temp];
                                MessageBox.Show("Waiting time for P" + (x + 1) + " = " + wtp[num], "Waiting time", MessageBoxButtons.OK);
                                //Console.WriteLine("\nWaiting time for P" + (x + 1) + " = " + wtp[num]);
                                temp = x;
                                p[x] = 0;
                                found = true;
                            }
                        }
                        found = false;
                    }
                }
                for (num = 0; num <= np - 1; num++)
                {
                    twt = twt + wtp[num];
                }
                MessageBox.Show("Average waiting time for " + np + " processes" + " = " + (awt = twt / np) + " sec(s)", "Average waiting time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Console.WriteLine("\n\nAverage waiting time: " + (awt = twt / np));
                //Console.ReadLine();
            }
            else
            {
                //this.Hide();
            }
        }

        public static void roundRobinAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            double timeQuantum;
            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double[] remainingTime = new double[np];
            double[] waitingTime = new double[np];
            double[] turnaroundTime = new double[np];
            double[] lastRunTime = new double[np]; // Tracks when each process was last run

            // Get inputs
            DialogResult result = MessageBox.Show("Round Robin Scheduling", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                // Collect process information
                for (int i = 0; i < np; i++)
                {
                    arrivalTime[i] = Convert.ToDouble(Interaction.InputBox("Enter arrival time:",
                        $"Arrival time for P{i + 1}", "", -1, -1));

                    burstTime[i] = Convert.ToDouble(Interaction.InputBox("Enter burst time:",
                        $"Burst time for P{i + 1}", "", -1, -1));

                    remainingTime[i] = burstTime[i];
                    lastRunTime[i] = arrivalTime[i]; // Initialize to arrival time
                }

                timeQuantum = Convert.ToDouble(Interaction.InputBox("Enter time quantum:",
                    "Time Quantum", "", -1, -1));
                Helper.QuantumTime = timeQuantum.ToString();

                double currentTime = 0;
                int completed = 0;

                // Main scheduling loop
                while (completed < np)
                {
                    bool anyProcessExecuted = false;

                    for (int i = 0; i < np; i++)
                    {
                        if (remainingTime[i] > 0 && arrivalTime[i] <= currentTime)
                        {
                            anyProcessExecuted = true;

                            // Calculate waiting time since last run
                            waitingTime[i] += (currentTime - lastRunTime[i]);

                            // Execute for quantum or remaining time
                            double executeTime = Math.Min(timeQuantum, remainingTime[i]);
                            remainingTime[i] -= executeTime;
                            currentTime += executeTime;
                            lastRunTime[i] = currentTime;

                            // Check if process completed
                            if (remainingTime[i] == 0)
                            {
                                completed++;
                                turnaroundTime[i] = currentTime - arrivalTime[i];

                                MessageBox.Show($"Process {i + 1} completed:\n" +
                                    $"Waiting Time: {waitingTime[i]}\n" +
                                    $"Turnaround Time: {turnaroundTime[i]}",
                                    "Process Completion", MessageBoxButtons.OK);
                            }
                        }
                    }

                    // If no processes were ready, advance time
                    if (!anyProcessExecuted)
                    {
                        currentTime++;
                    }
                }

                // Calculate averages
                double avgWait = waitingTime.Average();
                double avgTurnaround = turnaroundTime.Average();

                MessageBox.Show($"Average Wait Time: {avgWait:F2}\n" +
                              $"Average Turnaround Time: {avgTurnaround:F2}",
                              "Final Results", MessageBoxButtons.OK);
            }
        }
        private static bool AnyProcessReady(double[] arrivalTime, double[] remainingTime, double currentTime)
        {
            for (int i = 0; i < arrivalTime.Length; i++)
            {
                if (remainingTime[i] > 0 && arrivalTime[i] <= currentTime)
                    return true;
            }
            return false;
        }
        public static void srtfAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double[] remainingTime = new double[np];
            double[] completionTime = new double[np];
            double[] waitingTime = new double[np];
            double[] turnaroundTime = new double[np];
            bool[] isCompleted = new bool[np];
            double currentTime = 0;
            int completed = 0;
            double totalWaitingTime = 0;
            double totalTurnaroundTime = 0;

            DialogResult result = MessageBox.Show("Shortest Remaining Time First", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                // Get process details
                for (int i = 0; i < np; i++)
                {
                    string arrivalInput = Interaction.InputBox("Enter arrival time:",
                        $"Arrival time for P{i + 1}", "", -1, -1);
                    arrivalTime[i] = Convert.ToDouble(arrivalInput);

                    string burstInput = Interaction.InputBox("Enter burst time:",
                        $"Burst time for P{i + 1}", "", -1, -1);
                    burstTime[i] = Convert.ToDouble(burstInput);
                    remainingTime[i] = burstTime[i];
                }

                while (completed != np)
                {
                    int shortest = -1;
                    double shortestTime = double.MaxValue;

                    // Find process with shortest remaining time
                    for (int i = 0; i < np; i++)
                    {
                        if (arrivalTime[i] <= currentTime &&
                            !isCompleted[i] &&
                            remainingTime[i] < shortestTime)
                        {
                            shortest = i;
                            shortestTime = remainingTime[i];
                        }
                    }

                    if (shortest == -1)
                    {
                        currentTime++;
                        continue;
                    }

                    // Process execution
                    remainingTime[shortest]--;
                    currentTime++;

                    if (remainingTime[shortest] == 0)
                    {
                        // Process completed
                        completionTime[shortest] = currentTime;
                        turnaroundTime[shortest] = completionTime[shortest] - arrivalTime[shortest];
                        waitingTime[shortest] = turnaroundTime[shortest] - burstTime[shortest];
                        totalWaitingTime += waitingTime[shortest];
                        totalTurnaroundTime += turnaroundTime[shortest];
                        isCompleted[shortest] = true;
                        completed++;

                        MessageBox.Show($"Process P{shortest + 1} completed:\n" +
                            $"Waiting Time: {waitingTime[shortest]}\n" +
                            $"Turnaround Time: {turnaroundTime[shortest]}",
                            "Process Completion", MessageBoxButtons.OK);
                    }
                }

                // Calculate averages
                double avgWaitingTime = totalWaitingTime / np;
                double avgTurnaroundTime = totalTurnaroundTime / np;

                MessageBox.Show($"SRTF Scheduling Results:\n\n" +
                    $"Average Waiting Time: {avgWaitingTime:F2}\n" +
                    $"Average Turnaround Time: {avgTurnaroundTime:F2}",
                    "Final Results", MessageBoxButtons.OK);
            }
        }

        public static void mlfqAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double[] remainingTime = new double[np];
            double[] completionTime = new double[np];
            double[] waitingTime = new double[np];
            double[] turnaroundTime = new double[np];
            int[] queueLevel = new int[np]; // 0 = highest priority, 1 = medium, 2 = lowest
            double[] quantumUsed = new double[np];
            double currentTime = 0;
            int completed = 0;
            double totalWaitingTime = 0;
            double totalTurnaroundTime = 0;
            bool[] isCompleted = new bool[np]; // Declare isCompleted here

            // Define quantum for each queue level
            double[] quantums = { 4, 8, double.MaxValue }; // Q0=4, Q1=8, Q2=FCFS

            DialogResult result = MessageBox.Show("Multi-Level Feedback Queue", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                // Get process details
                for (int i = 0; i < np; i++)
                {
                    string arrivalInput = Interaction.InputBox("Enter arrival time:",
                        $"Arrival time for P{i + 1}", "", -1, -1);
                    arrivalTime[i] = Convert.ToDouble(arrivalInput);

                    string burstInput = Interaction.InputBox("Enter burst time:",
                        $"Burst time for P{i + 1}", "", -1, -1);
                    burstTime[i] = Convert.ToDouble(burstInput);
                    remainingTime[i] = burstTime[i];
                    queueLevel[i] = 0; // Start in highest priority queue
                    isCompleted[i] = false; // Initialize isCompleted for each process
                }

                while (completed != np)
                {
                    bool processExecuted = false;

                    // Check queues from highest to lowest priority
                    for (int q = 0; q < 3; q++)
                    {
                        // Find first process in this queue that's ready to execute
                        for (int i = 0; i < np; i++)
                        {
                            if (!isCompleted[i] &&
                                arrivalTime[i] <= currentTime &&
                                queueLevel[i] == q)
                            {
                                double timeSlice = Math.Min(quantums[q], remainingTime[i]);

                                // Execute the process
                                remainingTime[i] -= timeSlice;
                                currentTime += timeSlice;
                                quantumUsed[i] += timeSlice;
                                processExecuted = true;

                                // Check if process completed
                                if (remainingTime[i] == 0)
                                {
                                    completionTime[i] = currentTime;
                                    turnaroundTime[i] = completionTime[i] - arrivalTime[i];
                                    waitingTime[i] = turnaroundTime[i] - burstTime[i];
                                    totalWaitingTime += waitingTime[i];
                                    totalTurnaroundTime += turnaroundTime[i];
                                    isCompleted[i] = true;
                                    completed++;

                                    MessageBox.Show($"Process P{i + 1} completed from Queue {q}:\n" +
                                        $"Waiting Time: {waitingTime[i]}\n" +
                                        $"Turnaround Time: {turnaroundTime[i]}",
                                        "Process Completion", MessageBoxButtons.OK);
                                }
                                else
                                {
                                    // Demote to next queue if not completed
                                    if (q < 2)
                                    {
                                        queueLevel[i] = q + 1;
                                    }
                                }

                                break; // Move to next time unit after executing
                            }
                        }

                        if (processExecuted) break;
                    }

                    if (!processExecuted)
                    {
                        currentTime++; // CPU idle
                    }
                }

                // Calculate averages
                double avgWaitingTime = totalWaitingTime / np;
                double avgTurnaroundTime = totalTurnaroundTime / np;

                MessageBox.Show($"MLFQ Scheduling Results:\n\n" +
                    $"Average Waiting Time: {avgWaitingTime:F2}\n" +
                    $"Average Turnaround Time: {avgTurnaroundTime:F2}\n" +
                    $"Queue Levels Used: 0 (Q=4), 1 (Q=8), 2 (FCFS)",
                    "Final Results", MessageBoxButtons.OK);
            }
        }
    }
}