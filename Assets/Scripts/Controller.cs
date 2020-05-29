using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public GameObject player;
    private string direction;
    public GameObject projectiles;
    public AudioSource missile;
    private float shootingRate = 1f;
    // public AudioSource moveSound;     I shut it down since it doesnt work smoothly as ı want.

    // Start is called before the first frame update
    void Start()
    {
        
    }
   
    
    // Update is called once per frame
   
    void Update()
    {
        if (FindObjectOfType<Enemy>().enemyC()==0)
        {
            SceneManager.LoadScene(3);
        }  
        if (Input.GetKey("up"))                      
        {
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);
            direction = "up";
            
        }
        else if (Input.GetKey("down"))
        {
            player.transform.rotation = Quaternion.Euler (0, 0, 180);         
             GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
            direction = "down";
            
        }
        else if (Input.GetKey("left"))
        {
            player.transform.rotation = Quaternion.Euler (0, 0, 90);         
             GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0);
            direction = "left";
            
        }
        else if (Input.GetKey("right"))
        {
            player.transform.rotation = Quaternion.Euler (0, 0, -90);         
             GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0);
            direction = "right";
          
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
        shootingRate += Time.deltaTime;
        if (shootingRate> 1f)
        {
         if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject projectile;
            projectile = Instantiate(projectiles,GetComponent<Transform>().position,Quaternion.identity);
            missile.Play();
            projectile.GetComponent<Fire>().direction = direction;
            projectile.GetComponent<Fire>().from = "player";
            Destroy(projectile, 5f);
                shootingRate = 0f;

        }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Fire rocket = collision.gameObject.GetComponent<Fire>();
            if (rocket.from=="enemy")
            {
                SceneManager.LoadScene("Game Over");
            }
        }
    }
}
