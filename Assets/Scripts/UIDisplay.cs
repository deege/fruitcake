using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    
    [SerializeField] Health playerHealth;
    [SerializeField] Slider healthSlider;

    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper keeper;

    void Awake() {
        keeper = FindObjectOfType<ScoreKeeper>();
    }
    
    void Start()
    {
        healthSlider.maxValue =  playerHealth.GetHealth();  
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();  
        scoreText.text = keeper.GetScore().ToString();
    }
}
 