using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour {
    public LayerMask platformLayerMask;
    public float speed = 10f;
    public float jumpSpeed = 100f;
    public Rigidbody2D rb2;

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.Space)) {
            rb2.velocity = Vector2.up * jumpSpeed;
        }
        rb2.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.A)) {
            rb2.velocity = new Vector2(-speed, rb2.velocity.y);
        } else if (Input.GetKey(KeyCode.D)) {
            rb2.velocity = new Vector2(+speed, rb2.velocity.y);
        } else {
            rb2.velocity = new Vector2(0f, rb2.velocity.y);
            rb2.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
