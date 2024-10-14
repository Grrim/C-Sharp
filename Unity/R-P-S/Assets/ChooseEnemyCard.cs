using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseEnemyCard : MonoBehaviour
{
    public static int cardNumber;
    public static int i;

    void Start()
    {
        i = 8;
        cardNumber = Random.Range(0, i);
    }

    public static void RandomNumber()
    {
        if (i == 1)
        {
            EnemyAction.randomCard = false;
        }
        else
        {
            i--;
            cardNumber = Random.Range(0, i);
        }
    }
}
