using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public List<Light> affectedLights = new List<Light>();
    public bool isOn;

    public void UseFuse()
    {
        isOn = !isOn;
        foreach (Light light in affectedLights)
        {
            if(isOn)
            {
                light.intensity = 1;
            }
            else
            {
                light.intensity = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerAction>().fuseBoxInRange = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerAction pA = other.GetComponent<PlayerAction>();
            if(pA.fuseBoxInRange == this)
            {
                pA.fuseBoxInRange = null;
            }
        }
    }
}
