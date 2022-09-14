// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


Task firstTask = DoSomethingAsync("1st", 5, 3);
Task secondTask = DoSomethingAsync("2nd", 5, 4, true);
Task thirdTask = DoSomethingAsync("3rd", 5, 3, true);


async Task DoSomethingAsync(string taskName, int loops, int waitTimeInSeconds, bool throwException = false)
{
    for (int i = 0; i < loops; i++)
    {
        Console.WriteLine($"progress of {taskName} task");
        await Task.Delay(TimeSpan.FromSeconds(waitTimeInSeconds));
        if (throwException)
            throw new ArgumentException($"Exception of {taskName} task");
    }
}

Task.WaitAll(firstTask, secondTask, thirdTask);
Console.WriteLine("Everything is done");