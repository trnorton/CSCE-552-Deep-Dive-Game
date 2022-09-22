using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;
    public GameObject health;
    System.DateTime invincibleFrames = System.DateTime.Now;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }
    //Deals damage to current health
    public void TakeDamage(int amount)
    {
        if(invincibleFrames <= System.DateTime.Now)
        {
            Destroy(health.transform.Find("Heart"+currentHealth.ToString()).gameObject);
            currentHealth -= amount;
            Debug.Log(currentHealth);
            Reset();
        }

        else if(currentHealth <= 0)
        {
            //This is where the code would go for what happens when player loses

            //I am just booting them to a "you lost menu" - Josh
            SceneManager.LoadScene("LostTheGame");
        }
    }
    //2 seconds of invincibility
    void Reset()
    {
        invincibleFrames = System.DateTime.Now.AddSeconds(2);
    }
}
