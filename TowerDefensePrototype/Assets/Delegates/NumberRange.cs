using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberRange
{
    public delegate void ReturnFunction(int value);

    private ReturnFunction rangeHit;

    private int realCurrent;

    public int current
    {
        get => realCurrent;
        set => realCurrent = changeValue(value);
    }

    private int max;
    private int min;

    public NumberRange(int startValue, int maxValue, int minValue, ReturnFunction sendTo)
    {
        rangeHit = sendTo;
        max = maxValue;
        min = minValue;
        realCurrent = startValue;
    }

    private int changeValue(int value)
    {
        if ((value >= max) || (value <= min))
        {
            return (value >= max) ?  informOfChange(max) :informOfChange(min);
        }
        else
        {
            return informOfChange(value);
        }
    }

    private int informOfChange(int value)
    {
        rangeHit(value);
        return value;
    }
}
