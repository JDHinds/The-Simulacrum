using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroLook : MonoBehaviour
{
    public Player player;
    private Gyroscope gyro;
    private bool gyroSupported;

    public GameObject playerCameraCentre;
    public GameObject playerModel;

    private void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gyroSupported = true;
            gyro = Input.gyro;
            gyro.enabled = true;
        }
    }

    void Update()
    {
        if (player.PlayerPreferences.gyroEnabled && gyroSupported)
        {
            transform.rotation = Quaternion.Euler(0, gyro.attitude.x, 0);
            playerCameraCentre.transform.rotation = Quaternion.Euler(-gyro.attitude.y, gyro.attitude.x, 0);
            playerModel.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
