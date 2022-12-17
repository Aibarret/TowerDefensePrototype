using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject character;
    
    private Character characterInit;
    private DelegateTimer timer;

    private string[] dialogue = new string[3];
    private int dCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        dialogue[0] = "doot";
        dialogue[1] = "doot2";
        dialogue[2] = "doot3";

        characterInit = new Human();

        characterInit.controller = character;
        characterInit.health = new NumberRange(5, 6, 0, characterInit.takeDamage);

        timer = gameObject.GetComponent<DelegateTimer>();
        timer.startTimer(5, timeOut, true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            characterInit.walk(new Vector3(0, 1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            characterInit.walk(new Vector3(0, -1, 0));
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            characterInit.walk(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            characterInit.walk(new Vector3(1, 0, 0));
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            characterInit.attack();
            characterInit.health.current -= 1;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            characterInit.speak();
        }
    }

    public void timeOut()
    {
        if (dCount < 3)
        {
            print(dialogue[dCount]);
            dCount++;
        }
    }
}
