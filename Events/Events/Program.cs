using System; 
public class ThresholdEventArgs : EventArgs
{
    public int Threshold { get; }
    public int Total { get; }

    public ThresholdEventArgs(int threshold , int total)
    {
        Threshold = threshold;  
        Total = total;  
    }
}

public class Counter
{
    private int _threshold; 
    private int _total;

    public event EventHandler<ThresholdEventArgs> ThresholdReached;

    public Counter(int threshold)
    {
        _threshold = threshold; 
    }

    public void Add(int x)
    {
        _total += x;
         if(_total > _threshold)
        {
            OnThresholdReached(new ThresholdEventArgs(_threshold , _total));
        }
    }
    protected virtual void OnThresholdReached(ThresholdEventArgs e)
    {
        ThresholdReached?.Invoke(this , e);
    }

}
class Program
{
    static void Main(string[] args)
    {
        Counter counter = new Counter(10);
        counter.ThresholdReached += Counter_ThresholdReached;

        counter.Add(3);
        counter.Add(4);
        counter.Add(2);
    }

    private static void Counter_ThresholdReached(object sender, ThresholdEventArgs e)
    {
        Console.WriteLine($"Threshold of {e.Threshold} was reached. Total: {e.Total}");
    }
}