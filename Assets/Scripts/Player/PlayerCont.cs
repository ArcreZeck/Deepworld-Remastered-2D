using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCont : MonoBehaviour {
    public LayerMask platformLayerMask;
    public float speed = 10f;
    public float jumpSpeed = 100f;
    public Rigidbody2D rb2;
    public Transform mainTransform;
    public Camera mainCamera;
    private float distToGround;

    Ray ray;    
    RaycastHit2D hit = new RaycastHit2D(); 

    public GameObject placedBlock;

    void Start() {
        distToGround = GetComponent<Collider>().bounds.extents.y;
    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W) && IsGrounded()) rb2.velocity = Vector2.up * jumpSpeed;
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

    bool IsMouseOverBlock(Ray ray, RaycastHit2D hit) {
        bool returnBool = false;
        hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
        if (hit.collider == null) {
            return returnBool;
        }
        if (hit.collider.gameObject.tag == "SolidBlockTag") {
            returnBool = true;
        }
        return returnBool;
    }

    private bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void Update() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetMouseButton(1)) {
                if (!IsMouseOverBlock(ray, hit)) {
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
}