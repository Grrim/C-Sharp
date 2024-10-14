using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCards : MonoBehaviour
{
    public GameObject PlayerZone;
    public GameObject CardWait;
    public static int cardNumber;
    public static int i;
    public static bool blockPause;
    private float fireDelay = 0.1f;
    private float fireTimestamp = 0.0f;

    void Start()
    {
        fireTimestamp = Time.realtimeSinceStartup + fireDelay;
        i = 8;
    }

    void Update()
    {
        if (i > 0)
        {
            blockPause = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            blockPause = false;
            Cursor.lockState = CursorLockMode.None;
        }
        if (i >= 0 && Time.realtimeSinceStartup > fireTimestamp)
        {
            if (fireTimestamp > 3)
            {
                cardNumber = i;
                CardWait.transform.GetChild(cardNumber).transform.SetParent(PlayerZone.transform);
                i--;
                fireTimestamp = fireTimestamp + 0.5f;
            }
            else
            {
                fireTimestamp++;
            }
        }
    }
}
