using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VR_Map
{
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset); 
    }

}

public class VRrig : MonoBehaviour
{
    public VR_Map head;
    public VR_Map leftHand;
    public VR_Map rightHand;

    public  Transform headconstraints;
    public Vector3 headBodyOffest;

    public float turnSmoothness { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        headBodyOffest = transform.position - headconstraints.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = headconstraints.position 
            + headBodyOffest;
        transform.forward = Vector3.Lerp(transform.forward,
            Vector3.ProjectOnPlane(headconstraints.up,Vector3.up).normalized,Time.deltaTime * turnSmoothness);
              

        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
