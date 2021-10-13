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

    // Update is called once per frame
    void Update()
    {
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
