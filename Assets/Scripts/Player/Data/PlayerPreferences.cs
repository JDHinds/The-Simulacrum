using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;

[System.Serializable]
public class PlayerPreferences
{
    public bool controlsSet = false;

    public List<KeyCode> forward;
    public List<KeyCode> left;
    public List<KeyCode> backward;
    public List<KeyCode> right;

    public List<KeyCode> jump;
    public List<KeyCode> sprint;
    public bool holdSprint;

    public List<KeyCode> cast;
    public bool holdCast;
    public List<KeyCode> castUp;
    public List<KeyCode> castLeft;
    public List<KeyCode> castDown;
    public List<KeyCode> castRight;

    public List<KeyCode> inventory;
    public List<KeyCode> pauseEscape;
    public List<KeyCode> hideUI;

    public bool gyroEnabled;

    public Resolution resolution;
    public bool fullScreen;

    public string language;
    public List<string> pronounsSubjective = new List<string>();
    public List<string> pronounsObjective = new List<string>();
    public List<string> pronounsPossessive = new List<string>();

    public void LoadDefaults()
    {
        forward = new List<KeyCode>();
        forward.Add(KeyCode.W);
        left = new List<KeyCode>();
        left.Add(KeyCode.A);
        backward = new List<KeyCode>();
        backward.Add(KeyCode.S);
        right = new List<KeyCode>();
        right.Add(KeyCode.D);

        jump = new List<KeyCode>();
        jump.Add(KeyCode.Space);
        sprint = new List<KeyCode>();
        sprint.Add(KeyCode.LeftControl);
        holdSprint = true;

        cast = new List<KeyCode>();
        cast.Add(KeyCode.LeftShift);
        holdCast = true;
        castUp = new List<KeyCode>();
        castUp.Add(KeyCode.UpArrow);
        castLeft = new List<KeyCode>();
        castLeft.Add(KeyCode.LeftArrow);
        castDown = new List<KeyCode>();
        castDown.Add(KeyCode.DownArrow);
        castRight = new List<KeyCode>();
        castRight.Add(KeyCode.RightArrow);

        inventory = new List<KeyCode>();
        inventory.Add(KeyCode.Tab);
        pauseEscape = new List<KeyCode>();
        pauseEscape.Add(KeyCode.Escape);
        hideUI = new List<KeyCode>();
        hideUI.Add(KeyCode.F1);

        gyroEnabled = true;

        resolution = Screen.resolutions[0];

        if (LocalizationSettings.AvailableLocales.GetLocale(Application.systemLanguage.ToString("G")))
        {
            language = Application.systemLanguage.ToString("D"); //Format String can be only "G", "g", "X", "x", "F", "f", "D" or "d".
        }
        else
        {
            language = "en";
        }

        pronounsSubjective = new List<string>();
        pronounsSubjective.Add("they");
        pronounsObjective = new List<string>();
        pronounsObjective.Add("them");
        pronounsPossessive = new List<string>();
        pronounsPossessive.Add("theirs");
    }
}
