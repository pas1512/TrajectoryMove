using System;

public class Timer
{
    private DateTime _start;

    public void Set()
    {
        _start = DateTime.Now;
    }

    public float Current()
    {
        return (float)(DateTime.Now - _start).TotalSeconds;
    }

    public float Interrupt()
    {
        float current = Current();
        Set();
        return current;
    }
}