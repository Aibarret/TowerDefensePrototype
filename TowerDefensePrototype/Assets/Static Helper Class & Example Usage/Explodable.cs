using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explodable : MonoBehaviour
{
    Vector3 direction;
    float speed;

    DebugHelper helper;

    // Start is called before the first frame update
    void Start()
    {
        helper = GameObject.Find("Helper").GetComponent<DebugHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > 0)
        {
            transform.position += (direction * speed) * Time.deltaTime;
            helper.drawRay(transform.position, direction, speed);
        }
    }

    public void knockback(Vector3 dir, float speed)
    {
        direction = dir;
        this.speed = speed;
    }
}
