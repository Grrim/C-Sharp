using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    private bool isDraggin = false;
    public static bool isOverDropZone = false;
    public static bool isDraggin2 = true;
    private Vector2 startPosition;
    private GameObject dropZone;
    public GameObject cardBack;
    public GameObject EnemyCard2;
    public GameObject PlayerArea;
    public static GameObject cardRewerse;
    public static GameObject EnemyCard;
    public GameObject Backlight;

    void Update()
    {
        if (isDraggin)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOverDropZone = false;
        dropZone = null;
    }

    public void StartDrag()
    {
        startPosition = transform.position;
        isDraggin = true;
        Backlight.SetActive(true);
    }

    public void EndDrag()
    {
        isDraggin = false;
        isDraggin2 = false;
        Backlight.SetActive(false);
        if (isOverDropZone)
        {
            if (dropZone.transform.childCount > 0)
            {
                transform.position = startPosition;
            }
            else
            {
                transform.SetParent(dropZone.transform);
                if (transform.parent == dropZone.transform)
                {
                    cardRewerse = Instantiate(cardBack, new Vector3(0, 0, 0), Quaternion.identity);
                    cardRewerse.transform.SetParent(PlayerArea.transform);
                    gameObject.SetActive(false);
                    gameObject.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
                }
            }
        }
        else
        {
            transform.position = startPosition;
        }
    }
}
