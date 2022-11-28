using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5;
    public int movementSpeed = 2;
    public int loot = 1;

    public Rigidbody2D rg;
    public GameObject player;

    public enemyTypes type;

    public enum enemyTypes
    {
        Untyped,
        Armored,
        Undying
    }

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        rg.MovePosition(transform.position + new Vector3(movementSpeed, 0, 0) * Time.deltaTime);
    }

    public void takeDamage(int damage, towerTypes towerType)
    {
        switch (type){
            case enemyTypes.Untyped:
                health -= damage;

                if (health <= 0)
                {
                    die();
                }
                break;
            case enemyTypes.Armored:
                health -= damage - 2;

                if (health <= 0)
                {
                    die();
                }
                break;
            case enemyTypes.Undying:
                health -= damage - 2;

                if (health <= -5)
                {
                    die();
                }
                break;
        }
        print(type + " enemy hit by " + towerType + " projectile!");
    }

    public void die()
    {
        player.GetComponent<Player>().gainKill(loot);
        GameObject.Destroy(gameObject);
    }
}
