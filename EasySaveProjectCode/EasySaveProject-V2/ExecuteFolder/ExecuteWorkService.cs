using EasySaveProject_V2.AddWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasySaveProject_V2.SaveFolder;
using System.Threading;

namespace EasySaveProject_V2.ExecuteFolder
{

    public class ExecuteWorkService
    {

        private Barrier priorityBarrier;
        private int totalPriorityTasks;
        private int completedPriorityTasks = 0;
        private int totalWorkCount;
        private int startedWorkCount = 0;
        private object lockObject = new object();


        public void WorkExecutor(int totalPriorityTasks, int totalWorkCount)
        {
            this.totalPriorityTasks = totalPriorityTasks;
            this.totalWorkCount = totalWorkCount;
            // Initialize the barrier to synchronize after all priority tasks have completed.
            // Only priority tasks participate in this barrier.
            this.priorityBarrier = new Barrier(totalPriorityTasks, (barrier) =>
            {
                Console.WriteLine("All priority tasks have completed. Non-priority tasks may proceed.");
            });
        }

        public void executeWork(SaveWorkModel work)
        {
            SaveFactory saveFactory = new SaveFactory();

            // Utilisez la méthode statique CreateSave pour obtenir une instance de Save
            string? saveType = work?.saveType;
            Save save = saveFactory.CreateSave(saveType);
            save.ExecuteSave(work);

        }

        public void ExecuteWorkThreadSafe(SaveWorkModel work,int numWork)

        // numWork contient le nombre de thread existant
        {
            ThreadStart threadStart = () =>
            {
                SaveFactory saveFactory = new SaveFactory();
                string? saveType = work?.saveType;
                Save save = saveFactory.CreateSave(saveType);

                lock (lockObject)
                {
                    startedWorkCount++;
                    // Check if it's the last work item to start and all priority tasks have been completed.
                    if (startedWorkCount == totalWorkCount && completedPriorityTasks == totalPriorityTasks)
                    {
                        // This signals the barrier for the last priority task, allowing non-priority tasks waiting on the barrier to proceed.
                        priorityBarrier.RemoveParticipants(1);
                    }
                }

                if (work.isPriority)
                {
                    // Execute the save operation for priority work.
                    save.ExecuteSave(work);

                    lock (lockObject)
                    {
                        completedPriorityTasks++;
                        if (completedPriorityTasks == totalPriorityTasks)
                        {
                            // If this is the last priority task, signal the barrier to allow any waiting non-priority tasks to proceed.
                            // Adjust the barrier participant count if there are no non-priority tasks waiting.
                            if (startedWorkCount == totalWorkCount)
                            {
                                priorityBarrier.RemoveParticipants(1);
                            }
                            else
                            {
                                priorityBarrier.SignalAndWait();
                            }
                        }
                    }
                }
                else
                {
                    lock (lockObject)
                    {
                        if (completedPriorityTasks < totalPriorityTasks)
                        {
                            // For non-priority tasks, this thread should wait if not all priority tasks have completed.
                            // It waits on the barrier, which is signaled once the last priority task completes.
                            priorityBarrier.AddParticipant();
                            priorityBarrier.SignalAndWait();
                            priorityBarrier.RemoveParticipant();
                        }
                    }

                    // Execute the save operation for non-priority work.
                    save.ExecuteSave(work);
                }
            };

            Thread thread = new Thread(threadStart);
            thread.Start();

        }


    }
}
