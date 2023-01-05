using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionControl : MonoBehaviour
{
    public TMP_Dropdown drpResolutions;
    public Toggle chkFullscreen;

    public Player Player;

    //bool currentlyRebinding = false;

    void Start()
    {
        drpResolutions.AddOptions(GetResolutions());
        int i = FindCurrentResolution();
        drpResolutions.value = i;
        drpResolutions.options[i].text += " (Current)";
    }

    void Update()
    {
        
    }

    private List<string> GetResolutions()
    {
        List<string> i = new List<string>();
        Resolution[] j = Screen.resolutions;

        for (int k = 0; k < j.Length; k++)
        {
            i.Add(j[k].ToString());
        }

        return i;
    }

    private int FindCurrentResolution()
    {
        for (int i = 0; i < Screen.resolutions.Length; i++)
        {
            if (Screen.resolutions[i].ToString() == Screen.currentResolution.ToString())
            {
                return i;
            }
        }
        return 0;
    }

    private void SetResolutions()
    {
        Screen.SetResolution(Screen.resolutions[drpResolutions.value].width, Screen.resolutions[drpResolutions.value].height, chkFullscreen.isOn);
    }
}
