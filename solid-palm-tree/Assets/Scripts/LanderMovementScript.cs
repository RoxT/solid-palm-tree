using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderMovementScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float upForce = 10f;
    [SerializeField]
    private float tiltTorque = .1f;
    private Vector3 startPosition;
    private Quaternion startRotation;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
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
        }
        float hAxis = Input.GetAxis("Horizontal");
        if (hAxis != 0)
        {
            rb.AddTorque(new Vector3(0, 0, -hAxis * tiltTorque));
        }
        float vAxis = Input.GetAxis("Vertical");
        if (vAxis != 0)
        {
            rb.AddTorque(new Vector3(vAxis * tiltTorque, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }
    }
}
