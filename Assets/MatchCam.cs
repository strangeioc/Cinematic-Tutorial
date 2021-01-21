using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MatchCam : MonoBehaviour
{

    public Camera referenceCam;
    public Transform referenceTransform;
    public bool matchTranslation = true;
    public bool matchRotation = true;

    //private Vector3 referencePosition;
    // private Vector3 refInitPos;

    void OnEnable()
    {
        if (referenceCam == null || referenceTransform == null)
            return;

        //referencePosition = referenceTransform.position;
        // refInitPos = referenceCam.transform.position;
    }
    
    
    void LateUpdate()
    {
        if (referenceCam == null || referenceTransform == null)
            return;

        if (matchRotation)
        {
            Quaternion q = referenceCam.transform.rotation * Quaternion.Inverse(referenceTransform.rotation);
            Vector3 v3 = q.eulerAngles;
            transform.rotation = Quaternion.Euler(v3);
        }
        
        if (matchTranslation)
        {
            Vector3 move = referenceTransform.position - referenceCam.transform.position;
            Vector3 direction = referenceTransform.rotation * (Vector3.forward);

            transform.position = Quaternion.Euler(direction) * move;

        }

        Debug.Log("new: " + referenceCam.transform.position);
    }
}
