using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour {
    [SerializeField]
    private Transform landerTransform;
    [SerializeField]
    private Vector3 positionOffset;
    [SerializeField]
    private Vector3 cameraPosOffset = new Vector3(0, -3, 7);
    [SerializeField]
    private Quaternion cameraRotOffset = Quaternion.Euler(18, 0, 0);

    void LateUpdate ()
    {
        if (landerTransform != null)
        {
            transform.position = landerTransform.position - positionOffset;
        }
    }

    public void InitOffsets (Transform landerTransform)
    {
        this.landerTransform = landerTransform;
        positionOffset = landerTransform.position - transform.position;
        transform.SetPositionAndRotation(transform.position + cameraPosOffset, cameraRotOffset);
    }
}
