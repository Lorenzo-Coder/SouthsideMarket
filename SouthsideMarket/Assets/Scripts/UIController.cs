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

    private float roundTimer;
    // Start is called before the first frame update
    void Start()
    {
        roundTimer = roundDuration;
    }

    // Update is called once per frame
    void Update()
    {
        roundTimer -= Time.deltaTime;
        Timer.value = roundTimer / roundDuration;
        Health.value = (float)player.health / 100;
        Happiness.value = (float)player.happiness / 100;
    }
}
