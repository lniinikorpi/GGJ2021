using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public int speed = 3;
    public Rigidbody rb;
    private Vector3 _movement;
    public IconMove iconMove;
    public GameObject playerModel;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = new Vector3(_movement.x, rb.velocity.y, _movement.y) * speed * Time.fixedDeltaTime;
        //Rotate player model
        if (_movement != Vector3.zero)
        {
            iconMove.MoveIcon(new Vector2(_movement.x, _movement.y));

            Vector3 direction = playerModel.transform.localPosition - _movement;

            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            Vector3 directionVector = new Vector3(0, angle, 0);
            playerModel.transform.rotation = Quaternion.Euler(directionVector);

            if (!audioSource.isPlaying) { 
                audioSource.Play();
            }

        }
        else
        {
            audioSource.Stop();
        }
    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }
}
