﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform teleportLocation;
    public List<string> collectedKeys = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Die()
    {
        transform.position = teleportLocation.position;
    }
}
