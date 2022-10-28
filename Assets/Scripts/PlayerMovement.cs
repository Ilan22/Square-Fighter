using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public DynamicJoystick joystick;
    public Rigidbody2D rb;
    public float speed;
    public float velocityStop;

    public void FixedUpdate(){
        if (joystick.Horizontal + joystick.Vertical != 0)
            rb.velocity = new Vector2(joystick.Horizontal, joystick.Vertical) * speed * Time.deltaTime;
        else
            rb.velocity *= velocityStop * Time.deltaTime;
    }
}
