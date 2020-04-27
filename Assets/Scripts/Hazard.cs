using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.Health -= 1;
        Debug.Log("OUCH!");
        Debug.Log("Player Health " + Player.Health);
    }
}
