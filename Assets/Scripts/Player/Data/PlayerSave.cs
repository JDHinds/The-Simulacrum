using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSave
{
    public Inventory inventory;
    public Vector3 position;
    public Vector3 rotation;

    float healthBody;
    float healthMind;
    float healthSoul;

    public PlayerSave()
    { }

    public float HealthBody
    {
        get { return healthBody; }
        set { healthBody = value; }
    }
}
