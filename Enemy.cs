using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth;
    public int currentHealth;

    public HealthBar healthBar;
    public ScoreManager scoreManager;

    public int EnemyScore;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(maxHealth);
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Kill();
        }
    }

    void Kill()
    {
        //Debug.Log("Enemy died!");

        // Die animation

        //Disable the enemy
        //GetComponent<Collider2D>().enabled = false;

        //Destroy
        Destroy(gameObject);

        this.enabled = false;

        scoreManager.AddPoint(EnemyScore);
    }


}
