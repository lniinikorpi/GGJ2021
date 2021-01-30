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
        iconMove.MoveIcon(new Vector2(_movement.x, _movement.y));
    }

    public void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }
}
