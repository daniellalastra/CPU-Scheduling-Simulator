using System;

namespace CpuSchedulingWinForms
{
    public class Process
    {
        // Basic process properties
        public int Id { get; set; }               // Process ID (P1, P2, etc.)
        public string Name => $"P{Id}";           // Process name for display
        public int ArrivalTime { get; set; }     // When process arrives in ready queue
        public int BurstTime { get; set; }        // Total CPU time required
        public int RemainingTime { get; set; }    // For preemptive algorithms
        public int Priority { get; set; }         // For priority scheduling (lower number = higher priority)

        // Calculated metrics
        public int CompletionTime { get; set; }   // When process finishes execution
        public int TurnaroundTime => CompletionTime - ArrivalTime;
        public int WaitingTime => TurnaroundTime - BurstTime;
        public int ResponseTime { get; set; }     // Time from arrival to first execution

        // For tracking scheduling
        public bool IsStarted { get; set; }
        public int StartTime { get; set; }        // When process first gets CPU
        public int LastPreemptTime { get; set; }  // For preemption tracking

        // For multi-level feedback queue
        public int QueueLevel { get; set; } = 0;  // Current queue level in MLFQ
        public int AllocatedQuantum { get; set; } // Quantum allocated at current level

        public Process()
        {
            // Initialize remaining time to burst time
            RemainingTime = BurstTime;
        }

        public Process(int id, int arrivalTime, int burstTime, int priority = 0)
        {
            Id = id;
            ArrivalTime = arrivalTime;
            BurstTime = burstTime;
            RemainingTime = burstTime;
            Priority = priority;
        }

        public void Reset()
        {
            RemainingTime = BurstTime;
            CompletionTime = 0;
            IsStarted = false;
            StartTime = 0;
            LastPreemptTime = 0;
            ResponseTime = 0;
            QueueLevel = 0;
        }

        public override string ToString()
        {
            return $"{Name} (Arrival: {ArrivalTime}, Burst: {BurstTime}, Priority: {Priority})";
        }

        // For deep cloning processes
        public Process Clone()
        {
            return new Process(Id, ArrivalTime, BurstTime, Priority)
            {
                RemainingTime = RemainingTime,
                CompletionTime = CompletionTime,
                IsStarted = IsStarted,
                StartTime = StartTime,
                LastPreemptTime = LastPreemptTime,
                ResponseTime = ResponseTime,
                QueueLevel = QueueLevel,
                AllocatedQuantum = AllocatedQuantum
            };
        }
    }
}