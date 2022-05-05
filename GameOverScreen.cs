using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public PlayerHealt playerHealth;

    public GameObject DeathMenuUI;
    private void Update()
    {
        if (playerHealth.currentHealth <= 0)
        {
            Dead();
        }

    }
    
    public void Dead()
    {
        DeathMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void DeathLoadMenu()
    {
        Time.timeScale = 1f;
        playerHealth.currentHealth = playerHealth.maxHealth;
        SceneManager.LoadScene("MenuScene");
    }

    public void Restart()
    {
        DeathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        playerHealth.currentHealth = playerHealth.maxHealth;
        //SceneManager.LoadScene("GameScene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
