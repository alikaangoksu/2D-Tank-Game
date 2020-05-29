using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    private string direction;
    private float turnTime;
    public GameObject enemy;
    private Vector3 current;
    private float shootingRate;
    public GameObject Projectiles;
    public Sprite explosion;
    public bool isAlive = true;
    public Rigidbody2D myRigidBody;
    public int enemyCounter=4;
    public AudioSource explode;
    public AudioSource missile;

    int temp;
    // Start is called before the first frame update
    void Start()
    {
        
        temp  = Random.Range(0, 4);
        if (temp == 0) direction = "up";
        if (temp == 1) direction = "down";
        if (temp == 2) direction = "left";
        if (temp == 3) direction = "right";

        turnTime = Random.Range(3f, 5f);
        shootingRate = Random.Range(0f, 5f);

    }

   

    // Update is called once per frame
    void Update()
    {
        enemyC();
        //Debug.Log("Direction" + direction);
        turnTime -= Time.deltaTime;
        if (isAlive)
        {

       
       if (turnTime<0)
        {
            turnTime = Random.Range(3f, 6f);
           
             temp = Random.Range(0, 4);
            if (temp == 0) direction = "up";
            if (temp == 1) direction = "down";
            if (temp == 2) direction = "left";
            if (temp == 3) direction = "right";
        }
        if (direction=="up" )
        {
            enemy.transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 5f);
        }

        else if (direction == "down" )
        {
            enemy.transform.rotation = Quaternion.Euler(0, 0, 180);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -5f);
        }

        else if (direction == "left" )
        {
            enemy.transform.rotation = Quaternion.Euler(0, 0, 90);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-5f, 0);
        }

        else if (direction == "right" )
        {
            enemy.transform.rotation = Quaternion.Euler(0, 0, -90);
            GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 0);
        }
        
        current = GetComponent<Transform>().position;
        if (current.x > 9.3f && direction == "right")  direction = "left";
        if (current.x < -9f && direction=="left") direction = "right";
        if (current.y < -4f && direction == "down") direction = "up";
        if (current.y > 3.7f && direction == "up") direction = "down";
        

        shootingRate -= Time.deltaTime;
        if (shootingRate<0)
        {
            shootingRate = 3f;
            GameObject rocket;
            rocket= Instantiate(Projectiles,GetComponent<Transform>().position,Quaternion.identity);
                missile.Play();
            rocket.GetComponent<Fire>().from = "enemy";
            rocket.GetComponent<Fire>().direction = direction;
        }
        }
    }

    public int enemyC()
    {
        return enemyCounter;
           
    }

    public void setEnemyCounter()
    {
        enemyCounter = 3;
    }
    /*
    private void OnTriggerExit2D(Collider other)
    {
        if (direction == "left" || direction== "right")
        {
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
        }

        else if (direction== "up" || direction == "down")
        {
            transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.y)), 1f);
        }
        
    }
    */
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Fire rocket = collision.gameObject.GetComponent<Fire>();
            if (rocket.from=="player")
            {
                isAlive = false;
                GetComponent<SpriteRenderer>().sprite = explosion;
                explode.Play();
                Destroy(collision.gameObject);
                Destroy(this.gameObject, 0.5f);
                enemyCounter--;
            }
        }
    }
}
