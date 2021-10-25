using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimation : MonoBehaviour
{
    private float timeAnimate = 1;
    private int goup = 0;
    private float timeWait = 2;
    public GameObject me;
    public int waitround = 4;
    public float top;
    public float bottom;
    
    //public GameObject playerChar;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(-90,0,0);
        me = GameObject.Find("char (1)");
        top = 0.45f;
        bottom = 0.52f;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y <= me.transform.position.y-bottom && waitround == 4) {
            transform.position = new Vector3(transform.position.x, me.transform.position.y-bottom, transform.position.z);
            waitround = 1;
        }
        if(waitround == 1 && timeWait <= 2){
            timeWait -= Time.deltaTime;
        }
        if (waitround == 1 && timeWait <= 0){
            timeWait = 2;
            waitround =2;
        }
        if( waitround == 2 && transform.position.y <=  me.transform.position.y-top){
            transform.position = new Vector3(transform.position.x, transform.position.y + (float)0.005, transform.position.z);
        }
        if(waitround == 2 && transform.position.y >=  me.transform.position.y-top){
            transform.position = new Vector3(transform.position.x, me.transform.position.y-top, transform.position.z);
            waitround = 3;
        }
        if (waitround == 3 && timeAnimate <= 1){
            timeAnimate -= Time.deltaTime;
        }
        if(waitround == 3 && timeAnimate <= 0 ){
            waitround = 4;
            timeAnimate = 1;
        }
        if(waitround == 4 && transform.position.y >= me.transform.position.y-bottom){
            transform.position = new Vector3(transform.position.x, transform.position.y - (float)0.005, transform.position.z);
        }










        
        // // going up
        // if (timeAnimate >= 0 && goup == 0) {
            
        //     transform.position = new Vector3(transform.position.x, transform.position.y + (float)0.005, transform.position.z);
        //     timeAnimate -= Time.deltaTime;
        //     timeAnimate = 1;
        // }
        // // reach top
        // if (transform.position.y >= me.transform.position.y-0.4f) {
        //     transform.position = new Vector3(transform.position.x, me.transform.position.y-0.4f, transform.position.z);
        //     goup = 1;
        // }
        // // cool down
        // if (timeWait >= 0 && goup == 1) {
        //     timeWait -= Time.deltaTime;
        // }
        // // going to continue
        // if (timeWait <= 0 && goup == 1) {
        //     timeWait = 2;
        //     goup = 2;
        // }
        // // going down
        // if (timeAnimate >= 0 && goup == 2) {
            
        //     transform.position = new Vector3(transform.position.x, transform.position.y - (float)0.005, transform.position.z);
        //     timeAnimate -= Time.deltaTime;
        //     timeAnimate = 1;
        // }
        // // reach bottom
        // if (transform.position.y <= me.transform.position.y-0.52f) {
        //     transform.position = new Vector3(transform.position.x, me.transform.position.y-0.52f, transform.position.z);
        //     goup = 0;
        // }

        
        

    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("eiei");
        if (collision.gameObject.tag == "floortag")
        {
            Debug.Log("hi floor");
        }
        // collide with obs
        if (collision.gameObject.tag == "obstacle_col") {
            Debug.Log("hi myself");
            Destroy(collision.gameObject);
        } 
        // if out of floor and player but not necessary
        // if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "floortag")
        // {
        //     Debug.Log("hi OUTSIDE");
        //     Destroy(gameObject);
        // }

    }

}
