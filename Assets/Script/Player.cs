using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontal, vertical, speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward *Time.deltaTime * speed * vertical);
        transform.Translate(Vector3.right *Time.deltaTime * speed * horizontal);
        transform.Rotate(Vector3.up * speed * horizontal * Time.deltaTime);
    }
}
