using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal1 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Player 2 Scored...");
            GameObject.Find("GameManager").GetComponent<GameManager>().Player2Scored();
        }
    }
}
