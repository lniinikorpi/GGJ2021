using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public string keyName;
    public AudioSource audioSource;

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, 50 * Time.deltaTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.player.GetComponent<Player>().collectedKeys.Add(keyName);
            print(keyName + " collected");
            audioSource.Play();
            UIManager.instance.ToggleItem();
            Destroy(gameObject);
        }
    }
}
