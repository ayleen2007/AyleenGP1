using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    public int coinCount;
    // set max health
    public int MaxHealth;
    public int currentHealth;

    void start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
   private void Update()
    {
        if(currentHealth <= 0)
        {
            PauseGame();
        }
    }

    public bool PickupItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
                coinCount++;
                return true;

            case "Speed+":
                playerMovement.SpeedPowerUp();
                //call function here
                return true;
            default:
                Debug.Log("Item tag or refrence not set.");
                return false;
        }
       
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
    }
  public void PauseGame()
    {
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
