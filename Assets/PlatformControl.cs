using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    public int x;
    public float speed;
    public gamemanager GameManager;





    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(0,2);
        if (x==0)
        {
            x = -1;
        }

        speed = Random.Range(5, 15);
    }

    // Update is called once per frame
    void Update()
    {        
        SideMove();
        if (transform.position.y <= (Camera.main.transform.position.y - 6))
        {
            GameManager.NextPlat += 5f;
            transform.position = new Vector3(transform.position.x, GameManager.NextPlat, transform.position.z);
            speed = Random.Range(5, 15);

        }
        //gototop();
    }


    void SideMove()
    {
        transform.Translate(x * speed * Time.deltaTime, 0, 0);
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.tag=="wall")
        {
            x *= -1;
        }
    }

    void gototop()
    {
       
    }
    
}
