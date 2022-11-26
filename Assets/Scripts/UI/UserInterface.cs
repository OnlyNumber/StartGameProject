using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterface : MonoBehaviour
{

    [SerializeField] private Text score;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image healthBarEffect;
    [SerializeField] private float speedHealthBar;
    [SerializeField] private GameObject gameOverPanel;
    private PlayerCombat playerCombat;
    private SpawnManager spawnManager;
    private int scoreNumber = 0; 


    void Start()
    {
        Time.timeScale = 1;
        playerCombat = GameObject.Find("Player").GetComponent<PlayerCombat>();
    }

    void Update()
    {


        if (playerCombat.GetIsGame())
        {
            healthBar.fillAmount = playerCombat.GetCurrentHealth() / playerCombat.GetMaxHealth();
        }
        else
        {
            healthBar.fillAmount = 0;
            ShowGameOverPanel();
        }


        if (healthBarEffect.fillAmount > healthBar.fillAmount)
        {
            healthBarEffect.fillAmount -= speedHealthBar;
        }
    }

    public void SetScore()
    {
        score.text = "Score: " + ++scoreNumber;  
    }

    private void ShowGameOverPanel()
    {
        Time.timeScale = 0;
        gameOverPanel.GetComponentsInChildren<Text>()[2].text = "Score: " + scoreNumber;
        gameOverPanel.SetActive(true);
    }
}
