using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    public GameManagerScript gameManager;

    private bool isDead;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.collider.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives--;

            UpdateLivesUI();

            if (lives <= 0 && !isDead)
            {
                isDead = true;
                gameManager.ShowGameOverUI(); // Update this line
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy Projectile"))
        {
            Destroy(collision.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            lives--;

            UpdateLivesUI();

            if (lives <= 0 && !isDead)
            {
                isDead = true;
                gameManager.ShowGameOverUI(); // Update this line
                Destroy(gameObject);
            }
        }
    }

    private void UpdateLivesUI()
    {
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives;
        }
    }
}
