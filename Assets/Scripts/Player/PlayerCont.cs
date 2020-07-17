using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour {
    public LayerMask platformLayerMask;
    public float speed = 10f;
    public float jumpSpeed = 100f;
    public Rigidbody2D rb2;

    public Camera camera;

    public GameObject placedBlock;

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

    void Update(){
        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mousePos2D = Input.mousePosition;
            float screenToCameraDistance = camera.nearClipPlane;
            Vector3 mousePosNearClipPlane = new Vector3(mousePos2D.x, mousePos2D.y - 102.4f, screenToCameraDistance);
            Vector3 worldPointPos = camera.ScreenToWorldPoint(mousePosNearClipPlane);

            float delta = 102.4f;
            if (worldPointPos.y <= 0)
            {
                delta = 0;
            }
            
            Instantiate(placedBlock, new Vector2(worldPointPos.x - worldPointPos.x % 102.4f, worldPointPos.y - worldPointPos.y % 102.4f + delta), Quaternion.identity);
        }
    }
}
