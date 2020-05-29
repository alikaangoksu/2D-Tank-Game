using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public string direction ;
    private float speed = 0.1f;
    public string from = "none";
    public GameObject rocket;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (direction=="left")
        {
            rocket.transform.rotation = Quaternion.Euler(0, 0, 90);
            GetComponent<Transform>().position += new Vector3(-speed, 0f);
        }

        else if(direction == "right")
        {
            rocket.transform.rotation = Quaternion.Euler(0, 0, -90);
            GetComponent<Transform>().position += new Vector3(speed, 0f);
        }

        else if (direction == "up")
        {
           rocket.transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Transform>().position += new Vector3(0f,speed);
        }

        else if (direction == "down")
        {
            rocket.transform.rotation = Quaternion.Euler(0, 0, 180);
            GetComponent<Transform>().position += new Vector3(0, -speed, 0);
        }
    }
}
