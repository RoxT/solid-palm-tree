using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platoform : MonoBehaviour
{
    private MeshRenderer[] houses = new MeshRenderer[8];
    private bool activated;
    private ParticleSystem flowers;

    // Start is called before the first frame update
    void Start()
    {
        MeshRenderer[] allRenderers = GetComponentsInChildren<MeshRenderer>();
        activated = false;
        for (int i = 1; i < allRenderers.Length; i++)
        {
            allRenderers[i].enabled = false;
            houses[i-1] = allRenderers[i];
        }

        flowers = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name);


        if (collision.gameObject.tag == "Player")
        {
            flowers.Play();
            if (activated == true)
            {
                return;
            }
            foreach (MeshRenderer house in houses)
            {
                house.enabled = true;
                activated = true;
            }
        }
    }
}
