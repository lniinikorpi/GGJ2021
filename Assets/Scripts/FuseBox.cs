using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FuseBox : MonoBehaviour
{
    public Transform affectedLights;
    public Transform fuseboxLights;
    public GameObject keyInfo;
    public GameObject fuseActive;
    public bool isOn;
    public bool firstFuse = false;

    public GameObject bulb;
    public MeshRenderer bulbMeshRenderer;
    Material fuseboxActiveMaterial;
    Material fuseboxInactiveMaterial;
    Color fuseboxInactiveColor;
    Color fuseboxActiveColor;


    private void Start()
    {
        if(!firstFuse)
        {
            isOn = false;
            UseLights(affectedLights);
            UseLights(fuseboxLights);
        }

        keyInfo.SetActive(false);
        keyInfo.transform.rotation = Quaternion.Euler(keyInfo.transform.rotation.eulerAngles.x, 360 - transform.rotation.y, keyInfo.transform.rotation.z);

        fuseboxActiveMaterial = Resources.Load<Material>("FuseboxActiveMaterial");
        fuseboxActiveColor = fuseboxActiveMaterial.GetColor("_EmissionColor");

        fuseboxInactiveMaterial = Resources.Load<Material>("FuseboxInactiveMaterial");
        fuseboxInactiveColor = fuseboxInactiveMaterial.GetColor("_EmissionColor");

        bulbMeshRenderer = bulb.GetComponent<MeshRenderer>();
    }

    public void UseFuse()
    {
        isOn = !isOn;
        EnableFuse();
        UseLights(affectedLights);
        UseLights(fuseboxLights);
    }

    private void EnableFuse()
    {
        fuseActive.SetActive(isOn);
        if (isOn)
        {
            bulbMeshRenderer.material.SetColor("_EmissionColor", fuseboxActiveColor);
        } else
        {
            bulbMeshRenderer.material.SetColor("_EmissionColor", fuseboxInactiveColor);
        }
    }

    private void UseLights(Transform affectedLights)
    {
        List<Light> lights = affectedLights.GetComponentsInChildren<Light>().ToList();
        foreach (Light light in lights)
        {
            if (isOn)
            {
                light.intensity = 7f;
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
