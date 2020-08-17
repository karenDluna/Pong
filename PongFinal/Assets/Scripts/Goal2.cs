using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal2 : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Player 1 Scored...");
            GameObject.Find("GameManager").GetComponent<GameManager>().Player1Scored();
        }
    }
}
