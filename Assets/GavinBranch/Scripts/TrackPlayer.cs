using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    Cinemachine.CinemachineVirtualCamera c_VirtualCam;

    private void Awake()
    {
        c_VirtualCam = this.GetComponent<Cinemachine.CinemachineVirtualCamera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        Transform target = GameObject.Find("Player").transform;
        c_VirtualCam.m_LookAt = target;
        c_VirtualCam.m_Follow = target;
    }
}
