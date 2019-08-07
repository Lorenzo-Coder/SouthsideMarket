using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject loseScreen;
    public GameObject winScreen;
    public ParticleSystem goodPS;
    public ParticleSystem badPS;
    public Animator animator;

    public float moveSpeed = 10.0f;

    public int health = 50;
    public int happiness = 50;
    public float howOftenDecreaseHealth = 1;
    public float howOftenDecreaseHappiness = 1;

    //Private
    private float timerHealth;
    private float timerHappiness;
    private int durationTimer = 60;
    private float durationCountdown;

    // Start is called before the first frame update
    void Start()
    {
        timerHealth = howOftenDecreaseHealth;
        timerHappiness = howOftenDecreaseHappiness;
        loseScreen.gameObject.SetActive(false);
        winScreen.gameObject.SetActive(false);
        durationCountdown = durationTimer;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = new Vector3(transform.position.x + Time.deltaTime * moveSpeed, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 180, 0);//2nd Value 180 to flip

        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(transform.position.x - Time.deltaTime * moveSpeed, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        
        //Animation
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.SetFloat("Speed", 1);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            animator.SetFloat("Speed", 0);
        }


        timerHappiness -= Time.deltaTime;
        timerHealth -= Time.deltaTime;
        durationCountdown -= Time.deltaTime;

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

        //Win condition
        if (durationCountdown <= 0.0f)
        {
            winScreen.gameObject.SetActive(true);
        }

        //Lose Condition
        if (health <= 0 || happiness <= 0)
        {
            loseScreen.gameObject.SetActive(true);
        }

        if (health > 100)
        {
            health = 100;
        }

        if (happiness > 100)
        {
            happiness = 100;
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
