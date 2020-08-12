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

    Ray ray;    
    RaycastHit2D hit = new RaycastHit2D(); 

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

    void Update() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (Input.GetMouseButton(1)) {
                if (!IsMouseOverBlock(ray, hit)) {
                    Vector2 mousePos2D = Input.mousePosition;
                    float screenToCameraDistance = mainCamera.nearClipPlane;
                    Vector3 mousePosNearClipPlane = new Vector3(mousePos2D.x, mousePos2D.y - 102.4f, screenToCameraDistance);
                    Vector3 worldPointPos = mainCamera.ScreenToWorldPoint(mousePosNearClipPlane);
                    float ydelta = 102.4f;
                    float xdelta = 0;
                    if (worldPointPos.y <= 0) ydelta = 0;
                    if (worldPointPos.x <= 0) xdelta = 102.4f;
                    GameObject currentBlock = ObjectPooler.Instance.SpawnFromPool("Block", new Vector3(worldPointPos.x - worldPointPos.x % 102.4f - xdelta, worldPointPos.y - worldPointPos.y % 102.4f + ydelta, 1f));
                    SpriteMask spriteMask = currentBlock.GetComponent<SpriteMask>();
                    spriteMask.backSortingOrder = 0;
                    foreach (Transform borderObject in currentBlock.transform) {
                        if (borderObject.name.Contains("Border")) {
                            SpriteMask borderTex = borderObject.gameObject.GetComponent<SpriteMask>();
                            borderTex.backSortingOrder = 0;
                        }
                    }
                }
            }
        }
    }
}