using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class controller : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    public RectTransform gamePad;
    public float moveSpeed = 0.5f;
    public GameObject Character;

    GameObject arObject;
    Vector3 move;
    public float time;
    public Text timeDisplay;

    bool walking;
    //////////////////////////////////////////////////////// chic's
    private MyControl _playerControl;
    RaycastHit hit;
    [SerializeField] private LayerMask layerMsk;
    public bool gonnaGo;
    bool toJump;
    // public GameObject mother;
    [SerializeField] private string SceneName;
    private Animator anim;
    private Vector3 startcoord;
    /////////////////////////////////////////////////////////

    void Start()
    {
        //arObject = GameObject.FindGameObjectWithTag("Player");
        arObject = Character;
        anim = Character.GetComponent<Animator>();
        time = 200f;
        GameObject temp = GameObject.Find("Point 2");
        startcoord = new Vector3(temp.transform.position.x, temp.transform.position.y, temp.transform.position.z);
    }

    public void reset_button() {
        arObject.transform.position = startcoord;
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

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        transform.localPosition = Vector2.ClampMagnitude(eventData.position - (Vector2)gamePad.position, gamePad.rect.width * 0.5f);

        move = new Vector3(transform.localPosition.x, 0f, transform.localPosition.y).normalized; // no movement in y
        Character.GetComponent<Animator>().SetBool("Walking", true); // on drag start the walk animation
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // do the movement when touched down
        StartCoroutine(PlayerMovement());


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero; // joystick returns to mean pos when not touched
        move = Vector3.zero;
        StopCoroutine(PlayerMovement());
        StopAllCoroutines();
        walking = false;
        Character.GetComponent<Animator>().SetBool("Walking", false);


    }

  IEnumerator PlayerMovement()
    {
        while(true)
        {
            arObject.transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

            if(move != Vector3.zero)
                arObject.transform.rotation = Quaternion.Slerp
                    (arObject.transform.rotation, Quaternion.LookRotation(move), Time.deltaTime * 5.0f);
            
            yield return null;

                
        }
    }

    void Update()
    {
        // time = time - (float)Time.deltaTime;
        //  if (time < 0){
        //     timeDisplay.text = "Time\n0.00";
        //     //canMove = false;
        //     SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        // }else{
        //     timeDisplay.text = "Time\n" + time.ToString("#.00");
        //  }
        
        if (_playerControl.Player.climb.ReadValue<float>() > 0)
            {
                toJump = true;
                Character.GetComponent<Rigidbody>().useGravity = false;
                Character.transform.position = Vector3.Lerp(Character.transform.position, Character.transform.position + new Vector3(0f, 1f, 0f), 0.5f * Time.deltaTime);
                toJump = false;
            }else{
                Character.GetComponent<Rigidbody>().useGravity = true;
            }
        if(_playerControl.Player.jump.triggered && toJump == false && (anim.GetCurrentAnimatorStateInfo(0).IsName("Ninja Idle") || anim.GetCurrentAnimatorStateInfo(0).IsName("Sprint"))){
            toJump = true;
            // playervec = mother.transform.forward * 2;
            // playervec.y = Mathf.Sqrt(1f * -2.0f * gravityValue);
            Character.transform.Translate(new Vector3(0f,0.05f,0f));
            Character.transform.Translate(new Vector3(0f,0f,0.04f));
            anim.Play("Base Layer.Jumping");
            toJump = false;
        }
    }
}

