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

    private void Start()
    {

    }

    private void Update()
    {
        rg.MovePosition(transform.position + new Vector3(movementSpeed, 0, 0) * Time.deltaTime);
    }

    public void takeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            die();
        }
    }

    public void die()
    {
        GameObject.Destroy(gameObject);
    }
}
