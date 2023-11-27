using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
//Organize code and prevent naming collisions
namespace Level_1
{
    public class Level1KillCounter : MonoBehaviour
    {
        private int killCount = 0;
        public int bulletCount = 7;
        public int maxBullets = 7;
        public TMP_Text killCountText;
        public TMP_Text bulletCountText;
        private int maxKills = 6;
    
        public float fireCooldown = 0.25f; 
        private float nextFireTime;
    
        public void Start()
        {
            UpdateBulletCountText();
            
            // Find and assign the TextMeshPro components
            killCountText = GameObject.Find("KillsCounter").GetComponent<TMP_Text>();
            bulletCountText = GameObject.Find("BulletsCounter").GetComponent<TMP_Text>();
        
            UpdateKillCountText();
            UpdateBulletCountText();
        
            nextFireTime = 0f;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFireTime)
            {
                //Makes sure that the player can't spam Mouse0 and the bullets thereby go down on the UI without bullets getting fired
                nextFireTime = Time.time + fireCooldown;
            
                if (bulletCount > 0) // Ensure the player has bullets to shoot
                {
                    DecrementBulletCount();
                }
            }
        
            if (killCount == maxKills)
            {
                SceneManager.LoadScene("Level 2");
            }
        }
    
        public void IncrementKillCount()
        {
            killCount++;
            UpdateKillCountText();
        }

        public void DecrementBulletCount()
        {
            bulletCount--;
            UpdateBulletCountText();
        }

        void UpdateKillCountText()
        {
            killCountText.text = killCount.ToString();
        }

        public void UpdateBulletCountText()
        {
            bulletCountText.text = bulletCount.ToString();
        }
    }
}