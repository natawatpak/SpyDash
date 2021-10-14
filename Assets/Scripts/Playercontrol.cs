using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    // Start is called before the first frame update

    private CharacterController _controller;
    private MyControl _playerControl;
    private Animator anim;

    private GlideController Glide;
    //private Vector3 _playerVelocity;

    private bool waiting = false;
    private bool running = false;

    private float rotation = 360f;

    ///////////////////////////////////////////

    private Vector3 playervec;
    [SerializeField] private LayerMask layerMsk;
    [SerializeField] private float playerspd = 5f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.8f;
    [SerializeField] private float turnSpd = 180f;
    [SerializeField] private bool grounded;

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
        if (!waiting){
            if(_playerControl.Player.forward.ReadValue<float>() > 0){

                if (rotation == 360 || rotation == 0){
                    anim.Play("Base Layer.Sprint");
                    running = true;
                }else{
                    
                    if (rotation == 270 || rotation == 180){
                        rotation += 90;
                        anim.Play("Base Layer.Turn Right 90");
                    }else{
                        rotation -= 90;
                        anim.Play("Base Layer.Turn Left 90");
                    }
                    waiting = true;
                }
                
                

            }else if(_playerControl.Player.backward.ReadValue<float>() > 0) {

                if (rotation == 180){
                    anim.Play("Base Layer.Sprint");
                    running = true;
                }else{
                    
                    if (rotation == 360 || rotation == 270){
                        rotation -= 90;
                        anim.Play("Base Layer.Turn Left 90");
                    }else{
                        rotation += 90;
                        anim.Play("Base Layer.Turn Right 90");
                    }
                    waiting = true;
                }

            }else if(_playerControl.Player.left.ReadValue<float>() > 0){

                if (rotation == 270){
                    anim.Play("Base Layer.Sprint");
                    running = true;

                }else{
                    
                    if (rotation == 180 || rotation == 90){
                        anim.Play("Base Layer.Turn Right 90");
                        rotation += 90f;
                    }else{
                        anim.Play("Base Layer.Turn Left 90 0");
                        rotation -= 90f;
                    }
                    waiting = true;
                }
            }
            else if(_playerControl.Player.right.ReadValue<float>() > 0){

                if (rotation == 90){
                    anim.Play("Base Layer.Sprint");
                    running = true;

                }else{
                    
                    if (rotation == 360){
                        anim.Play("Base Layer.Turn Right 90");
                        rotation = 90f;
                    }else{
                        anim.Play("Base Layer.Turn Left 90");
                        rotation -= 90f;
                    }
                    waiting = true;
                }
            }

            else if(_playerControl.Player.jump.triggered){

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
            }

        Debug.Log(rotation);

        float angleX = transform.rotation.eulerAngles.x;  
        float angleY = transform.rotation.eulerAngles.y; 
        float angleZ = transform.rotation.eulerAngles.z;
        Vector3 fwd = new Vector3 (angleX,angleY,angleZ);
        RaycastHit hit;

        if (_playerControl.Player.climb.ReadValue<float>() > 0)
        {
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
            }
            //Debug.Log(fwd);
            Debug.Log(transform.forward);
        }

        playervec.y += gravityValue * Time.deltaTime;
        _controller.Move(playervec * Time.deltaTime);
        
    }
}
