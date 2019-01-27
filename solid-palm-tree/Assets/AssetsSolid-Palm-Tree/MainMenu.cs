using UnityEngine;
using UnityEngine.SceneManagement;

//Created By: Charlotte Schofield
//AKA: Aquillis
//Note: Remind me to watch more vids on making a Menu.
//Will be needing it.

public class MainMenu : MonoBehaviour
{

    //Note - There needs to be an distinction between the New Game
    //And the Load Game.
    public void PlayNewGame()
    {
        //Gets the NEXT scene in the queue
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        //Use this to test if the application has succeded
        Debug.Log("The Game is Finished");
        Application.Quit();
    }
}
