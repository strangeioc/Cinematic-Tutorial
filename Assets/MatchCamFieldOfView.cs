using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class MatchCamFieldOfView : MonoBehaviour
{

    public Camera mainCam;
    private Camera myCam;

    void Start()
    {
        myCam = GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {
        if (mainCam == null)
            return;

        myCam.fieldOfView = mainCam.fieldOfView;
    }
}
