using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusClicker : MonoBehaviour, IClicker
{
    [SerializeField]
    private CinemachineVirtualCamera _camera;

    public void TriggerAction()
    {
        CameraManager.Instance.Push(_camera);
    }
}
