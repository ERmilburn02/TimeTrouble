using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public AudioSource pickupsfx;
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.Items += 1;
        pickupsfx.Play();
        // Destroy(this.gameObject);
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
    }
}
