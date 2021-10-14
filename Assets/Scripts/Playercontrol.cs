using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    // Start is called before the first frame update

    private MyControl _playerControl;
    private Animator anim;

    private bool waiting = false;
    private bool breaking = false;

    private float rotation = 360f;

    public GameObject obstacle;
    private float spawn_time = 3;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public Rigidbody rigid;
=======
    public GameObject rigid;
    public int canSpawn = 0;
    private float save_x;
    private float save_y;
    private float save_z;
>>>>>>> Stashed changes
=======
    public Rigidbody rigid;


    ///////////////////////////////////////////

    private Vector3 playervec;
    [SerializeField] private LayerMask layerMsk;
    [SerializeField] private float playerspd = 5f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.8f;
    [SerializeField] private float turnSpd = 180f;
    [SerializeField] private bool grounded;
>>>>>>> Stashed changes

    void Start()
    {
        save_x = rigid.transform.position.x;
        save_y = rigid.transform.position.y;
        save_z = rigid.transform.position.z;
        Debug.Log("Start");
        anim = GetComponent<Animator>();
    }
    private void Awake(){
        _playerControl = new MyControl();
    }

    private void OnEnable(){
        _playerControl.Enable();
    }

    private void OnDisable(){
        _playerControl.Disable();
    }

    private void CreateObs(){
<<<<<<< Updated upstream
<<<<<<< Updated upstream
        float xpos = rigid.position.x;
        float ypos = rigid.position.y;
        float zpos = rigid.position.z;
        for (int i = 0; i < 3; i++) {
            Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range(-3f, 3f), ypos - (float)0.750213, zpos + UnityEngine.Random.Range(3f, 10f)), this.transform.rotation);
=======
        float xpos = rigid.transform.position.x;
        float ypos = rigid.transform.position.y;
        float zpos = rigid.transform.position.z;
        for (int i = 0; i < 3; i++) {
            Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range(-3f, 3f), ypos - (float)0.750213, zpos + UnityEngine.Random.Range(3f, 10f)), this.transform.rotation);

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.transform.position.x == save_x && rigid.transform.position.z == save_z ){
            //Debug.Log("cant spawn");
            canSpawn = 0;
        }else{
            //Debug.Log("can spawn");
            canSpawn = 1;
            save_x = rigid.transform.position.x;
            save_y = rigid.transform.position.y;
            save_z = rigid.transform.position.z;
        }
        if (canSpawn == 1 && spawn_time >= 0){
            spawn_time -= Time.deltaTime;
        }
        
        if (spawn_time <= 0 && canSpawn == 1) {
            CreateObs();
            spawn_time = 5;
        }

=======
            float xpos = rigid.position.x;
            float ypos = rigid.position.y;
            float zpos = rigid.position.z;
            for (int i = 0; i < 3; i++) {
                Instantiate(obstacle, new Vector3(xpos + UnityEngine.Random.Range(-3f, 3f), ypos - (float)0.750213, zpos + UnityEngine.Random.Range(3f, 10f)), this.transform.rotation);

            }
    }


    // Update is called once per frame
    void Update()
    {
        spawn_time -= Time.deltaTime;
        if (spawn_time <= 0) {
            CreateObs();
            spawn_time = 5;
        }
        
>>>>>>> Stashed changes
        if (!waiting){
            if(_playerControl.Player.forward.ReadValue<float>() > 0){
>>>>>>> Stashed changes

        }
    }


    // Update is called once per frame
    void Update()
    {
        spawn_time -= Time.deltaTime;
        if (spawn_time <= 0) {
            CreateObs();
            spawn_time = 5;
        }

        if(_playerControl.Player.forward.ReadValue<float>() > 0){
            
            anim.SetInteger("State", 1);
            if (!waiting){
                anim.Play("Base Layer.Sprint");
                breaking = true;
            }

        }else if(_playerControl.Player.backward.ReadValue<float>() > 0) {

            anim.SetInteger("State", 2);
            if (!waiting){
                anim.Play("Base Layer.Sprint");
            }
        }
        else if(_playerControl.Player.left.ReadValue<float>() > 0){
            if (rotation == 270){
                anim.Play("Base Layer.Sprint");
                breaking = true;
                waiting = false;
            }else if(!waiting){
                
                if (rotation == 180 || rotation == 90){
                    anim.Play("Base Layer.Turn Right 90");
                    rotation += 90f;
                }else{
                    anim.Play("Base Layer.Turn Left 90");
                    rotation -= 90f;
                }
                waiting = true;
            }
        }
        else if(_playerControl.Player.right.ReadValue<float>() > 0){
            if (rotation == 90){
                anim.Play("Base Layer.Sprint");
                breaking = true;
                waiting = false;
            }else if(!waiting){
                
                if (rotation == 180 || rotation == 270){
                    anim.Play("Base Layer.Turn Left 90");
                    rotation -= 90f;
                }else{
                    if (rotation == 360){
                        rotation = 90;
                        anim.Play("Base Layer.Turn Right 90");
                    }else{
                        anim.Play("Base Layer.Turn Right 90");
                        rotation += 90f;
                    }
                }
                waiting = true;
            }
        }
        else if(_playerControl.Player.jump.triggered){

            if(!waiting){
                anim.Play("Base Layer.Jumping");
                waiting = true;
            }else{
                anim.SetInteger("State", 0);
            }
        }
        else {
            if (!waiting){
                if (breaking){
                    anim.Play("Base Layer.Stop Walking");
                    breaking = false;
                    waiting = true;
                }else{
                    anim.Play("Base Layer.Ninja Idle");
                }
            }else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Ninja Idle")){
                waiting = false;
            }
<<<<<<< Updated upstream
        }
=======

        //Debug.Log(rotation);
        
>>>>>>> Stashed changes
    }
}
