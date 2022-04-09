using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level4Controller : MonoBehaviour
{
    public GameObject key4;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.key4)
        {
            Destroy(key4.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
