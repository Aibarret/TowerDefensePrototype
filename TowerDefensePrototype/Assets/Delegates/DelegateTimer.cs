using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateTimer : MonoBehaviour
{
    public delegate void ReturnFunction();

    ReturnFunction returnFunction;

    private bool isRunning = false;
    private bool isPaused = false;
    private float maxTime;

    public bool isRepeat = false;

    private float elapsedFrames = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (isRunning && !isPaused)
        {
            elapsedFrames += Time.deltaTime;

            if (elapsedFrames >= maxTime)
            {
                endTimer();
            }
        }
    }

    public void startTimer(float seconds, ReturnFunction timeOut, bool repeat=false)
    {
        returnFunction = timeOut;
        maxTime = seconds;
        elapsedFrames = 0;
        isRunning = true;
        isRepeat = repeat;
    }

    public void endTimer()
    {
        if (isRepeat)
        {
            resetTimer();
        }
        else
        {
            isRunning = false;
            elapsedFrames = 0;
        }
        
        returnFunction();
    }

    public float getCurrentTime()
    {
        return maxTime - elapsedFrames;
    }

    public float getElaspsedTime()
    {
        return elapsedFrames;
    }

    public bool getPaused()
    {
        return isPaused;
    }

    public void pause()
    {
        isPaused = !isPaused;
    }

    public void resetTimer()
    {
        elapsedFrames = 0;
    }

}
