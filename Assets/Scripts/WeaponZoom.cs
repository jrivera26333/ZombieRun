using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] Camera playerCamera;
    [SerializeField] RigidbodyFirstPersonController rigidbodyFirstPersonController;
    [SerializeField] float zoomIn = 20f;
    [SerializeField] float zoomOut = 60f;

    [SerializeField] float zoomOutSensitivity = 2f;
    [SerializeField] float zoomInSensitivity = .5f;

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
                rigidbodyFirstPersonController.mouseLook.XSensitivity = zoomInSensitivity;
                rigidbodyFirstPersonController.mouseLook.YSensitivity = zoomInSensitivity;
            }
            else
            {
                isToggled = false;
                playerCamera.fieldOfView = zoomOut;
                rigidbodyFirstPersonController.mouseLook.XSensitivity = zoomOutSensitivity;
                rigidbodyFirstPersonController.mouseLook.YSensitivity = zoomOutSensitivity;
            }

        }
    }
}
