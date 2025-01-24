using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    public float speed;
    bool isSprinting;
    public float walkSpeed = 5f;
    public float sprintSpeed = 8f;
    public float JumpPower;
    public GameObject Enemy;
    public GameObject MouseHole;
    public GameObject Barrier;
    public GameObject WinScreen;
    public bool Grounded;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.SetActive(false);
        WinScreen.SetActive(false);
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        speed = walkSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            Debug.Log("'D'key pressed");
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
            Debug.Log("'A'key pressed");
        }
        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            rb.AddForce(Vector3.up * JumpPower);
            Debug.Log("Jumped");
            Grounded = false;
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
            isSprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = walkSpeed;
            isSprinting = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("enemySpawn"))
        {
            Enemy.SetActive(true);
        }
        if (collision.tag == ("Win"))
        {
            WinScreen.SetActive(true);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.E) && collision.tag == ("mouseHole"))
        {
            transform.position = MouseHole.transform.position;
            Barrier.SetActive(false);
            Debug.Log("Went trough a hole");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
}
