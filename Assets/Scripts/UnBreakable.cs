using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnBreakable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Fire rocket = collision.gameObject.GetComponent<Fire>();
            Destroy(collision.gameObject);
         


        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
