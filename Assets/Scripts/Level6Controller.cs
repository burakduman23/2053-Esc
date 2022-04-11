using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level6Controller : MonoBehaviour
{

    public GameObject key6, paper;
    // Start is called before the first frame update
    void Start()
    {
        if (GameController.key6)
            Destroy(key6.gameObject);

    }
    // Update is called once per frame
    void Update()
    {
        if (GameController.key6)
        {
            paper.SetActive(true);
        }
        else
        {
            paper.SetActive(false);
        }
    }
}
