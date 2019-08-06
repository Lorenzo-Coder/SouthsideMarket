using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject loseScreen;
    public ParticleSystem goodPS;
    public ParticleSystem badPS;

    public float moveSpeed = 10.0f;

    public int health = 50;
    public int happiness = 50;
    public float howOftenDecreaseHealth = 1;
    public float howOftenDecreaseHappiness = 1;

    //Private
    private float timerHealth;
    private float timerHappiness;

    // Start is called before the first frame update
    void Start()
    {
        timerHealth = howOftenDecreaseHealth;
        timerHappiness = howOftenDecreaseHappiness;
        loseScreen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * moveSpeed, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 180, 0);

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime * moveSpeed, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        timerHappiness -= Time.deltaTime;
        timerHealth -= Time.deltaTime;

        if (timerHealth <= 0.0f)
        {
            health--;
            timerHealth = howOftenDecreaseHealth;
        }

        if (timerHappiness <= 0.0f)
        {
            happiness--;
            timerHappiness = howOftenDecreaseHappiness;
        }

        //Lose Condition
        if (health <= 0 || happiness <= 0)
        {
            loseScreen.gameObject.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hit");

        if (collision.gameObject.layer == LayerMask.NameToLayer("Grocery"))
        {
            if (collision.gameObject.tag == "Healthy")
            {
                goodPS.Play();
            }

            if (collision.gameObject.tag == "Junk")
            {
                badPS.Play();
            }
            health += collision.GetComponent<GroceryScript>().healthValue;
            happiness += collision.GetComponent<GroceryScript>().happyValue;
            Destroy(collision.gameObject);
        }
    }
}
