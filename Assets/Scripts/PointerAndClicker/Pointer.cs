using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField]
    private LayerMask mask;

    void Start()
    {
        InputManager.Instance.OnInteract += Interact;
    }

    public void Interact()
    {
        //TODO Chck If we can interact

        if(Physics.Raycast(
            Camera.main.ScreenPointToRay(
                InputManager.Instance.MousePositiotn
                ),
            out var hit,
            float.PositiveInfinity,
            mask.value))
        {
            var clicker = hit.collider.GetComponent<IClicker>();

            if (clicker.Equals(null))
            {
                return;
            }

            clicker.TriggerAction();
        }
    }
}
