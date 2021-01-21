using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Animator))]
public class FKCrane : MonoBehaviour
{
    public float standHeight = 1f;
    public float armLength = 3f;
    public Vector3 armOrientation = Vector3.forward;

    public GameObject standBase;
    public GameObject armBase;
    public GameObject camAttachmentPoint;

    private Transform[] standPieces;
    private Transform[] armPieces;
    

    void Start()
    {
        if (standBase == null || armBase == null)
            return;

        int standChildren = standBase.transform.childCount;
        int armChildren = armBase.transform.childCount;
        
        standPieces = new Transform[standChildren];
        for (int a = 0; a < standChildren; a++)
        {
            standPieces[a] = standBase.transform.GetChild(a);
        }
        
        armPieces = new Transform[armChildren];
        for (int a = 0; a < armChildren; a++)
        {
            armPieces[a] = armBase.transform.GetChild(a);
        }
    }

    void LateUpdate()
    {
        // Move and rotate the arm
        armBase.transform.localPosition = new Vector3(0, standHeight, 0);
        armBase.transform.rotation = Quaternion.Euler(armOrientation);
        
        Vector3 direction = armBase.transform.rotation * (Vector3.up);
        camAttachmentPoint.transform.localPosition = armBase.transform.localPosition + (direction * armLength);
        
        // Space out the segments of the base
        int standCount = standPieces.Length;
        float standSegmentLength = (standHeight / standCount);
        for (int a = 0; a < standCount; a++)
        {
            Vector3 newPos = new Vector3(0f, standSegmentLength * a, 0f);
            standPieces[a].localPosition = newPos;
        }
        
        // Space out the segments of the arm
        int armCount = armPieces.Length;
        float armSegmentLength = (armLength / armCount);
        for (int a = 0; a < armCount; a++)
        {
            Vector3 newPos = new Vector3(0f, armSegmentLength * a, 0f);
            armPieces[a].localPosition = newPos;
        }
    }
}
