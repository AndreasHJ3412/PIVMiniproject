using UnityEngine;
using UnityEngine.SceneManagement;
//Organize code and prevent naming collisions
namespace Level_1
{
    public class Level1EnemyBullet : MonoBehaviour
    {
        private float maxHealth = 100f;
        private float damageAmount = 25f;
    
        public void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {       
                //Destroys the bullets
                Destroy(gameObject);
            
                //Find the health bar using its tag
                GameObject healthBar = GameObject.FindGameObjectWithTag("HealthBar");
            
                //Retrieves the RectTransform component from the health bar
                RectTransform healthBarRect = healthBar.GetComponent<RectTransform>();
                
                //Get the current health
                float currentHealth = healthBarRect.sizeDelta.x;

                //Decrease health by the damage amount
                currentHealth -= damageAmount;

                //Makes sure that the health doesn't go below zero
                currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);

                //Calculate the health bar's width based on the current health
                float healthPercentage = currentHealth / maxHealth;
                float newWidth = healthPercentage * healthBarRect.sizeDelta.x;

                //Update the health bar's width
                healthBarRect.sizeDelta = new Vector2(newWidth, healthBarRect.sizeDelta.y);

                if (currentHealth == 0)
                {
                    SceneManager.LoadScene("Level 1");
                }
            }
        }
    }
}
