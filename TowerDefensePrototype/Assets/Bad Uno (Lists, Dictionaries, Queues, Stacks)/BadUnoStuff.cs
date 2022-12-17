using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum possibleColor
{
    Red,
    Green,
    Yellow,
    Blue
}

public class Card
{
    public possibleColor color;
    public int number;
  
    public Card(int numValue, possibleColor colValue)
    {
        number = numValue;
        color = colValue;
    }
}

public class Deck
{
    public Stack<Card> cardPool = new Stack<Card>();

    public Card draw()
    {
        return cardPool.Pop();
    }

    public Deck()
    {
        List<Card> newDeck = new List<Card>();

        int count = 0;
        while (count < 4)
        {
            int subCount = 0;
            while (subCount < 10)
            {
                switch (count)
                {
                    case 0:
                        newDeck.Add(new Card(subCount, possibleColor.Blue));
                        break;
                    case 1:
                        newDeck.Add(new Card(subCount, possibleColor.Red));
                        break;
                    case 2:
                        newDeck.Add(new Card(subCount, possibleColor.Green));
                        break;
                    case 3:
                        newDeck.Add(new Card(subCount, possibleColor.Yellow));
                        break;
                }
                subCount++;
            }
            
            count++;
        }
        cardPool = shuffle(newDeck);
    }

    public Stack<Card> shuffle(List<Card> incomingDeck)
    {
        Stack<Card> newDeck = new Stack<Card>();

        int loopAttempts = 0;
        while (incomingDeck.Count > 0 && loopAttempts < 100)
        {
            int cardIndex = Random.Range(0, incomingDeck.Count);
            newDeck.Push(incomingDeck[cardIndex]);
            incomingDeck.Remove(newDeck.Peek());
            loopAttempts++;
        }

        return newDeck;
    }
}

public class PlayerHand
{
    public List<Card> hand = new List<Card>();

    public PlayerHand(Deck deck)
    {
        for (int i = 0; i < 7; i++)
        {
            drawToHand(deck);
        }

        Debug.Log(toString());
    }

    public void drawToHand(Deck deck)
    {
        Debug.Log("Draing Card!");
        hand.Add(deck.draw());
        Debug.Log(toString());
    }

    public void discard(possibleColor color, int num, PlayingStack pile)
    {
        foreach (Card i in hand)
        {
            if ((i.color == color) && (i.number == num))
            {
                Debug.Log("Discarding " + i.color + " " + i.number);
                pile.gy.Push(i);
                hand.Remove(i);
                Debug.Log(toString());
                break;
            }
        }
    }

    public void checkToPlay(PlayingStack pile, Deck deck)
    {
        Card top = pile.gy.Peek();

        foreach (Card i in hand)
        {
            if (i.color == top.color || i.number == top.number)
            {
                discard(i.color, i.number, pile);
                return;
            }
        }
        drawToHand(deck);
    }

    public string toString()
    {
        string line = "Hand: ";

        foreach (Card i in hand)
        {
            line += i.color + " " + i.number + "| ";
        }

        return line;
    }
}

public class PlayingStack
{
    public Stack<Card> gy = new Stack<Card>();


    public PlayingStack(Deck deck)
    {
        gy.Push(deck.draw());
    }

    public void addTo(Card card)
    {
        gy.Push(card);
    }

    public void flush(Deck deck)
    {
        Card top = gy.Pop();

        List<Card> deckToShuffle = new List<Card>();

        if (deck.cardPool.Count > 0)
        {
            while (deck.cardPool.Count > 0)
            {
                deckToShuffle.Add(deck.cardPool.Pop());
            }
        }

        while (gy.Count > 0)
        {
            deckToShuffle.Add(gy.Pop());
        }

        deck.cardPool = deck.shuffle(deckToShuffle);

        gy.Push(top);
    }
}
