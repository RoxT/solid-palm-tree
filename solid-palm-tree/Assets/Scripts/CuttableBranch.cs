using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttableBranch : MonoBehaviour {

    public Material glow;
    private Material normalMaterial;
    private MeshRenderer meshRenderer;
    private bool cuttable;
    private Rigidbody branchRigidbody;


	// Use this for initialization
	void Start () {
        meshRenderer = GetComponent<MeshRenderer>();
        normalMaterial = meshRenderer.material;
        cuttable = false;
        branchRigidbody = GetComponent<Rigidbody>();
        branchRigidbody.isKinematic = true;
    }
	
	// Update is called once per frame
	void Update () {
		if (cuttable == true && Input.GetKeyDown(KeyCode.X) == true)
        {
            GetComponent<FixedJoint>().breakForce = 0;
            GetComponent<FixedJoint>().breakTorque = 0;
            branchRigidbody.isKinematic = false;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CutterTrigger")
        {
            meshRenderer.material = glow;
            cuttable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "CutterTrigger")
        {
            meshRenderer.material = normalMaterial;
            cuttable = false;
        }
    }
}
