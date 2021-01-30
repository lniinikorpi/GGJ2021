using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public FuseBox fuseBoxInRange;
    public int fuseCount = 0;
    public GameObject fuse;
    public GameObject playerLightObject;
    Light playerLight;
    float playerLightIntensity;

    void Start()
    {
        playerLight = playerLightObject.GetComponent<Light>();
        playerLightIntensity = playerLight.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnUse()
    {
        Use();
    }

    void Use()
    {
        if(fuseBoxInRange != null)
        {
            if(fuseBoxInRange.isOn)
            {
                fuseCount++;
                fuse.SetActive(true);

                playerLight.intensity = playerLightIntensity;
            }
            else
            {
                if(fuseCount > 0)
                {
                    fuseCount--;
                    fuse.SetActive(false);
                }
                else
                {
                    return;
                }
                playerLight.intensity = 0;
            }
            fuseBoxInRange.UseFuse();
        }
    }

    public void OnMap()
    {
        Map();
    }

    private void Map()
    {
        UIManager.instance.ToggleMap();
    }
}
