using System;
using UnityEngine;

//Class created by: Charlotte Schofield
//AKA: Aquillis

[Serializable]
public class Stats
{
    //Takes the bar script to use in the class
    [SerializeField]
    private BarScript bar;
    //Vals that add to the bar
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float currentVal;

    public float CurrentVal
    {
        //Get the currentVal
        get
        {
            return currentVal;
        }
        //Set the currentVal to the player's val
        set
        {
            currentVal = value;
            bar.Value = currentVal;
        }
    }

    public float MaxVal
    {
        //Get the max value
        get
        {
            return maxVal;
        }
        //Set the max value, and allow it to update every time it needs to
        //Also, allows increases to the max value easily
        set
        {
            maxVal = value;
            bar.MaxValue = maxVal;
        }
    }

    //Allows the MaxVal to be initilized
    //Also initilizes the CurrentVal immediately
    public void Initilize()
    {
        MaxVal = maxVal;
        CurrentVal = currentVal;
    }
}
