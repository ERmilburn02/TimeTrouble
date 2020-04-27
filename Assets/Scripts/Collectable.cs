using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Inventory.Items += 1;
        Destroy(this.gameObject);
    }
}
