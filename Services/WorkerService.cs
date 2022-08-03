using ParallelTesting.Models;

namespace ParallelTesting.Services;

public class WorkerService
{
    public async Task<int> ProcessTask(TaskInfo taskInfo)
    {
        var trueDuration = taskInfo.TaskDuration * 10;

        Console.WriteLine($"{DateTime.UtcNow} :: Start processing task {taskInfo.TaskId}");
        await Task.Delay(trueDuration);
        Console.WriteLine($"{DateTime.UtcNow} :: Finished processing task {taskInfo.TaskId} after {trueDuration} ms");

        return trueDuration;
    }
}