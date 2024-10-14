using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePoints : MonoBehaviour
{
    public static ScorePoints instance;

    public TMPro.TextMeshProUGUI playerScoreText;
    public TMPro.TextMeshProUGUI enemyScoreText;

    public static int playerScore = 0;
    public static int enemyScore = 0;

    public GameObject playerPoint;
    public GameObject enemyPoint;
    public GameObject scoreTable;
    public GameObject playerZone;
    public GameObject enemyZone;
    public GameObject playerCards;
    public GameObject winScreen;
    public GameObject loseScreen;
    public GameObject drawScreen;
    public float timer = 200.0f;

    private void Awake()
    {
        playerScore = 0;
        enemyScore = 0;
        instance = this;
    }

    // Start is called before the first frame update
    void Update()
    {
        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();

        if (playerZone.transform.childCount < 1 && playerCards.transform.childCount < 1 && playerScore > enemyScore)
        {
            timer -= 1f;
            if (timer == 0)
            {
                playerZone.SetActive(false);
                enemyZone.SetActive(false);
                scoreTable.SetActive(false);
                winScreen.SetActive(true);
            }
        }
        if (playerZone.transform.childCount < 1 && playerCards.transform.childCount < 1 && playerScore < enemyScore)
        {
            timer -= 1f;
            if (timer == 0)
            {
                playerZone.SetActive(false);
                enemyZone.SetActive(false);
                scoreTable.SetActive(false);
                loseScreen.SetActive(true);
            }
        }
        if (playerZone.transform.childCount < 1 && playerCards.transform.childCount < 1 && playerScore == enemyScore)
        {
            timer -= 1f;
            if (timer == 0)
            {
                playerZone.SetActive(false);
                enemyZone.SetActive(false);
                scoreTable.SetActive(false);
                drawScreen.SetActive(true);
            }
        }
    }

    public static void AddPlayerPoint()
    {
        playerScore += 1;
    }

    public static void AddEnemyPoint()
    {
        enemyScore += 1;
    }
}
