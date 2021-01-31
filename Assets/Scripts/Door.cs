using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public string keyToOpen;
    public Animator anim;

    public AudioSource audioSource;
    public AudioClip doorOpen;
    public AudioClip doorClose;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (string s in GameManager.instance.player.GetComponent<Player>().collectedKeys)
            {
                if(s == keyToOpen)
                {
                    anim.SetBool("Open", true);
                    audioSource.PlayOneShot(doorOpen);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (string s in GameManager.instance.player.GetComponent<Player>().collectedKeys)
            {
                if (s == keyToOpen)
                {
                    anim.SetBool("Open", false);
                    audioSource.PlayOneShot(doorClose);
                }
            }
        }
    }
}
