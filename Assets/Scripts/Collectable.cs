﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        Player.Items += 1;
        Destroy(this.gameObject);
    }
}
