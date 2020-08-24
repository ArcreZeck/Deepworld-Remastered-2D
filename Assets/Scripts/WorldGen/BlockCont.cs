﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockCont : MonoBehaviour {
    public int blockId;
    float blockHealth = 50f;
    float tempHealth;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        tempHealth = blockHealth;
        GameObject child = gameObject.transform.GetChild(0).gameObject;
        spriteRenderer = child.GetComponent<SpriteRenderer>();
    }

    private void OnMouseOver() {
        if (Input.GetMouseButton(0)) {
            if (!EventSystem.current.IsPointerOverGameObject()) {
                if (tempHealth >= Math.Truncate(blockHealth / 4 * 3) && tempHealth <= blockHealth) {
                    spriteRenderer.sprite = Resources.Load<Sprite>("Effects/crack1");
                } else if (tempHealth >= Math.Truncate(blockHealth / 4 * 2) && tempHealth <= Math.Truncate(blockHealth / 4 * 3)) {
                    spriteRenderer.sprite = Resources.Load<Sprite>("Effects/crack2");
                } else if (tempHealth >= Math.Truncate(blockHealth / 4 * 1) && blockHealth <= 0) {
                    spriteRenderer.sprite = Resources.Load<Sprite>("Effects/crack3");
                } else if (tempHealth >= 0) {
                    Destroy(gameObject);
                }
                tempHealth--;
            }
        }
    }

    private void OnMouseDown() {
        if (!EventSystem.current.IsPointerOverGameObject()) {
            if (tempHealth >= Math.Truncate(blockHealth / 4 * 3) && tempHealth <= blockHealth) {
                spriteRenderer.sprite = Resources.Load<Sprite>("Effects/crack1");
            } else if (tempHealth >= Math.Truncate(blockHealth / 4 * 2) && tempHealth <= Math.Truncate(blockHealth / 4 * 3)) {
                spriteRenderer.sprite = Resources.Load<Sprite>("Effects/crack2");
            } else if (tempHealth >= Math.Truncate(blockHealth / 4 * 1) && blockHealth <= 0) {
                spriteRenderer.sprite = Resources.Load<Sprite>("Effects/crack3");
            } else if (tempHealth >= 0) {
                Destroy(gameObject);
            }
            tempHealth -= tempHealth / 4;
        }
    }

    private bool IsCloseToTag(string tag, float minimumDistance) {
        GameObject[] goWithTag = GameObject.FindGameObjectsWithTag (tag);
        for (int i = 0; i < goWithTag.Length; ++i) {
            if (Vector3.Distance(transform.position, goWithTag[i].transform.position) <= minimumDistance) {
                return true;
            }
        }
        return false;
    }
}