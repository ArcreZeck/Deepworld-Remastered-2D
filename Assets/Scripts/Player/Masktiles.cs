using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Masktiles : MonoBehaviour
{
    public float speed = 10f;
    public float jumpSpeed = 100f;
    public Transform mainTransform;
    public GameObject playerObject;
    public Rigidbody2D rb2;
    public GameObject player;

    private Vector3 originalPos;
    private Vector3 currentPos;

    void Start() {
        originalPos = transform.position;
    }

    void Update() {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) rb2.velocity = Vector2.up * jumpSpeed;
        if (Input.GetKey (KeyCode.A)) {
            rb2.velocity = new Vector2(-speed, rb2.velocity.y);
            mainTransform.localScale = new Vector3(-Mathf.Abs(mainTransform.localScale.x), mainTransform.localScale.y, mainTransform.localScale.z);
        } else if (Input.GetKey (KeyCode.D)) {
            rb2.velocity = new Vector2(+speed, rb2.velocity.y);
            mainTransform.localScale = new Vector3(Mathf.Abs(mainTransform.localScale.x), mainTransform.localScale.y, mainTransform.localScale.z);
        } else {
            rb2.velocity = new Vector2(0f, rb2.velocity.y);
            rb2.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
