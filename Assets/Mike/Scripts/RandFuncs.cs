using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandFuncs : MonoBehaviour
{
    //randomize order
    public static void Shuffle<T>(T[] deck)
    {
        for (int i = deck.Length - 1; i >= 1; i--) {
            int randomIndex = Random.Range(0, i + 1);
            T swapTemp = deck[randomIndex];
            deck[randomIndex] = deck[i];
            deck[i] = swapTemp;
        }
    }
    
    //for list
    public static void Shuffle<T>(List<T> deck)
    {
        for (int i = deck.Count - 1; i >= 1; i--) {
            int randomIndex = Random.Range(0, i + 1);
            T swapTemp = deck[randomIndex];
            deck[randomIndex] = deck[i];
            deck[i] = swapTemp;
        }
    }
}
