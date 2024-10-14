using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction : MonoBehaviour
{
    public GameObject EnemyArea;
    public GameObject EnemyZone;
    public GameObject PlayerZone;
    public GameObject EnemyCard2;
    public GameObject Deck;
    public GameObject ThirdCard;
    public GameObject Trash;
    public static int isEnemyPoint = 0;
    public static int isPlayerPoint = 0;
    public int roundPoint = 0;
    private float seconds = 4;
    public float timer;
    public float timer2;
    public float timer3;
    public float timer4 = 20.0f;
    public float timer5;
    public Vector3 Point;
    public Vector3 start;
    public static bool randomCard = true;
    public float percent;
    public float percent2;
    public float flip;
    private float fireDelay = 1.5f;
    private float fireTimestamp = 0.0f;

    public void Start()
    {
        fireTimestamp = Time.realtimeSinceStartup + fireDelay;
        PlayerZone = GameObject.FindGameObjectWithTag("PlayerZone");
    }

    public void Update()
    {
        if (PlayerZone.transform.childCount > 0 && EnemyArea.transform.childCount > 0)
        {
            if (DragDrop.isOverDropZone == true && DragDrop.isDraggin2 == false)
            {
                if (timer4 < 0.0f)
                {
                    timer2 = 0.0f;
                    if (timer <= seconds)
                    {
                        if (ThirdCard == EnemyArea.transform.GetChild(ChooseEnemyCard.cardNumber).gameObject)
                        {
                            if (EnemyZone.transform.childCount < 1)
                            {
                                timer += Time.deltaTime;
                                percent = timer / seconds;

                                float step = 1.5f * Time.deltaTime;

                                transform.position = Vector3.Lerp(EnemyArea.transform.GetChild(ChooseEnemyCard.cardNumber).transform.position, EnemyZone.transform.position, step);

                                if (percent > 1)
                                {
                                    EnemyArea.transform.GetChild(ChooseEnemyCard.cardNumber).transform.SetParent(EnemyZone.transform);
                                    PlayerZone.transform.GetChild(0).transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                                    GameObject EnemyCard = Instantiate(EnemyCard2, new Vector3(0, 0, 0), Quaternion.identity);
                                    EnemyCard.transform.SetParent(EnemyZone.transform);
                                    EnemyZone.transform.GetChild(1).transform.rotation = Quaternion.Euler(new Vector3(180, -90, 0));
                                    EnemyCard.SetActive(false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    timer4 -= 1.0f;
                }
            }
        }
        else
        {
            timer2 += Time.deltaTime;
            timer4 = 20.0f;
        }

        if (percent > 1)
        {
            timer3 += Time.deltaTime;
            flip = timer3 * 60;
            if (flip < 180)
            {
                EnemyZone.transform.GetChild(0).transform.Rotate(0, Time.deltaTime * 60, 0, Space.Self);
                DragDrop.cardRewerse.transform.Rotate(0, Time.deltaTime * 60, 0, Space.Self);
                if (flip > 90 && flip < 180)
                {
                    PlayerZone.transform.GetChild(0).gameObject.SetActive(true);
                    PlayerZone.transform.GetChild(1).gameObject.SetActive(false);
                    if (EnemyZone.transform.childCount > 1)
                    {
                        EnemyZone.transform.GetChild(0).transform.SetParent(Deck.transform);
                        EnemyZone.transform.GetChild(0).transform.Rotate(0, Time.deltaTime * 60, 0, Space.Self);
                    }
                    EnemyZone.transform.GetChild(0).gameObject.SetActive(true);

                    PlayerZone.transform.GetChild(0).transform.Rotate(0, Time.deltaTime * 60, 0, Space.Self);
                }
            }

            if (flip > 300 && roundPoint == 0)
            {
                if (PlayerZone.transform.GetChild(0).gameObject.name == "Card1(Clone)")
                {
                    if (EnemyZone.transform.GetChild(0).gameObject.name == "Card3(Clone)")
                    {
                        ScorePoints.AddPlayerPoint();
                        isPlayerPoint = 1;
                    }
                    else if (EnemyZone.transform.GetChild(0).gameObject.name == "Card4(Clone)")
                    {
                        ScorePoints.AddEnemyPoint();
                        isEnemyPoint = 1;
                    }
                }
                if (PlayerZone.transform.GetChild(0).gameObject.name == "Card3(Clone)")
                {
                    if (EnemyZone.transform.GetChild(0).gameObject.name == "Card1(Clone)")
                    {
                        ScorePoints.AddEnemyPoint();
                        isEnemyPoint = 1;
                    }
                    else if (EnemyZone.transform.GetChild(0).gameObject.name == "Card4(Clone)")
                    {
                        ScorePoints.AddPlayerPoint();
                        isPlayerPoint = 1;
                    }
                }
                if (PlayerZone.transform.GetChild(0).gameObject.name == "Card4(Clone)")
                {
                    if (EnemyZone.transform.GetChild(0).gameObject.name == "Card1(Clone)")
                    {
                        ScorePoints.AddPlayerPoint();
                        isPlayerPoint = 1;
                    }
                    else if (EnemyZone.transform.GetChild(0).gameObject.name == "Card3(Clone)")
                    {
                        ScorePoints.AddEnemyPoint();
                        isEnemyPoint = 1;
                    }
                }

                roundPoint = 1;
                }

                if (flip > 300 && EnemyZone.transform.childCount > 0 && PlayerZone.transform.childCount > 0)
                {
                    timer5 += Time.deltaTime;
                    percent2 = timer5 / seconds;

                    float step = 1.5f * Time.deltaTime;

                    EnemyZone.transform.GetChild(0).transform.position = Vector3.Lerp(EnemyZone.transform.GetChild(0).transform.position, Trash.transform.position, step);
                    PlayerZone.transform.GetChild(0).transform.position = Vector3.Lerp(PlayerZone.transform.GetChild(0).transform.position, Trash.transform.position, step);

                    if (percent2 > 0.9)
                    {
                        roundPoint = 0;
                        randomCard = true;
                        Destroy(PlayerZone.transform.GetChild(0).gameObject);
                        Destroy(PlayerZone.transform.GetChild(1).gameObject);
                        Destroy(EnemyZone.transform.GetChild(0).gameObject);
                        Destroy(Deck.transform.GetChild(5).gameObject);
                    }

                if (randomCard == true)
                {
                    ChooseEnemyCard.RandomNumber();
                    randomCard = false;
                }
            }
        }
    }
}