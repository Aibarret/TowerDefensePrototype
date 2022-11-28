using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public int money;
    public int killCount;
    public int lives;

    public GameObject enemyInstance;

    public void loseLife()
    {
        lives -= 1;

        if (lives <= 0)
        {
            Application.Quit();
        }
    }

    public void gainKill(int loot)
    {
        killCount += 1;
        gainMoney(loot);
    }

    public void gainMoney(int amount)
    {
        money += amount;
    }

    public void loseMoney(int amount)
    {
        money -= amount;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Enemy")
        {
            loseLife();
            collision.gameObject.GetComponent<Enemy>().die();
            respawnEnemy();
        }
        
        
    }

    public void respawnEnemy()
    {
        Instantiate(enemyInstance, new Vector3(-6.96f, 0.03f, 0f), Quaternion.identity);
    }
}
