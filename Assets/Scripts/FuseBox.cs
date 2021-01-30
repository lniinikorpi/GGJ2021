using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public Transform affectedLights;
    public GameObject keyInfo;
    public bool isOn;
    public bool firstFuse = false;

    private void Start()
    {
        if(!firstFuse)
        {
            isOn = false;
            UseLights();
        }
        keyInfo.SetActive(false);
        keyInfo.transform.rotation = Quaternion.Euler(keyInfo.transform.rotation.eulerAngles.x, 360 - transform.rotation.y, keyInfo.transform.rotation.z);
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
                light.intensity = 20f;
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
            keyInfo.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerAction pA = other.GetComponent<PlayerAction>();
            if(pA.fuseBoxInRange == this)
            {
                keyInfo.SetActive(false);
                pA.fuseBoxInRange = null;
            }
        }
    }
}
