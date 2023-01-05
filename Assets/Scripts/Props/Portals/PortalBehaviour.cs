using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
    public PortalBehaviour pairedPortal;
    public Camera portalCamera;
    
    Camera playerCamera;
    RenderTexture renderTexture;

    void Start()
    {
        playerCamera = Camera.current;
        renderTexture = new RenderTexture(512, 512, 16);
        portalCamera.targetTexture = renderTexture;
        GetComponent<Renderer>().material.mainTexture = renderTexture;
    }

    void Update()
    {
        if (playerCamera != Camera.current)
        { playerCamera = Camera.current; }
        if (GetComponent<Renderer>().isVisible)
        {
            portalCamera.enabled = true;
        }
        else
        { portalCamera.enabled = false; }
    }
}
