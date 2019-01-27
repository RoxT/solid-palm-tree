﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderMovementScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float upForce = 10f;
    [SerializeField]
    private float lateralMoveForce = 10f;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private ParticleSystem fire;
    private bool isFire;
    private AudioSource engineFlameSound;
    [SerializeField]
    private Transform cameraAnchor;
    [SerializeField]
    private float fuelLevel = 100f;
    [SerializeField]
    private float fuelBurnRate = 1f;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
        rb.centerOfMass = rb.centerOfMass - new Vector3(0, 1, 0);
        fire = transform.parent.GetComponentInChildren<ParticleSystem>();
        SetupCamera();
        engineFlameSound = transform.parent.GetComponentInChildren<AudioSource>();
    }

    void SetupCamera ()
    {
        Camera mainCamera = Camera.main;
        CameraFollowScript cfScript = mainCamera.gameObject.AddComponent<CameraFollowScript>();
        cfScript.InitOffsets(cameraAnchor);
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.up * upForce);
            fuelLevel -= fuelBurnRate * Time.deltaTime;
            if (!isFire)
            {
                fire.Play();
                engineFlameSound.Play();
                isFire = true;
            }
        } else {
            fire.Stop();
            engineFlameSound.Stop();
            isFire = false;
        }

        float hAxis = Input.GetAxis("Horizontal");
        if (hAxis != 0)
        {
            rb.AddForce(transform.right * hAxis * lateralMoveForce);
        }
        float vAxis = Input.GetAxis("Vertical");
        if (vAxis != 0)
        {
            rb.AddForce(transform.forward * vAxis * lateralMoveForce);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }
    }

    public float GetFuelLevel ()
    {
        return fuelLevel/100f;
    }
}
