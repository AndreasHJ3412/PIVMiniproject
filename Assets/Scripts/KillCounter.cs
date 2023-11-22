using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCounter : MonoBehaviour
{
    public int killCount = 0;
    public int bulletCount = 20;
    public TMP_Text killCountText;
    public TMP_Text bulletCountText;
    private int maxKills = 6;
    
    public float fireCooldown = 0.25f; 
    private float nextFireTime;


    public void Start()
    {
            UpdateBulletCountText();
            
        // Find and assign the TextMeshPro components
        killCountText = GameObject.Find("KillCount").GetComponent<TMP_Text>();
        bulletCountText = GameObject.Find("BulletCount").GetComponent<TMP_Text>();
        
            UpdateKillCountText();
            UpdateBulletCountText();
      
       
        UpdateKillCountText();
        UpdateBulletCountText();
        
        nextFireTime = 0f;
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + fireCooldown;
            
            if (bulletCount > 0) // Ensure the player has bullets to shoot
            {
                
                DecrementBulletCount();
                
            }
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

    void UpdateBulletCountText()
    {
        
        
           bulletCountText.text = bulletCount.ToString();
    }

    
    
}