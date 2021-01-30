﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyName;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.player.GetComponent<Player>().collectedKeys.Add(keyName);
            print(keyName + " collected");
            Destroy(gameObject);
        }
    }
}