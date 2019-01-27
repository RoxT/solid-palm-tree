using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//Created by: Charlotte Schofield
//AKA: Aquillis
//Note: Would we have enough time to add an options menu into the Pause Menu?

public class SettingsMenu : MonoBehaviour
{
    //Script for the Controls menu
    //Maybe rename it to 'settings' instead?

    //For the Volume of the Music
    public AudioMixer mixar;

    //Get the dropdown
    public Dropdown resolutionDropdown;

    //Gets the # of resolutions
    Resolution[] resols;

    private void Start()
    {
        //Gets the resolutions
        resols = Screen.resolutions;

        //Gets the dropdown currently to clear
        resolutionDropdown.ClearOptions();

        //Change the Resolutions to a array for Strings
        List<string> options = new List<string>();

        //For the current resolution finding
        int currentResolIndex = 0;

        //Sort through list
        for(int i = 0; i < resols.Length; i++)
        {
            string option = resols[i].width + " x " + resols[i].height;
            options.Add(option);

            if(resols[i].width == Screen.currentResolution.width &&
                resols[i].height == Screen.currentResolution.height)
            {
                currentResolIndex = i;
            }
        }

        //Add the found options to the resolution dropdown
        resolutionDropdown.AddOptions(options);
        //Make sure the width & height match the actual computer!
        resolutionDropdown.value = currentResolIndex;
        //Make sure it's the ACTUAL Value!
        resolutionDropdown.RefreshShownValue();
    }

    //Make the automatic fullscreen avaliable
    public void SetResolution (int resIndex)
    {
        //Add the resolution to the function
        Resolution resol = resols[resIndex];
        //Change the variables for each area
        Screen.SetResolution(resol.width, resol.height, Screen.fullScreen);
    }

    //Add the control for the volume
    public void VolumeSlider(float volume)
    {
        //Sets up the Volume Controls. Easy!
        mixar.SetFloat("Volume", volume);
    }

    //Sets the game to become fullscreen
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}
