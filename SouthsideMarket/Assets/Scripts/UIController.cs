using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public int roundDuration = 60;
    public Slider Health;
    public Slider Happiness;
    public Slider Timer;
    public PlayerController player;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private float roundTimer;
    private bool gameLost = false;
    // Start is called before the first frame update
    void Start()
    {
        roundTimer = roundDuration;
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        gameLost = false;
    }

    // Update is called once per frame
    void Update()
    {
        roundTimer -= Time.deltaTime;
        Timer.value = roundTimer / roundDuration;
        Health.value = (float)player.health / 100;
        Happiness.value = (float)player.happiness / 100;

        if (roundTimer <= 0.0f && !gameLost)
        {
            gameLost = true;
            if (player.happiness + player.health >= 190)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(true);
            }
            else if (player.happiness + player.health >= 130)
            {
                star1.SetActive(true);
                star2.SetActive(true);
                star3.SetActive(false);
            }
            else
            {
                star1.SetActive(true);
                star2.SetActive(false);
                star3.SetActive(false);
            }
        }
    }
}
