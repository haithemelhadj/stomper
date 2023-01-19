using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager : MonoBehaviour
{

    public GameObject Player;
    public GameObject Platform;
    bool MoveCam;
    private PlayerScript PlayerScript;
    public float NextPlat;
    //private float score = 0;

    // Start is called before the first frame update
    void Start()
    {
        NextPlat = 11f;
        //score = (NextPlat - 11f) / 5f;
        //Debug.Log(score);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerScript = Player.gameObject.GetComponent<PlayerScript>();
        GoDown();
        if(PlayerScript.gameover)
        {
            SceneManager.LoadScene(0);
        }
    }


    void GoDown()
    {
        
        if ((Player.transform.position.y > Camera.main.transform.position.y+1) && (PlayerScript.grounded)&&(PlayerScript.GoingDown))
        {
            //transform.Translate(0, x * speed * Time.deltaTime, 0);
             MoveCam = true;
        }
        if(Player.transform.position.y<=Camera.main.transform.position.y-3)
        {
            MoveCam = false;
        }

        if((MoveCam)&&(Player.transform.position.y > Camera.main.transform.position.y - 4f))
        {
            Camera.main.transform.Translate(0, 10 * Time.deltaTime, 0);
        }
    }





}




/* -----bugs-----
 -platforms spawn inside of the camera
 -if the player fell into the same platform , platforms spawn again
 -
 
 
 
 */