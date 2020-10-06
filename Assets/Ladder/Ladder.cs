using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
    float speed = 5;
    float last_x, last_y;
    KeyCode buttonJump = KeyCode.Space;
    void OnTriggerEnter2D (Collider2D other) { }
    void OnTriggerStay2D (Collider2D other) {
        if (other.gameObject.CompareTag ("Player")) {
            if (Input.GetKey (buttonJump)) {
                other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, speed);
                //other.transform.position = new Vector2 (transform.position.x + 0.7f, other.transform.position.y);

            }

        }
        if (Input.GetKeyUp (buttonJump)) {
            //other.transform.position = new Vector2 (transform.position.x + 0.7f, -transform.position.y);
            other.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
        }
    }
    void OnTriggerExit2d (Collider2D other) {
        if (other.gameObject.CompareTag ("Player")) {
            if (other.transform.position.y > transform.position.y) {
                GetComponent<BoxCollider2D> ().isTrigger = false;
            }
        }
    }
}