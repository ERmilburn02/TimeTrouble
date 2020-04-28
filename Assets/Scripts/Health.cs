using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public GameObject h1;
    public GameObject h2;
    public GameObject h3;

    // Update is called once per frame
    void Update()
    {
        if (Player.Health == 3)
        {
            h3.SetActive(true);
        } else
        {
            h3.SetActive(false);
        }
        if (Player.Health >= 2)
        {
            h2.SetActive(true);
        } else
        {
            h2.SetActive(false);
        }
        if (Player.Health >= 1)
        {
            h1.SetActive(true);
        } else
        {
            h1.SetActive(false);
        }
    }
}
