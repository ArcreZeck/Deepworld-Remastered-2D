using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCont : MonoBehaviour {
    public LayerMask platformLayerMask;
    public float speed = 10f;
    public float jumpSpeed = 100f;
    public Rigidbody2D rb2;
    public Transform mainTransform;
    public Camera mainCamera;

    public GameObject placedBlock;

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W)) rb2.velocity = Vector2.up * jumpSpeed;
        rb2.constraints = RigidbodyConstraints2D.FreezeRotation;
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

    bool IsMouseOnBlock() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        bool isOn = false;
        // RaycastHit sphereHit;
        if(Physics.Raycast(ray, out rayHit)){
            if (rayHit.collider.gameObject.tag == "Block") {
                isOn = true;
            }
        }
        // if(Physics.SphereCast(ray, 1, sphereHit)){
        //  Check if sphereHit.collider.gameObject is your object
        //  If it is, the cursor is near it
        // }
        return isOn;
    }

    void Update() {
        if (!IsMouseOnBlock()) {
            if (Input.GetMouseButton(1)) {
                Vector2 mousePos2D = Input.mousePosition;
                float screenToCameraDistance = mainCamera.nearClipPlane;
                Vector3 mousePosNearClipPlane = new Vector3(mousePos2D.x, mousePos2D.y - 102.4f, screenToCameraDistance);
                Vector3 worldPointPos = mainCamera.ScreenToWorldPoint(mousePosNearClipPlane);
                float delta = 102.4f;
                if (worldPointPos.y <= 0) delta = 0;
                GameObject currentBlock = ObjectPooler.Instance.SpawnFromPool("Block", new Vector3(worldPointPos.x - worldPointPos.x % 102.4f, worldPointPos.y - worldPointPos.y % 102.4f + delta, 1f));
                SpriteMask spriteMask = currentBlock.GetComponent<SpriteMask>();
                spriteMask.backSortingOrder = 0;
            }
        }
    }
}