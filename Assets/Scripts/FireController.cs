﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public float speed = 20f;

    public Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (velocity != null)
            transform.Translate(velocity * Time.deltaTime * speed);

        float dist = (transform.position - Camera.main.transform.position).z;
        float leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        float rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        float bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        float topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;

        if (transform.position.y > topBorder ||
            transform.position.y < bottomBorder ||
            transform.position.x > rightBorder ||
            transform.position.x < leftBorder)
        {
            Destroy(gameObject);
        }


    }

    public void InitPosition(Vector3 p, Vector3 v)
    {
        transform.position = p;
        velocity = v;
    }


}
