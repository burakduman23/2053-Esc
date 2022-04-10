using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    public GameObject Fire;

    public float speed;

    private bool fire;

    void Start()
    {
        fire = true;    
    }

    // Update is called once per frame
    void Update()
    {
        if(fire)
        {
            Vector3 offset = new Vector3(0f, -1f, 0f);

            GameObject b = Instantiate(Fire, new Vector3(0f, 0f, 0f), Quaternion.AngleAxis(180, Vector2.left));

            b.GetComponent<FireController>().InitPosition(transform.position + offset, new Vector3(0f, speed, 0f));


            fire = false;

            StartCoroutine(PlayerCanFireAgain());

        }



    }

    IEnumerator PlayerCanFireAgain()
    {
        //this will pause the execution of this method for 3 seconds without blocking
        yield return new WaitForSecondsRealtime(2);
        fire = true;
    }


}
