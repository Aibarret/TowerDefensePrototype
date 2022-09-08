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
    private float timerRemaining = 30f;

    public GameObject player;
    public CircleCollider2D collider2D;

    private void Start()
    {
        collider2D.radius = range;
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            target = collision.GetComponent<Enemy>();
            ShouldBeShooting = true;
            GetComponent<Timer>().startTimer(60 / projectileSpeed);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            ShouldBeShooting = false;
            GetComponent<Timer>().stopTimer();
        }
    }

    public void timeOut()
    {
        if (ShouldBeShooting)
        {
            target.takeDamage(projectileDamage);
            GetComponent<Timer>().startTimer(60 / projectileSpeed);
            print("BULLET FIRED");
        }
        
    }


    private void Update()
    {
        /*if (timerRemaining > 0)
        {
            timerRemaining -= Time.deltaTime;
        }
        else
        {
            print("TIME");
        }*/
        /*if (ShouldBeShooting)
        {
            //TODO: make damage per second
            target.takeDamage(projectileDamage);
        }*/
    }
}
