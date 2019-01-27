using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanderFuelScript : MonoBehaviour {

    [SerializeField]
    private float fuelLevel;
    [SerializeField]
    private GameObject lander;
    private LanderMovementScript lms;
    [SerializeField]
    private Image fillImage;

	// Use this for initialization
	void Start () {
        fillImage = GetComponent<Image>();
        lms = lander.GetComponentInChildren<LanderMovementScript>();
	}
	
	// Update is called once per frame
	void Update () {
        fuelLevel = lms.GetFuelLevel();
        fillImage.fillAmount = fuelLevel;
    }
}
