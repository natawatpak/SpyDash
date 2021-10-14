using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wallClaim : MonoBehaviour
{
    public GameObject player;
    private CharacterController controller;
    private Vector3 playervec;
    [SerializeField] private LayerMask layerMsk;
    [SerializeField] private float playerspd = 5f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.8f;
    [SerializeField] private float turnSpd = 180f;
    [SerializeField] private bool grounded;
    private Input_action inputActions;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        inputActions = new Input_action();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "wall")
        {
            Debug.Log("coin collected");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = inputActions.PlayerMain.Move1.ReadValue<Vector2>();
        float angleX = transform.rotation.eulerAngles.x;  
        float angleY = transform.rotation.eulerAngles.y; 
        float angleZ = transform.rotation.eulerAngles.z;
        Vector3 fwd = new Vector3 (angleX,angleY,angleZ);
        RaycastHit hit;
        grounded = controller.isGrounded;
        // Debug.Log(grounded);

        if (grounded && playervec.y < 0)
        {
            playervec.y = 0f;
        }

        Vector3 move = transform.forward * moveInput.y;

        controller.Move(move * playerspd * Time.deltaTime);

        // if (inputActions.PlayerMain.jump.triggered && grounded)
        // {
        //     playervec.y = Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        // }

        // if (Physics.Raycast(transform.position, fwd, 10)){
        //         // playervec.y = Mathf.Sqrt(3f * -2.0f * gravityValue);
        //         Debug.Log("claim");
        //     }

        if (inputActions.PlayerMain.claim.triggered)
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
        controller.Move(playervec * Time.deltaTime);
        transform.RotateAround(transform.position, -transform.up, turnSpd * moveInput.x * Time.deltaTime);
    }
}
