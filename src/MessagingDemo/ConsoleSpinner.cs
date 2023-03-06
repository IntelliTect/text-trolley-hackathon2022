namespace MessagingDemo;

public class ConsoleSpinner
{
    private readonly int delay;
    private bool isRunning = false;
    private Thread thread;

    public ConsoleSpinner(int delay = 300)
    {
        this.delay = delay;
    }

    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            thread = new Thread(Spin);
            thread.Start();
        }
    }

    public void Stop()
    {
        isRunning = false;
    }

    private void Spin()
    {
        while (isRunning)
        {
            Console.Write('.');
            Thread.Sleep(delay);
        }
    }
}
