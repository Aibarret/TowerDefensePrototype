using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    Deck deck;
    PlayerHand hand;
    PlayingStack pile;

    // Start is called before the first frame update
    void Start()
    {
        deck = new Deck();
        hand = new PlayerHand(deck);
        pile = new PlayingStack(deck);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            hand.checkToPlay(pile, deck);

        }
    }
}
