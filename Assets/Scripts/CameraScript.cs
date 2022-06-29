using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform BGTransform;


    private Vector3 CamPosition_BG;
    private void Start()
    {
        CamPosition_BG = new Vector3(-2.1f, 0, -5);
    }
    void FixedUpdate()
    {

        BGTransform.position = transform.position - CamPosition_BG;

    }
}
