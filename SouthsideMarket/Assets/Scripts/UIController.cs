using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider Health;
    public Slider Happiness;
    public PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Health.value = (float)player.health / 100;
        Happiness.value = (float)player.happiness / 100;
    }
}
