using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public GameObject Enemy;

    // Start is called before the first frame update
    void Start()
    {
        Enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
            Debug.Log("'D'key pressed");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("enemySpawn"))
        {
            Enemy.SetActive(true);
        }
    }
}
