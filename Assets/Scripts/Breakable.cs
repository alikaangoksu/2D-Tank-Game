using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public AudioSource explode;
    public Sprite explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
                Fire rocket = collision.gameObject.GetComponent<Fire>();
                GetComponent<SpriteRenderer>().sprite = explosion;
                explode.Play();
                Destroy(collision.gameObject);
                Destroy(this.gameObject, 0.5f);
               
            
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
