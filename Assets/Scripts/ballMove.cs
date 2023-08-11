using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballMove : MonoBehaviour
{
    public float moveSpeed = 3;
    Vector2 direction = Vector2.up;
    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x <= 0 || pos.x >= 1) {
            direction.x = -direction.x;
        }
        if (pos.y <= 0 || pos.y >= 1) {
            direction.y = -direction.y;
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Block") {
            direction.y = -direction.y;
            collision.gameObject.GetComponent<block>().hit();
        } else if (collision.gameObject.tag == "Player") {
            string name = collision.gameObject.name;
            if (name == "MainPad") {
                direction.x += Random.Range(-0.3f, 0.3f);
            } else if (name == "PadLeft") {
                direction.x -= Random.Range(0.5f, 0.7f);
            } else {
                direction.x += Random.Range(0.5f, 0.7f);
            }
            direction.y = -direction.y;
        }
    }
}
