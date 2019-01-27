using UnityEngine;
using UnityEngine.SceneManagement;

//Created By: Charlotte Schofield
//AKA: Aquillis

//Note: Make sure everything else works properly!

public class PauseMenu : MonoBehaviour
{
    //Checks to see if game is paused
    public static bool GameIsPaused = false;

    //Controls the UI for Pausing
    public GameObject pausingMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Checks the bool to see if game is paused
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    //Method for resuming the game
    public void Resume ()
    {
        //Deactivate the UI for pausing
        pausingMenuUI.SetActive(false);
        //For Resuming time
        Time.timeScale = 1f;
        //changes bool to false
        GameIsPaused = false;
    }
    //method for pausing
    private void Pause ()
    {
        //activate the UI for pausing
        pausingMenuUI.SetActive(true);
        //For Freezing time
        Time.timeScale = 0f;
        //changes bool to true
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        //Make sure that this isn't deleted, otherwise it's softlocked!
        Time.timeScale = 1f;
        //Note: Get this removed & given it's own var later
        SceneManager.LoadScene("Menu");
    }

    public void CloseGame()
    {
        //As it's still being built, it will do nothing for now.
        Debug.Log("Game Closed...");
        Application.Quit();
    }
}
