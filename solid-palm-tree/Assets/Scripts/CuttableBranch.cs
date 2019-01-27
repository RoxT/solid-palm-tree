using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableBranch : MonoBehaviour {


    public Material[] glow;
    private Material[] normalMaterials;
    private MeshRenderer meshRenderer;
    private bool cuttable;
    private Rigidbody branchRigidbody;
    
    // Use this for initialization
    void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        normalMaterials = meshRenderer.materials;
        cuttable = false;
        branchRigidbody = GetComponent<Rigidbody>();
        branchRigidbody.isKinematic = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (cuttable == true && Input.GetKeyDown(KeyCode.X) == true)
        {
            branchRigidbody.isKinematic = false;
        }
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
