using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public Light dirLight;
    void Start()
    {
        
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
        if(dirLight.intensity == 0)
        {
            dirLight.intensity = 1;
        }
        else
        {
            dirLight.intensity = 0;
        }
    }
}
