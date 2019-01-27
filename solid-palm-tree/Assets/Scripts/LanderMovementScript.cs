using System.Collections;
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
        cfScript.InitOffsets(transform);
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
            rb.AddForce(new Vector3(hAxis * lateralMoveForce, 0, 0));
        }
        float vAxis = Input.GetAxis("Vertical");
        if (vAxis != 0)
        {
            rb.AddForce(new Vector3(0, 0, vAxis * lateralMoveForce));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }
    }
}
