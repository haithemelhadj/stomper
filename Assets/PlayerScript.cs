using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool grounded=false;
    [SerializeField] private float JumpForce;
    public float Speed;
    private PlatformControl PlatformControl;
    private GameObject other;
    public GameObject Platform;
    public Collider2D Collider2D;
    private Vector3 LastPos;
    public bool GoingDown;
    private float score;
    public bool gameover = false;
    void Start()
    {
        LastPos = transform.position;
        gameover = false;
    }

    
    void Update()
    {
        
        GameOver();

        //slow down time
        if (Input.GetKeyDown("space") && (!grounded))
        {
            rb.drag = 10;
            //Time.timeScale = 0.01f;  //slow motion          
            Camera.main.backgroundColor = Color.blue;
        }
        if (Input.GetKeyUp("space"))
        {
            rb.drag = 1;
            
            //Time.timeScale = 1f;// get back to normal time
            Camera.main.backgroundColor = Color.red;
        }
        // slow down time

        



        if (grounded)
        {
            PlatformControl = other.gameObject.GetComponent<PlatformControl>();
            Speed = PlatformControl.speed * PlatformControl.x;
        }
        Jumper();
        SlowVelovity();
        LastPos = transform.position;
        if (!grounded)
        {
            transform.parent = null;
            score++;
        }
    }

    void Jumper()
    {
        if (Input.GetKeyDown("space"))
        {

            if(grounded)
            {
                rb.AddForce(new Vector2(Speed*80, JumpForce));
                GoingDown = false;
                Speed = PlatformControl.speed * PlatformControl.x;
                grounded = false;
                transform.parent = null;
            }
            else
            {                                    
                    rb.velocity *= 0f;
                    new WaitForSeconds(5 * Time.deltaTime);
                    rb.AddForce(new Vector2(0, -20 * 80));
                
                    
            }
          
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "platform") && (GoingDown))
        {
            grounded = true;
            transform.SetParent(collision.transform);
            other = collision.gameObject;
            
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "platform") )
        {
            grounded = false;
        }
    }

    void AddPlatform()
    {
        Instantiate(Platform, new Vector3(0, Camera.main.transform.position.y+6, 0), Quaternion.identity);
    }


    void SlowVelovity()
    {
        if(LastPos.y>transform.position.y)
        {
            rb.velocity *= 0.95f;
            GoingDown = true;
        }
    }


    void GameOver()
    {
        if (transform.position.y < Camera.main.transform.position.y -5)
        {
            //Debug.Log("ded");
            gameover = true;
            

        }
    }
}






