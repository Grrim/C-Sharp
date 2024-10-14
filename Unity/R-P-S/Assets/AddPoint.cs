using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddPoint : MonoBehaviour
{
    public GameObject enemyPoint;
    public GameObject playerPoint;
    public float timer4 = 100.0f;
    public static AddPoint instance;

    void Update()
    {
        if (EnemyAction.isPlayerPoint == 1)
        {
            playerPoint.SetActive(true);
            timer4 -= 0.5f;
        }
        else if (EnemyAction.isEnemyPoint == 1)
        {
            enemyPoint.SetActive(true);
            timer4 -= 0.5f;
        }
        if (timer4 < 0.0f)
        {
            enemyPoint.SetActive(false);
            playerPoint.SetActive(false);
            timer4 = 100.0f;
            EnemyAction.isPlayerPoint = 0;
            EnemyAction.isEnemyPoint = 0;
        }
    }
}
