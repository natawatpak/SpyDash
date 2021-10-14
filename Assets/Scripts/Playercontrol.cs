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
    public Rigidbody rigid;

    void Start()
    {
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
        }
    }
}
