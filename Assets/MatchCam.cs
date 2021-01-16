using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MatchCam : MonoBehaviour
{

    public Camera referenceCam;

    private Vector3 initPos;
    private Vector3 refInitPos;
    void OnEnable()
    {
        if (referenceCam == null)
            return;

        initPos = Vector3.zero;
        refInitPos = referenceCam.transform.position;
        
    }
    
    
    void Update()
    {
        if (referenceCam == null)
            return;
        Quaternion q = referenceCam.transform.rotation;
        Vector3 v3 = q.eulerAngles;
        // Vector3 newV3 = new Vector3(v3.z, v3.y, -v3.x);
        
        transform.rotation = Quaternion.Euler(v3);

        transform.position = initPos + (referenceCam.transform.position - refInitPos);
    }
}
