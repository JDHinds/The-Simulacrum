using UnityEngine;
using UnityEngine.Localization.Settings;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class Player : MonoBehaviour
{
    public PlayerPreferences PlayerPreferences;
    public PlayerSave PlayerSave;

    void Start()
    {
        LoadPlayerPreferences();
        if (PlayerPreferences.controlsSet == false || true)
        {
            PlayerPreferences.LoadDefaults();
        }
        LocalizationSettings.SelectedLocale.Identifier = PlayerPreferences.language;
        Screen.SetResolution(PlayerPreferences.resolution.width, PlayerPreferences.resolution.height, PlayerPreferences.fullScreen);
    }

    public void SavePlayerPreferences()
    {
        FileStream fileStream = new FileStream(Application.persistentDataPath + "/preferences.json", FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(PlayerPreferences);
        }
    }

    public PlayerPreferences LoadPlayerPreferences()
    {
        if (File.Exists(Application.persistentDataPath + "/preferences.json"))
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/preferences.json"))
            {
                PlayerPreferences i = new PlayerPreferences();
                string j = reader.ReadToEnd();
                JsonUtility.FromJsonOverwrite(j, i);

                return i;
            }
        }
        else 
        {
            PlayerPreferences i = new PlayerPreferences();
            i.LoadDefaults();
            return i;
        }      
    }

    public void SavePlayerSave()
    {
        FileStream fileStream = new FileStream(Application.persistentDataPath + "/save.json", FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(PlayerSave);
        }
    }

    public PlayerSave LoadPlayerSave()
    {
        if (File.Exists(Application.persistentDataPath + "/save.json"))
        {
            using (StreamReader reader = new StreamReader(Application.persistentDataPath + "/save.json"))
            {
                PlayerSave i = new PlayerSave();
                string j = reader.ReadToEnd();
                JsonUtility.FromJsonOverwrite(j, i);

                return i;
            }
        }
        else
        {
            PlayerSave i = new PlayerSave();
            return i;
        }
    }
}