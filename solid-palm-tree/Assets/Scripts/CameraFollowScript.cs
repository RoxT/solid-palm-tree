using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {
    [SerializeField]
    private Transform landerTransform;

    void LateUpdate ()
    {
        if (landerTransform != null)
        {
            transform.position = landerTransform.position;
            transform.rotation = landerTransform.rotation;
        }
    }

    public void InitOffsets (Transform landerTransform)
    {
        this.landerTransform = landerTransform;
    }
}
