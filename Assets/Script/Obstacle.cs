using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Robot robot;
    // Start is called before the first frame update
    void Start()
    {
        robot = GameObject.FindObjectOfType<Robot>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.inst.Health();
        }
    }
}
