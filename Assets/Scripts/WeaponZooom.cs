using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZooom : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] float zoomIn = 20f;
    [SerializeField] float zoomOut = 60f;

    bool isToggled;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(isToggled == false)
            {
                isToggled = true;
                playerCamera.fieldOfView = zoomIn;
            }
            else
            {
                isToggled = false;
                playerCamera.fieldOfView = zoomOut;
            }

        }
    }
}
