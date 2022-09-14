// See https://aka.ms/new-console-template for more information
Task firstTask = DoSomethingAsync("1st", 4, 3.3);
Task secondTask = DoSomethingAsync("2nd", 4, 2.2);
Task thirdTask = DoSomethingAsync("3rd", 5, 1.1);

async Task DoSomethingAsync(string taskName, int loops, double waitTimeInSeconds)
{
    for (int i = 0; i < loops; i++)
    {
        Console.WriteLine($"progress of {taskName} task");
        await Task.Delay(TimeSpan.FromSeconds(waitTimeInSeconds));
    }
}

List<Task> tasks = new List<Task> { firstTask, secondTask, thirdTask };

while(tasks.Count > 0)
{
    Task finishedTask = await Task.WhenAny(tasks);
    if(finishedTask == firstTask)
    {
        Console.WriteLine($"{nameof(firstTask)} is completed.");
    }
    if (finishedTask == secondTask)
    {
        Console.WriteLine($"{nameof(secondTask)} is completed.");
    }
    if (finishedTask == thirdTask)
    {
        Console.WriteLine($"{nameof(thirdTask)} is completed.");
    }
    await finishedTask;
    tasks.Remove(finishedTask);
}

Console.WriteLine("Everything is done");