using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematics : MonoBehaviour
{
    public GameObject Kamera;

    public GameObject Head;
    public GameObject Torso;
    public GameObject Waist;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if ()
        //{
            
        //}
        //else
        //{
            Head.transform.rotation = Kamera.transform.rotation;
        //}
    }
}
