using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimation : MonoBehaviour
{
    private float timeAnimate = 1;
    private int goup = 0;
    private float timeWait = 2;
    public GameObject me;
    
    //public GameObject playerChar;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(-90,0,0);
        me = GameObject.Find("char (1)");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (timeAnimate >= 0 && goup == 0) {
            
            transform.position = new Vector3(transform.position.x, transform.position.y + (float)0.005, transform.position.z);
            timeAnimate -= Time.deltaTime;
            timeAnimate = 1;
        }

        if (transform.position.y >= me.transform.position.y-0.48) {
            goup = 1;
        }

        if (timeWait >= 0 && goup == 1) {
            timeWait -= Time.deltaTime;
        }

        if (timeWait <= 0 && goup == 1) {
            timeWait = 2;
            goup = 2;
        }

        if (timeAnimate >= 0 && goup == 2) {
            
            transform.position = new Vector3(transform.position.x, transform.position.y - (float)0.005, transform.position.z);
            timeAnimate -= Time.deltaTime;
            timeAnimate = 1;
        }

        if (transform.position.y <= me.transform.position.y-0.52) {
            goup = 0;
        }

        
        

    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("eiei");
        if (collision.gameObject.tag == "floortag")
        {
            Debug.Log("hi floor");
        }
        if (collision.gameObject.tag == "obstacle_col") {
            Debug.Log("hi myself");
            Destroy(collision.gameObject);
        } 
        if (collision.gameObject.tag != "Player" && collision.gameObject.tag != "floortag")
        {
            Debug.Log("hi OUTSIDE");
            Destroy(gameObject);
        }

    }

}
