using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    // Start is called before the first frame update

    //nene code
    public GameObject obstacle;
    private float spawn_time = 3;
    public Rigidbody rigid;



    private CharacterController _controller;
    private MyControl _playerControl;
    private Animator anim;

    private GlideController Glide;
    //private Vector3 _playerVelocity;

    private bool waiting = false;
    private bool running = false;

    private float rotation = 360f;

    private Vector3 playervec;
    [SerializeField] private LayerMask layerMsk;
    [SerializeField] private float playerspd = 5f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.8f;
    [SerializeField] private float turnSpd = 180f;
    [SerializeField] private bool grounded;
    public GameObject mother;
    
    //nene code 2
    private void CreateObs(){
        float xpos = rigid.position.x;
        float ypos = rigid.position.y;
        float zpos = rigid.position.z;
        for (int i = 0; i < 3; i++) {
            Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range(-3f, 3f), ypos - (float)0.750213, zpos + UnityEngine.Random.Range(3f, 10f)), this.transform.rotation);

        }
    }

    void Start()
    {
        Debug.Log("Start");
        anim = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();

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
        if (!waiting) {
            if(_playerControl.Player.forward.ReadValue<float>() > 0){

                if (mother.transform.rotation.eulerAngles.y == 0){
                    anim.Play("Base Layer.Sprint");
                    running = true;
                    Vector3 move = mother.transform.forward * _playerControl.Player.forward.ReadValue<float>();
                    mother.transform.Translate(new Vector3(0f,0f,0.005f));
                    _controller.Move(move * playerspd * Time.deltaTime); // This does not work for some reason
                } else{
                    
                    if (mother.transform.rotation.eulerAngles.y == 270 || mother.transform.rotation.eulerAngles.y == 180){
                        anim.Play("Base Layer.Turn Right 90");
                        mother.GetComponent<Transform>().Rotate(0, 90 , 0);
                    }else{
                        anim.Play("Base Layer.Turn Left 90");
                        mother.GetComponent<Transform>().Rotate(0, -90 , 0);
                    }
                    waiting = true;
                }
                

            }else if(_playerControl.Player.backward.ReadValue<float>() > 0) {

                if (mother.transform.rotation.eulerAngles.y == 180){
                    anim.Play("Base Layer.Sprint");
                    running = true;
                    Vector3 move = transform.forward * _playerControl.Player.backward.ReadValue<float>();
                    _controller.Move(move * playerspd * Time.deltaTime);
                    mother.transform.Translate(new Vector3(0f,0f,0.005f));
                }else{
                    
                    if (mother.transform.rotation.eulerAngles.y == 0 || mother.transform.rotation.eulerAngles.y == 270){
                        anim.Play("Base Layer.Turn Left 90");
                        mother.GetComponent<Transform>().Rotate(0, -90 , 0);
                    }else{
                        anim.Play("Base Layer.Turn Right 90");
                        mother.GetComponent<Transform>().Rotate(0, 90 , 0);
                    }
                    waiting = true;
                }

            }else if(_playerControl.Player.left.ReadValue<float>() > 0){

                if (mother.transform.rotation.eulerAngles.y == 270){
                    anim.Play("Base Layer.Sprint");
                    running = true;
                    Vector3 move = transform.forward * _playerControl.Player.left.ReadValue<float>();
                    _controller.Move(move * playerspd * Time.deltaTime);
                    mother.transform.Translate(new Vector3(0f,0f,0.005f));

                }else{
                    
                    if (mother.transform.rotation.eulerAngles.y == 180 || mother.transform.rotation.eulerAngles.y == 90){
                        anim.Play("Base Layer.Turn Right 90");
                        mother.GetComponent<Transform>().Rotate(0, 90 , 0);
                    }else{
                        anim.Play("Base Layer.Turn Left 90");
                        mother.GetComponent<Transform>().Rotate(0, -90 , 0);
                    }
                    waiting = true;
                }
            }
            else if(_playerControl.Player.right.ReadValue<float>() > 0){

                if (mother.transform.rotation.eulerAngles.y == 90){
                    anim.Play("Base Layer.Sprint");
                    running = true;
                    Vector3 move = transform.forward * _playerControl.Player.right.ReadValue<float>();
                    _controller.Move(move * playerspd * Time.deltaTime);
                    mother.transform.Translate(new Vector3(0f,0f,0.005f));

                }else{
                    
                    if (mother.transform.rotation.eulerAngles.y == 0 || mother.transform.rotation.eulerAngles.y == -90){
                        anim.Play("Base Layer.Turn Right 90");
                        mother.GetComponent<Transform>().Rotate(0, 90 , 0);
                    }else{
                        anim.Play("Base Layer.Turn Left 90");
                        mother.GetComponent<Transform>().Rotate(0, -90 , 0);
                    }
                    waiting = true;
                }
            }

            else if(_playerControl.Player.jump.triggered){
                playervec = mother.transform.forward * 2;
                playervec.y = Mathf.Sqrt(1f * -2.0f * gravityValue);
                // mother.transform.rotation.eulerAngles.y
                anim.Play("Base Layer.Jumping");
                waiting = true;
                
            }
            
            else if (running){

                anim.Play("Base Layer.Stop Walking");
                running = false;
                waiting = true;

            }else{

                anim.Play("Base Layer.Ninja Idle");

            }
        }else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Ninja Idle")){
                waiting = false;
                playervec = new Vector3(0,0,0);
            }


        float angleX = transform.rotation.eulerAngles.x;  
        float angleY = transform.rotation.eulerAngles.y; 
        float angleZ = transform.rotation.eulerAngles.z;
        Vector3 fwd = new Vector3 (angleX,angleY,angleZ);
        RaycastHit hit;

        if (_playerControl.Player.climb.ReadValue<float>() > 0)
        {
            Debug.DrawRay(transform.position + new Vector3(0f,1f,0f),transform.forward,Color.red, 1.0f);
            // Vector3 fwd = transform.TransformDirection(Vector3.forward);
            // int layer = 1 << 3;
            //int layerMask = 1 << 3;
            //layerMask = ~layerMask;
            if (Physics.Raycast(transform.position + new Vector3(0f,1f,0f), transform.forward, out hit,  Mathf.Infinity, layerMsk)){
                Debug.DrawRay(transform.position + new Vector3(0f,1f,0f),transform.forward,Color.red, 1.0f);
                if (hit.collider.tag == "wall"){
                    float tall = hit.collider.bounds.size.y;
                    playervec.y = Mathf.Sqrt(tall * -2.0f * gravityValue);
                }
                Debug.Log(hit.collider.tag);
            }
            //Debug.Log(fwd);
            Debug.Log(transform.forward);
        }

        playervec.y += gravityValue * Time.deltaTime;
        _controller.Move(playervec * Time.deltaTime);
        
        //nene code 3
        spawn_time -= Time.deltaTime;
        if (spawn_time <= 0) {
                CreateObs();
                spawn_time = 5;
            }

    }
}
