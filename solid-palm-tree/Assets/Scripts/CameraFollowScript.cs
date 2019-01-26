using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {
    [SerializeField]
    private Transform landerTransform;
    [SerializeField]
    private Vector3 positionOffset;

	void Start () {
        positionOffset = landerTransform.position - transform.position;
	}

    void LateUpdate ()
    {
        transform.position = landerTransform.position - positionOffset;
    }
}
