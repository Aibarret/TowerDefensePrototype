using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    private DebugHelper helper;
    public float explosionRadius;

    GameObject[] targets = new GameObject[0];

    

    public void addToTargets(GameObject target)
    {
        bool isInArray = false;
        foreach (GameObject i in targets)
        {
            if (i.name == target.name)
            {
                isInArray = true;
            }
        }

        if (!isInArray)
        {
            GameObject[] temp = new GameObject[targets.Length + 1];
            targets.CopyTo(temp, 0);
            temp[temp.Length - 1] = target;
            targets = temp;

        }

    }

    public void removefromTargets(GameObject target)
    {
        int removedObjects = 0;

        GameObject[] temp = new GameObject[targets.Length - 1];
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].name == target.name)
            {
                removedObjects++;
            }
            else
            {
                temp[i - removedObjects] = targets[i];
            }
        }
        targets = temp;

    }

    public void displayPath(GameObject target)
    {
        helper.drawRay(target.transform.position, new Vector3(target.transform.position.x - transform.position.x, target.transform.position.y - transform.position.y).normalized, 5);
    }

    public void detonate()
    {
        foreach (GameObject i in targets)
        {
            i.GetComponent<Explodable>().knockback(new Vector3(i.transform.position.x - transform.position.x, i.transform.position.y - transform.position.y).normalized, 1);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

        
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.name);
        addToTargets(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        removefromTargets(other.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        helper = GameObject.Find("Helper").GetComponent<DebugHelper>();
        GetComponent<SphereCollider>().radius = explosionRadius;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject i in targets)
        {
            helper.debugLine(transform.position, i.transform.position);
        }

        foreach (GameObject i in targets)
        {
            displayPath(i);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            detonate();
        }
    }
}
