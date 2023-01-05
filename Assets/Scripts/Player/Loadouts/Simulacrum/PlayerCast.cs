using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerCast : MonoBehaviour
{
    public GameObject prefab;

    public Player Player;

    bool casting;
    List<GameObject> activeSpells;
    List<Vector3> activeSpellsDestinations;

    void Start()
    {
        activeSpells = new List<GameObject>();
        activeSpellsDestinations = new List<Vector3>();
    }
    void Update()
    {
        if (!Player.PlayerPreferences.holdCast)
        {
            if (Player.PlayerPreferences.cast.Any(i => Input.GetKey(i)))
            {
                if (casting)
                { 
                    casting = false;
                    CreateSpell();
                }
                else
                { 
                    casting = true; 
                }
            }
        }
        else if (Player.PlayerPreferences.holdCast)
        {
            if (Player.PlayerPreferences.cast.Any(i => Input.GetKey(i)))
            { 
                casting = true; 
            }
            else if (Player.PlayerPreferences.cast.Any(i => Input.GetKey(i)))
            { 
                casting = false;
                CreateSpell();
            }
        }

        if (casting)
        { 
            
        }

        for (int i = activeSpells.Count - 1; i > -1 ; i--)
        {
            activeSpells[i].transform.position = Vector3.MoveTowards(activeSpells[i].transform.position, activeSpellsDestinations[i], 1f);
            if (activeSpells[i].transform.position == activeSpellsDestinations[i])
            {
                Destroy(activeSpells[i]);
                activeSpells.RemoveAt(i);
                activeSpellsDestinations.RemoveAt(i);
            }
        }
    }

    private void CreateSpell()
    {
        Ray ray = new(transform.position, transform.forward);

        GameObject i = Instantiate(prefab, ray.GetPoint(0f), transform.rotation);
        activeSpells.Add(i);
       
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            activeSpellsDestinations.Add(hit.point);
        }
        else
        {
            activeSpellsDestinations.Add(ray.GetPoint(20f));
        }
    }
}
