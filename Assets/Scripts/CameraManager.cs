using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance { get; private set; }

    private Stack<CinemachineVirtualCamera> cameras;

    [SerializeField]
    private CinemachineVirtualCamera mainCam;
    [SerializeField]
    private CinemachineBrain brain;

    private void Start()
    {
        Assert.IsNull(Instance);
        Instance = this;
        cameras = new Stack<CinemachineVirtualCamera>();
        InputManager.Instance.OnBack += Pop;
        Push(mainCam);
    }

    public void Push(CinemachineVirtualCamera cam)
    {
        if (cameras.Count > 0)
        {
            var prev = cameras.Peek();
            prev.enabled = false;
        }
        cameras.Push(cam);
        cam.enabled = true;
    }

    public void Pop()
    {
        if (brain.IsBlending)
        {
            Debug.Log("Already Moving");
            return;
        }
        if (cameras.Count > 1)
        {
            cameras.Pop().enabled = false;
            cameras.Peek().enabled = true;
        }
        else
        {
            Debug.Log("Attempting to Pop last camera");
        }
    }
}
