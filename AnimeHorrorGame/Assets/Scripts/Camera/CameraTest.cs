using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public GameObject target;
    void Update()
    {
        if (CameraLookingDetection.isRenderedByCamera(Camera.main, target))
        {
            Debug.Log("OMG ! I see " + target.name);
        }
    }
}
