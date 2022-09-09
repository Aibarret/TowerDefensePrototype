using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float remainingTime;
    private bool timerOn = false;

    public GameObject returnObject;
    public string nameOfObject;

    // Update is called once per frame
    void Update()
    {
        if (timerOn)
        {
            if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                print(remainingTime);

            }
            else
            {
                // I keep forgetting there's no good way to get a variable script from any potential Game Object in Unity
                //LET ME PROGRAM UNSAFELY
                returnObject.GetComponent<Tower>().timeOut();
            }
        }
    }

    public void startTimer(float timerDuration)
    {
        
        remainingTime = timerDuration;
        timerOn = true;
    }

    public void stopTimer()
    {
        timerOn = false;
    }

    
}
