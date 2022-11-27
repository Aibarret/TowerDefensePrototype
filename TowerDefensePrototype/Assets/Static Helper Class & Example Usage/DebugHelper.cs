using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugHelper : MonoBehaviour
{
    public GameObject testPointA;
    public GameObject testPointB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        //drawRay(new Vector3(0, 0, 0), new Vector3(1,1), 3);
    }

    private void OnDrawGizmos()
    {
        //basisVector(testPointA.transform.position);
    }


    public void debugLine(Vector3 pointA, Vector3 pointB, Color? gizmoColor = null)
    {
        Debug.DrawLine(pointA, pointB, gizmoColor ?? Color.white);
    }


    public void debugLine(Vector2 pointA, Vector2 pointB)
    {
        Debug.DrawLine(pointA, pointB);
    }


    public void debugGizmoLine(Vector3 pointA, Vector3 pointB)
    {
        Gizmos.DrawLine(pointA, pointB);
    }


    public void debugGizmoLine(Vector2 pointA, Vector2 pointB)
    {
        Gizmos.DrawLine(pointA, pointB);
    }

    public void drawFromOrigin(Vector3 posn)
    {
        Debug.DrawLine(new Vector3(0,0,0), posn);
    }


    public void vectorFromPoint(Vector3 origin, Vector3 endPoint)
    {
        // I THINK this is what you were going for?
        Debug.DrawLine(origin, origin + endPoint);
    }

    public void drawRay(Vector3 origin, Vector3 direction, float length, Color? gizmoColor = null)
    {
        Debug.DrawLine(origin, origin + (direction * length), gizmoColor ?? Color.white);
    }

    public void basisVector(Vector3 origin)
    {
        // works in both 2d mode and 3d mode
        drawRay(origin, new Vector3(0, 1, 0), 2, Color.red);
        drawRay(origin, new Vector3(1, 0, 0), 2, Color.green);
        drawRay(origin, new Vector3(0, 0, 1), 2, Color.blue);
    }

}
