using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskTile : MonoBehaviour
{
    public GameObject player;
    // private float currentDistance;
    private SpriteRenderer spriteRenderer;
    private float currentX;
    private float currentY;
    private float sizeX;
    private float sizeY;

    void Start() {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        sizeX = spriteRenderer.size.x;
        sizeY = spriteRenderer.size.y;
    }

    void Update() {
        // currentDistance = Vector3.Distance(transform.position, player.transform.position);
        currentX = Mathf.Round(Mathf.Abs(transform.position.x - player.transform.position.x));
        currentY = Mathf.Round(Mathf.Abs(transform.position.y - player.transform.position.y));
        if (currentX > (transform.localScale.x * sizeX) / 2) {
            transform.position = new Vector3(transform.position.x + 819.2f, transform.position.y, transform.position.z);
        }
        if (currentX < (transform.localScale.x * sizeX) / 3) {
            transform.position = new Vector3(transform.position.x - 819.2f, transform.position.y, transform.position.z);
        }
        if (currentY > (transform.localScale.y * sizeY) / 2) {
            transform.position = new Vector3(transform.position.x, transform.position.y + 409.6f, transform.position.z);
        }
        if (currentY < (transform.localScale.y * sizeY) / 3) {
            transform.position = new Vector3(transform.position.x, transform.position.y - 409.6f, transform.position.z);
        }
    }
}
