using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public int cost = 5;
    public float projectileSpeed = 1f;
    public int projectileDamage = 1;
    public int fireRate = 4;
    public float range = 1f;
    
    private Enemy target;
    private bool ShouldBeShooting = false;
   

    public GameObject player;
    public CircleCollider2D collider2D;

    private void Start()
    {
        //collider2D.radius = range;
    }

  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !ShouldBeShooting)
        {
            ShouldBeShooting = true;
            target = collision.gameObject.GetComponent<Enemy>();
            target.takeDamage(projectileDamage);
            print("BULLET FIRED");
            GetComponent<Timer>().startTimer(60 / fireRate);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            print("No longer Shooting");
            ShouldBeShooting = false;
            GetComponent<Timer>().stopTimer();
        }
    }

    public void timeOut()
    {
        if (ShouldBeShooting)
        {
            target.takeDamage(projectileDamage);
            GetComponent<Timer>().startTimer(60 / fireRate);
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
