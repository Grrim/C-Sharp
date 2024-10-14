using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixCards : MonoBehaviour
{
    public GameObject EnemyZone;
    public GameObject CardWait;
    public static int cardNumber;
    public static int i;
    private float fireDelay = 0.1f;
    private float fireTimestamp = 0.0f;

    void Start()
    {
        fireTimestamp = Time.realtimeSinceStartup + fireDelay;
        i = 8;
    }

    void Update()
    {
        if (i >= 0 && Time.realtimeSinceStartup > fireTimestamp)
        {
            if (fireTimestamp > 3)
            {
                cardNumber = Random.Range(0, i);
                CardWait.transform.GetChild(cardNumber).transform.SetParent(EnemyZone.transform);
                i--;
                fireTimestamp = fireTimestamp + 0.5f;
            }
            else
            {
                fireTimestamp++;
            }
        }
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
