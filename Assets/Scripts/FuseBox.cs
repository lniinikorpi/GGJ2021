using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public Transform affectedLights;
    public bool isOn;
    public bool firstFuse = false;

    private void Start()
    {
        if(!firstFuse)
        {
            isOn = false;
            UseLights();
        }
    }

    public void UseFuse()
    {
        isOn = !isOn;
        UseLights();
    }

    private void UseLights()
    {
        List<Light> lights = affectedLights.GetComponentsInChildren<Light>().ToList();
        foreach (Light light in lights)
        {
            if (isOn)
            {
                if(light.type == LightType.Directional)
                {
                    light.intensity = .3f;
                }
                else
                {
                    light.intensity = 4.7f;
                }
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
