using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    public GameObject tPlayer;
    public Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;
 
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }
 
    void Update()
    {
        if (tPlayer == null)
        {
            tPlayer = GameObject.FindWithTag("Player");
        }
        tFollowTarget = tPlayer.transform;
        vcam.LookAt = tFollowTarget;
        vcam.Follow = tFollowTarget;
    }
}
