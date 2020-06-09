using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public AudioSource hurtsfx;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.Health -= 1;
        hurtsfx.Play();
    }
}
