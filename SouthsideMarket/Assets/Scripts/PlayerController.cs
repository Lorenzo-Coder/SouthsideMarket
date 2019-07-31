using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10.0f;

    public int health = 50;
    public int happiness = 50;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * moveSpeed, transform.position.y, transform.position.z);
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime * moveSpeed, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.layer == LayerMask.NameToLayer("Grocery"))
        {
            if (collision.transform.tag == "Healthy")
            {
                health += 10;
            }
            else if (collision.transform.tag == "Junk")
            {
                health -= 10;
                happiness += 10;
            }

            Destroy(collision.gameObject);
        }
    }
}
