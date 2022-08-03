using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParallelTesting.Models;
using ParallelTesting.Services;

namespace ParallelTesting.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WorkerController : ControllerBase
{
    private readonly WorkerService _worker;
    private static Random _rand = new Random();

    public WorkerController(WorkerService worker)
    {
        _worker = worker;
    }

    [HttpPost("serial/{processes:int}")]
    public async Task<IActionResult> StartSerialProcessing(int processes)
    {
        TaskInfo[] processesToRun = GetRandomProcessInfo(processes);

        var sw = Stopwatch.StartNew();

        var tasksToProcess = processesToRun.Select(async p => await _worker.ProcessTask(p));

        sw.Stop();
        Console.WriteLine($"{DateTime.UtcNow} :: Took {sw.Elapsed} to create tasks.");

        int totalDurationMilliseconds = 0;

        Console.WriteLine($"{DateTime.UtcNow} :: ***************** Starting Task Processing ************");
        sw.Restart();
        foreach (var task in tasksToProcess)
        {
            var timeElapsed = await task;
            totalDurationMilliseconds += timeElapsed;
        }
        sw.Stop();
        Console.WriteLine($"{DateTime.UtcNow} :: Total task processing time: {totalDurationMilliseconds / 1000} seconds ");
        Console.WriteLine($"{DateTime.UtcNow} :: Total stopwatch elapsed time: {sw.Elapsed} seconds ");

        return new OkObjectResult(processesToRun);
    }



    [HttpPost("parallel/{processes:int}")]
    public async Task<IActionResult> StartParallelProcessing(int processes)
    {
        var processesToRun = GetRandomProcessInfo(processes);

        var sw = Stopwatch.StartNew();

        var tasksToProcess = processesToRun.Select(async p => await _worker.ProcessTask(p));

        sw.Stop();
        Console.WriteLine($"{DateTime.UtcNow} :: Took {sw.Elapsed} to create tasks.");

        var totalDurationMilliseconds = 0;
        ParallelOptions parallelOptions = new()
        {
            MaxDegreeOfParallelism = 10
        };

        Console.WriteLine($"{DateTime.UtcNow} :: ***************** Starting Task Processing ************");
        sw.Restart();
        await Parallel.ForEachAsync(tasksToProcess, parallelOptions, async (task, token) =>
        {
            var timeElapsed = await task;
            totalDurationMilliseconds += timeElapsed;
        });

        sw.Stop();
        Console.WriteLine($"{DateTime.UtcNow} :: Total task processing time: {totalDurationMilliseconds / 1000} seconds ");
        Console.WriteLine($"{DateTime.UtcNow} :: Total stopwatch elapsed time: {sw.Elapsed} seconds ");

        return new OkObjectResult(processesToRun);
    }

    private TaskInfo[] GetRandomProcessInfo(int processes)
    {
        var processValues = new TaskInfo[processes];
        for(int i = 0; i < processes; i++)
        {
            processValues[i] = new TaskInfo
            {
                TaskId = i,
                TaskDuration = _rand.Next(1, 500)
            };
        }

        return processValues;  
    }
}