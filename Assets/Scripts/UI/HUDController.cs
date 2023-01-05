using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    int state;
    public GameObject PlayObjects;
    public GameObject InventoryObjects;
    public GameObject PauseObjects;
    //0 is playing, 1 is viewing inventory, 2 is pausing game, 3 is UI off

    public Player Player;
    public PlayerMovement PlayerMovement;
    public MouseLook MouseLook;

    void Start()
    {
        PlayObjects.SetActive(true);
        InventoryObjects.SetActive(false);
        PauseObjects.SetActive(false);
        state = 0;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Player.PlayerPreferences.inventory.Any(i => Input.GetKey(i)))
        {
            if (state == 0)
            {
                PlayObjects.SetActive(false);
                InventoryObjects.SetActive(true);
                state = 1;
                Cursor.visible = true;
                PlayerMovement.paused = true;
                MouseLook.paused = true;
            }
            else if (state == 1)
            {
                PlayObjects.SetActive(true);
                InventoryObjects.SetActive(false);
                PauseObjects.SetActive(false);
                state = 0;
                Cursor.visible = false;
                PlayerMovement.paused = false;
                MouseLook.paused = false;
            }
        }
        else if (Player.PlayerPreferences.pauseEscape.Any(i => Input.GetKey(i)))
        {
            if (state == 0)
            {
                PlayObjects.SetActive(false);
                PauseObjects.SetActive(true);
                Time.timeScale = 0;
                state = 2;
                Cursor.visible = true;
            }
            else
            {
                PlayObjects.SetActive(true);
                InventoryObjects.SetActive(false);
                PauseObjects.SetActive(false);
                Cursor.visible = false;
                Time.timeScale = 1;
                PlayerMovement.paused = false;
                MouseLook.paused = false;
                state = 0;
            }
        }
        else if (Player.PlayerPreferences.hideUI.Any(i => Input.GetKey(i)))
        {
            if (state == 3)
            {
                PlayObjects.SetActive(true);
                state = 0;
            }
            else if (state == 0)
            {
                PlayObjects.SetActive(false);
                InventoryObjects.SetActive(false);
                PauseObjects.SetActive(false);

                state = 3;
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}