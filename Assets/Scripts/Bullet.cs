using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1;
    void Start()
    {
        Destroy(gameObject, 20);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.player.GetComponent<Player>().Die();
        }
        Destroy(gameObject);
    }
}
