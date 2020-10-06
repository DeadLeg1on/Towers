using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    int start_posX;
    int start_posY;
    int last_posX;
    int last_posY;

    [SerializeField]
    private float jumpForce = 5;

    [SerializeField]
    private float speed = 1;

    [SerializeField]
    public bool isJump = false;
    [SerializeField]
    float sprite_size = 3;
    [SerializeField]
    float direction; //1 - right -1 - left

    [SerializeField]
    bool ladderUp = false;

    Rigidbody2D rig2d;
    SpriteRenderer sprite;

    void Awake () {
        direction = sprite_size;
        rig2d = GetComponent<Rigidbody2D> ();
        sprite = GetComponent<SpriteRenderer> ();
    }
    void Start () {
        Run ();
    }
    void Update () {
        if (isJump == false && ladderUp == false) {
            if (Input.GetKeyDown (KeyCode.Space) || Input.GetKey (KeyCode.Joystick1Button3)) {
                rig2d.AddForce (transform.up * jumpForce, ForceMode2D.Impulse);
                isJump = true;

            }
            if (Input.GetKeyDown (KeyCode.A)) {
                direction = -1 * sprite_size;
                Run ();
            }
            if (Input.GetKeyDown (KeyCode.D)) {
                direction = 1 * sprite_size;
                Run ();
            }
        }
    }

    private void Run () {
        rig2d.velocity = new Vector2 (speed * direction, rig2d.velocity.y);
        transform.localScale = new Vector3 (direction, sprite_size, sprite_size);
    }
    void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Platform") {
            isJump = false;
        }
        if (other.gameObject.tag == "Ladder") {
            isJump = false;
        }
    }
    void OnCollisionExit2D (Collision2D other) {
        if (other.gameObject.tag == "Ladder") {
            isJump = true;
        }
    }

}