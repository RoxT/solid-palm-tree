using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableBranch : MonoBehaviour {


    public Material[] glow;
    private Material[] normalMaterials;
    private MeshRenderer meshRenderer;
    private bool cuttable;
    private Rigidbody branchRigidbody;
    [SerializeField]
    private AudioClip[] treeSounds = new AudioClip[4];
    private AudioSource audioSource;

    // Use this for initialization
    void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        normalMaterials = meshRenderer.materials;
        cuttable = false;
        branchRigidbody = GetComponent<Rigidbody>();
        branchRigidbody.isKinematic = true;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (cuttable == true && Input.GetKeyDown(KeyCode.X) == true)
        {
            branchRigidbody.isKinematic = false;
            if (audioSource != null)
            {
                audioSource.clip = treeSounds[Random.Range(0, 4)];
                audioSource.Play();
                waitAudio(audioSource);
                audioSource = null;
            }
        }
	}

    private IEnumerator waitAudio(AudioSource audioSource)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        Destroy(audioSource);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CutterTrigger")
        {
            meshRenderer.materials = glow;
            cuttable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CutterTrigger")
        {
            meshRenderer.materials = normalMaterials;
            cuttable = false;
        }
    }
}
