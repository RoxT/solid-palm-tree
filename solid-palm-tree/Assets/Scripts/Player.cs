using UnityEngine;
//Created by: Charlotte Schofield
//AKA: Aquillis
//Note: Please add script to actual Player Script
//This code will NOT work otherwise!!


public class Player : MonoBehaviour
{
    //Activates the Stats class
    //and allows changes to occur in real-time
    [SerializeField]
    private Stats fuel;

    //Removed the common Start() as we need to have the vals in Fuel awake.
    private void Awake()
    {
        //Activate the bar with initilize
        fuel.Initilize();
    }

    // Update is called once per frame
    void Update()
    {
        //Activates when A key is pressed. Best use for the meter.
        //Note to self: do NOT change from this function!
        if(Input.GetKeyDown(KeyCode.Z))
        {
            fuel.CurrentVal -= 10f;
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
            fuel.CurrentVal += 10f;
        }
    }
}
