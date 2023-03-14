using System.Collections;
using System.Collections.Generic;
using System;

public class Counter 
{
    public float TimeToComplete { get { return timeToComplete; } }
    public float ActualTime { get { return actualTime; } }
    public bool Stopped { get { return stopped; } }

    private float timeToComplete;
    private float actualTime;
    private DateTime lastDateTime;
    private bool stopped = true;

    public Counter() { }

    public Counter(float time)
    {
        timeToComplete = time;
    }

    public bool CheckCounter()
    {
        if (!stopped)
        {
            TimeSpan addSeconds = DateTime.Now - lastDateTime;
            actualTime += (float)addSeconds.TotalSeconds;

            //Update lastDateTime
            lastDateTime = DateTime.Now;

            bool counterFinished = actualTime >= timeToComplete;

            if (counterFinished)
                ResetCounter();

            return counterFinished;
        }
        else
            return false;
    }

    public void ResetCounter()
    {
        lastDateTime = default;
        actualTime = 0;

        stopped = true;
    }

    public void SetTimeToComplete(float time)
    {
        timeToComplete = time;
    }

    public void PlayCounter()
    {
        lastDateTime = DateTime.Now;
        stopped = false;
    }

    public void StopCounter()
    {
        stopped = true;
    }
}
