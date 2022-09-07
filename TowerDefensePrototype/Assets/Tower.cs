using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int cost = 5;
    public float projectileSpeed = 1f;
    public int projectileDamage = 1;
    public int fireRate = 1;
    public float range = 1f;
    
    private Enemy target;
    private bool ShouldBeShooting = false;

    public GameObject player;
    public CircleCollider2D collider;

    private void Start()
    {
        collider.radius = range;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            target = other.GetComponent<Enemy>();
            ShouldBeShooting = true;
        }
    }

    private void Update()
    {
        if (ShouldBeShooting)
        {
            //TODO: make damage per second
            target.takeDamage(projectileDamage);
        }
    }
}
