using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    float lookSensitivty = 4f;
    float lookSmoothDamp = .1f;
    float yCurrent;
    float yRotation;
    float yRotationV;
    float xCurrent;
    float xRotation;
    float xRotationV;

    public bool paused = false;

    public GameObject playerCameraCentre;
    public GameObject playerModel;

    public Player Player;

    void LateUpdate()
    {
        if (!paused)
        {
            xRotation += Input.GetAxis("Mouse X") * lookSensitivty;
            yRotation += Input.GetAxis("Mouse Y") * lookSensitivty;
        }

        yRotation = Mathf.Clamp(yRotation, -80, 80);

        xCurrent = Mathf.SmoothDamp(xCurrent, xRotation, ref xRotationV, lookSmoothDamp);
        yCurrent = Mathf.SmoothDamp(yCurrent, yRotation, ref yRotationV, lookSmoothDamp);

        transform.rotation = Quaternion.Euler(0, xCurrent, 0);
        playerCameraCentre.transform.rotation = Quaternion.Euler(-yCurrent, xCurrent, 0);
        playerModel.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
