using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Playercontrol : MonoBehaviour
{
    // Start is called before the first frame update

    //nene code
    public GameObject obstacle;
    private float spawn_time = 3;
    public Rigidbody rigid;
    public float time;
    public GameObject myself;
    public bool canspawn = true;
    //public int isclimbing = 0;


    private CharacterController _controller;
    private MyControl _playerControl;
    private Animator anim;
    private GlideController Glide;
    //private Vector3 _playerVelocity;
    private bool waiting = false;
    private bool running = false;
    private bool canMove = true;

    private float rotation = 360f;

    private Vector3 playervec;
    [SerializeField] private LayerMask layerMsk;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip playing_sound;
    [SerializeField] private float playerspd = 5f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.8f;
    [SerializeField] private float turnSpd = 180f;
    [SerializeField] private bool grounded;
    [SerializeField] private string SceneName;
    public GameObject plane_ar;
    public GameObject mother;
    public Text timeDisplay;
    public bool gonnaGo;
    Vector3 toJump;
    
    //nene code 2
    private void CreateObs(){
        float xpos = myself.transform.position.x;
        float ypos = myself.transform.position.y;
        float zpos = myself.transform.position.z;
        for (int i = 0; i < 3; i++) {
            float headingto = mother.transform.rotation.eulerAngles.y ;
            // for real
            //Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (-0.3f, 0.3f), plane_ar.transform.position.y - (float)0.52, zpos + UnityEngine.Random.Range(0.3f, 1f)), this.transform.rotation);
            // for test
            //Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (0.1f, 0.5f), ypos - (float)0.52, zpos + UnityEngine.Random.Range(0.3f, 1f)), this.transform.rotation);

            // if (mother.transform.rotation.eulerAngles.y >  0 && 90 >= mother.transform.rotation.eulerAngles.y){
            // Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (0.1f, 0.5f), plane_ar.transform.position.y - (float)0.52, zpos + UnityEngine.Random.Range(0.3f, 1f)), this.transform.rotation);
            // }else if ( mother.transform.rotation.eulerAngles.y >  90 && 180 >= mother.transform.rotation.eulerAngles.y){
            //     Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (-0.3f, 0.3f), plane_ar.transform.position.y - (float)0.52, zpos + UnityEngine.Random.Range(0.3f, 1f)), this.transform.rotation);
            // }else if( mother.transform.rotation.eulerAngles.y <  0 && -90 <= mother.transform.rotation.eulerAngles.y){
            //     Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (-0.3f, 0.3f), plane_ar.transform.position.y - (float)0.52, zpos + UnityEngine.Random.Range(0.3f, 1f)), this.transform.rotation);
            // }else if ( mother.transform.rotation.eulerAngles.y <  -90 && -180 < mother.transform.rotation.eulerAngles.y){
            //     Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (-0.3f, 0.3f), plane_ar.transform.position.y - (float)0.52, zpos + UnityEngine.Random.Range(0.3f, 1f)), this.transform.rotation);
            // } 


            if (mother.transform.rotation.eulerAngles.y >  0 && 90 >= mother.transform.rotation.eulerAngles.y){
                Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (0.1f, 0.3f), ypos - (float)0.52, zpos + UnityEngine.Random.Range(0.3f, 0.8f)), this.transform.rotation);
            }else if ( mother.transform.rotation.eulerAngles.y >  90 && 180 >= mother.transform.rotation.eulerAngles.y){
                Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (0.1f, 0.3f),ypos - (float)0.52, zpos + UnityEngine.Random.Range(-0.8f, -0.3f)), this.transform.rotation);
            }else if( mother.transform.rotation.eulerAngles.y <  0 && -90 <= mother.transform.rotation.eulerAngles.y){
                Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (-0.3f, -0.1f), ypos - (float)0.52, zpos + UnityEngine.Random.Range(0.3f, 0.8f)), this.transform.rotation);
            }else if ( mother.transform.rotation.eulerAngles.y <  -90 && -180 < mother.transform.rotation.eulerAngles.y){
                Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (-0.3f, -0.1f), ypos - (float)0.52, zpos + UnityEngine.Random.Range(-0.8f, -0.3f)), this.transform.rotation);
            } 







            // else {
            //     Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (-0.3f, 0.3f), plane_ar.transform.position.y - (float)0.52, zpos + UnityEngine.Random.Range(0.3f, 1f)), this.transform.rotation);
            // }
            //Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range (-0.3f, 0.3f), plane_ar.transform.position.y - (float)0.52, zpos + UnityEngine.Random.Range(0.3f, 1f)), this.transform.rotation);
        }
    }

    void Start()
    {
        Debug.Log("Start");
        anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
        time = 200;
        audioSource.PlayOneShot(playing_sound, 0.5f);
    }
    IEnumerator Hover()
    {
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Rigidbody>().useGravity = true;
        // StopCoroutine(Hover());
    }
    private void Hunnn()
    {
        Debug.Log("general kinobi");
        if (Physics.Raycast(transform.position + new Vector3(0f,1f,0f), transform.forward, Mathf.Infinity, layerMsk)){
            // mother.transform.Translate(new Vector3(0f,0.0001f,0f));
            rigid.AddForce(transform.up * 0.1f);
            
            }
        mother.transform.Translate(new Vector3(0f,1f,0f));
        gonnaGo = false;
        StartCoroutine(Hover());
    }
    private void Awake(){
        _playerControl = new MyControl();
        Glide = new GlideController();
    }

    private void OnEnable(){
        _playerControl.Enable();
    }

    private void OnDisable(){
        _playerControl.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        time = time - (float)Time.deltaTime;
         if (time < 0){
             timeDisplay.text = "Time\n0.00";
             canMove = false;
             SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }else{
             timeDisplay.text = "Time\n" + time.ToString("#.00");
         }

        
        
        if (canMove){
            if (!waiting) {
                if(_playerControl.Player.forward.ReadValue<float>() > 0){

                    if (mother.transform.rotation.eulerAngles.y == 0){
                        //anim.Play("Base Layer.Sprint");
                        running = true;
                        Vector3 move = mother.transform.forward * _playerControl.Player.forward.ReadValue<float>();
                        mother.transform.Translate(new Vector3(0f,0f,0.005f));
                        // _controller.Move(move * playerspd * Time.deltaTime); // This does not work for some reason
                    } else{
                        
                        if (mother.transform.rotation.eulerAngles.y == 270 || mother.transform.rotation.eulerAngles.y == 180){
                            //anim.Play("Base Layer.Turn Right 90");
                            mother.GetComponent<Transform>().Rotate(0, 90 , 0);
                        }else{
                            //anim.Play("Base Layer.Turn Left 90");
                            mother.GetComponent<Transform>().Rotate(0, -90 , 0);
                        }
                        waiting = true;
                    }
                    

                }else if(_playerControl.Player.backward.ReadValue<float>() > 0) {

                    if (mother.transform.rotation.eulerAngles.y == 180){
                        //anim.Play("Base Layer.Sprint");
                        running = true;
                        Vector3 move = transform.forward * _playerControl.Player.backward.ReadValue<float>();
                        // _controller.Move(move * playerspd * Time.deltaTime);
                        mother.transform.Translate(new Vector3(0f,0f,0.005f));
                    }else{
                        
                        if (mother.transform.rotation.eulerAngles.y == 0 || mother.transform.rotation.eulerAngles.y == 270){
                            //anim.Play("Base Layer.Turn Left 90");
                            mother.GetComponent<Transform>().Rotate(0, -90 , 0);
                        }else{
                            //anim.Play("Base Layer.Turn Right 90");
                            mother.GetComponent<Transform>().Rotate(0, 90 , 0);
                        }
                        waiting = true;
                    }

                }else if(_playerControl.Player.left.ReadValue<float>() > 0){

                    if (mother.transform.rotation.eulerAngles.y == 270){
                        //anim.Play("Base Layer.Sprint");
                        running = true;
                        Vector3 move = transform.forward * _playerControl.Player.left.ReadValue<float>();
                        // _controller.Move(move * playerspd * Time.deltaTime);
                        mother.transform.Translate(new Vector3(0f,0f,0.005f));

                    }else{
                        
                        if (mother.transform.rotation.eulerAngles.y == 180 || mother.transform.rotation.eulerAngles.y == 90){
                            //anim.Play("Base Layer.Turn Right 90");
                            mother.GetComponent<Transform>().Rotate(0, 90 , 0);
                        }else{
                            //anim.Play("Base Layer.Turn Left 90");
                            mother.GetComponent<Transform>().Rotate(0, -90 , 0);
                        }
                        waiting = true;
                    }
                }
                else if(_playerControl.Player.right.ReadValue<float>() > 0){

                    if (mother.transform.rotation.eulerAngles.y == 90){
                        //anim.Play("Base Layer.Sprint");
                        running = true;
                        Vector3 move = transform.forward * _playerControl.Player.right.ReadValue<float>();
                        // _controller.Move(move * playerspd * Time.deltaTime);
                        mother.transform.Translate(new Vector3(0f,0f,0.005f));

                    }else{
                        
                        if (mother.transform.rotation.eulerAngles.y == 0 || mother.transform.rotation.eulerAngles.y == -90){
                            //anim.Play("Base Layer.Turn Right 90");
                            mother.GetComponent<Transform>().Rotate(0, 90 , 0);
                        }else{
                            //anim.Play("Base Layer.Turn Left 90");
                            mother.GetComponent<Transform>().Rotate(0, -90 , 0);
                        }
                        waiting = true;
                    }
                }

                else if(_playerControl.Player.jump.triggered){
                    // playervec = mother.transform.forward * 2;
                    // playervec.y = Mathf.Sqrt(1f * -2.0f * gravityValue);
                    mother.transform.Translate(new Vector3(0f,0.05f,0f));
                    mother.transform.Translate(new Vector3(0f,0f,0.04f));
                    //anim.Play("Base Layer.Jumping");
                    waiting = true;
                    
                }
                
                else if (running){

                    //anim.Play("Base Layer.Stop Walking");
                    running = false;
                    waiting = true;

                }else{

                    //anim.Play("Base Layer.Ninja Idle");

                }
            }else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Ninja Idle")){
                    waiting = false;
                    playervec = new Vector3(0,0,0);
                }
            //Falling out of bound respawn function
            if (mother.transform.position.y <= -5) {
                mother.transform.SetPositionAndRotation(GameObject.FindGameObjectWithTag("Start").transform.position + new Vector3(0f,0.5f,0f), mother.transform.rotation);
            }

            float angleX = transform.rotation.eulerAngles.x;  
            float angleY = transform.rotation.eulerAngles.y; 
            float angleZ = transform.rotation.eulerAngles.z;
            Vector3 fwd = new Vector3 (angleX,angleY,angleZ);
            RaycastHit hit;

            if (_playerControl.Player.climb.ReadValue<float>() > 0)
            {
                if (Physics.Raycast(transform.position + new Vector3(0f,0.1f,0f), transform.forward, out hit,  2f, layerMsk)){
                    Debug.Log(hit.collider.tag);
                    if (hit.collider.tag == "wall"){
                        if (gonnaGo == false){
                            gonnaGo = true;
                            gameObject.GetComponent<Rigidbody>().useGravity = false;
                            // Debug.Log(gonnaGo);
                            toJump = new Vector3(mother.transform.position.x - hit.transform.position.x, 0f, mother.transform.position.z - hit.transform.position.z);
                            // if (Physics.Raycast(transform.position + new Vector3(0f,1f,0f), transform.forward, out hit, Mathf.Infinity, layerMsk)){
                            // mother.transform.Translate(new Vector3(0f,0.01f,0f));
                            mother.transform.position = Vector3.Lerp(mother.transform.position, mother.transform.position + new Vector3(0f, hit.collider.bounds.size.y + 1f, 0f), 0.5f * Time.deltaTime);
                            // mother.transform.Translate(new Vector3(0f,1.5f,0f));
                            gonnaGo = false;
                            //isclimbing = 1;
                            // StartCoroutine(Hover());
                        }
                        Debug.DrawRay(transform.position + new Vector3(0f,1f,0f),transform.forward,Color.red, 1.0f);
                    }
                    // if(hit.transform == null){
                    //     // toJump = new Vector3(mother.transform.position.x - hit.transform.position.x, 0f, mother.transform.position.z - hit.transform.position.z);
                    //     Debug.Log(mother.transform.position);
                    //     mother.transform.Translate(0f, 0f, 2f);
                    //     gameObject.GetComponent<Rigidbody>().useGravity = true;
                    // }
                }else{
                    gameObject.GetComponent<Rigidbody>().useGravity = true;
                }
            }
            spawn_time -= Time.deltaTime;
            if (spawn_time <= 0) {
                if(canspawn){
                CreateObs();
                }
                spawn_time = 5;
            }
        }
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("collide");
        
        if (collision.gameObject.tag == "obstacle_col") {
            Debug.Log("hi myself");
            time -= 5f;
            Destroy(collision.gameObject);
        } 
        
    }
}
