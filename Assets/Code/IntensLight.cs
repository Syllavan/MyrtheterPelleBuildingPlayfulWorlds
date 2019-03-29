using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensLight : MonoBehaviour
{

    public GameObject Light;
    private bool on = false;



    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Light.SetActive(true);
            on = true;
        }
    }
}