using System;
using System.Security.Cryptography.X509Certificates;
public class TemperatureEventArgs : EventArgs
{
    public int Temprature; 
    public TemperatureEventArgs(int temprature)
    {
        Temprature = temprature;
    }
    
}
public class TempratureMonitor
{
    private int _ThresholdTemprature; 
    public event EventHandler<TemperatureEventArgs> TemparetureExceeded; 
    public TempratureMonitor(int temprature)
    {
        _ThresholdTemprature = temprature;   
    }

    public void CheckTemprature(int temprature)
    {
        if(temprature > _ThresholdTemprature)
        {
            OnTempratureExceeded(new TemperatureEventArgs(temprature));
        }
    }
    protected virtual void OnTempratureExceeded(TemperatureEventArgs e)
    {
        TemparetureExceeded?.Invoke(this , e);
    }
}

public class Program
{
    public static void Main()
    {
        TempratureMonitor tempratureMonitor = new TempratureMonitor(104) ;
        tempratureMonitor.TemparetureExceeded += TempratureExceeded;
        tempratureMonitor.CheckTemprature(105);
    }
    public static void TempratureExceeded(object sender , TemperatureEventArgs e)
    {
        Console.WriteLine($"Temperature exceeded: {e.Temprature} degrees");

    }
}