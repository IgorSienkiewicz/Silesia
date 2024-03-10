using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI : MonoBehaviour
{
    [field: SerializeField]
    public CinemachineVirtualCamera PoiCamera { get; private set; }
/*
    [SerializeField] private LayerMask enabledLayers;
    [SerializeField] private LayerMask disabledLayers;*/

    [SerializeField] private GameObject marker;

    [SerializeField] private Collider targetCollider;
    [SerializeField] private POI[] nextPois;

    private void Awake()
    {
        Disable();
    }

    private void Enable()
    {
        /*targetCollider.excludeLayers = 0;
        targetCollider.includeLayers = enabledLayers.value;*/
        targetCollider.gameObject.layer = 6;
        marker.SetActive(true);
    }
    
    private void Disable()
    {
        //targetCollider.layerOverridePriority = disabledLayers.value;
        targetCollider.gameObject.layer = 0;
        //targetCollider.includeLayers = 0;
        marker.SetActive(false);
    }

    public void Arrive()
    {
        PoiCamera.enabled = true;
        foreach (var poi in nextPois)
        {
            poi.Enable();
        }
    }

    public void Depart()
    {
        PoiCamera.enabled = false;
        foreach (var poi in nextPois)
        {
            poi.Disable();
        }
    }
}
