using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public FuseBox fuseBoxInRange;
    public int fuseCount = 0;
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
        if(fuseBoxInRange != null)
        {
            if(fuseBoxInRange.isOn)
            {
                fuseCount++;
            }
            else
            {
                if(fuseCount > 0)
                {
                    fuseCount--;
                }
                else
                {
                    return;
                }
            }
            fuseBoxInRange.UseFuse();
        }
    }
}
