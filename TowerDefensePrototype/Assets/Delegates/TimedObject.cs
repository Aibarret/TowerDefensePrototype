using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    public DelegateTimer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer.startTimer(10, timeOut);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void timeOut()
    {
        print("doot");
    }
}
