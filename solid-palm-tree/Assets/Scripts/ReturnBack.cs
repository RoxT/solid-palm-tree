using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Created by: Charlotte Schofield
//Aka: Aquillis
//Blossom Wave is also mine
//I'm actually happy with what I did with it

public class ReturnBack : MonoBehaviour
{
    //Return to MenuScreen
    public void TurnBack()
    {
        //Gets the NEXT scene in the queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
