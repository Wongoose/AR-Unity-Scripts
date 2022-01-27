﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;


[RequireComponent(typeof(ARPlaneManager))]


public class PlaneDetectionToggle : MonoBehaviour
{
    private ARPlaneManager planeManager;
    [SerializeField]
    private Text toggleButtonText;

    private void Awake()
    {
        planeManager = GetComponent<ARPlaneManager>();
        toggleButtonText.text = "Disable";
    }

    public void TogglePlaneDetection()
    {
        // on click
        // toggle plane manager (prevent new planes to be created on top)
        planeManager.enabled = !planeManager.enabled;
        string toggleButtonMessage = "";

        // after toggled, set text for next click
        if (planeManager.enabled)
        {
            toggleButtonMessage = "Disable";
            SetAllPlanesActive(true);
        }
        else
        {
            toggleButtonMessage = "Enable";
            SetAllPlanesActive(false);
        }

        toggleButtonText.text = toggleButtonMessage;
    }

    private void SetAllPlanesActive(bool value)
    {
        foreach (var plane in planeManager.trackables)
        {
            plane.gameObject.SetActive(value);
        }
    }
}
