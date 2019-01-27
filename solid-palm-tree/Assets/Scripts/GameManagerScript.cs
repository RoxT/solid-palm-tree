using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField]
    private int finalSceneIndex = 3;
    [SerializeField]
    private Camera wideViewCamera;
    [SerializeField]
    private float endToTransitionTime = 3f;
    private bool hitEndCondition = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //hacky count down (who needs coroutines?)
        if (hitEndCondition)
        {
            if (endToTransitionTime <= 0)
            {
                // Delay until trees finish display
                // Transition to final scene
                SceneManager.LoadScene(3);
            } else
            {
                endToTransitionTime -= Time.deltaTime;
            }
        }
    }

    public void LanderOutOfFuel ()
    {
        // Transition to wide view
        Camera.main.enabled = false;
        wideViewCamera.enabled = true;
        hitEndCondition = true;
    }
}
