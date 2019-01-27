using UnityEngine;
using UnityEngine.UI;

//Global Game Jam 2019
//Created by: Charlotte Schofield
//AKA: Aquillis

public class BarScript : MonoBehaviour
{
    //Allows the var to be manipulated outside the script
    //But doesn't allow people who haven't made the game to access it
    [SerializeField]
    private float fillAmount;

    //The Variable, unlike the above, stays private
    [SerializeField]
    private Image content;

    //Creating a get set var for MaxValue
    public float MaxValue { get; set; }

    //Changes the value of the Fill Amount
    public float Value
    {
        set
        {
            //Update the fillAmount here
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FuelBar();
    }

    //Holds the container for the bar
    private void FuelBar()
    {
        //Checks to see if the fill amount is different from the content
        if(fillAmount != content.fillAmount)
        {
            content.fillAmount = fillAmount;
        }
    }

    //Calculates the total of the bar
    //and uses the vals placed as a indicator for how much
    private float Map(float val, float inMin, float inMax,float outMin, float outMax)
    {
        return (val - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
        //Makes sure that the minimum value is not always 0
        //and allows for changes should there be upgrades
    }
}
