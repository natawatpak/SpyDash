using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

[RequireComponent(typeof(ARRaycastManager))]
public class PointPlacer : MonoBehaviour
{
    private Screencontrol screencontrol;
    private GameObject startpoint;
    private GameObject endpoint;
    private Quaternion y;
    private Vector3 x;
    //public GameObject Butt;
    public GameObject Text1;
    public GameObject Text2;
    public GameObject joystick;
    public GameObject jump;
    public GameObject boost;
    public GameObject time;
    public bool placedstartpoint = false;
    public bool nextstage = false;
    public bool placedendpoint = false;
    private bool delay = false;
    private float timer = 0f;
    private ARRaycastManager arRaycastmng;
    private ARPlaneManager arPlaneManager;
    [SerializeField] public GameObject character;
    [SerializeField] public GameObject objectospawn1;
    [SerializeField] public GameObject objectospawn2;
    public ARSession arSession;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Awake()
    {
        screencontrol = new Screencontrol();
        arRaycastmng = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
        EnhancedTouchSupport.Enable();
        arSession.Reset();
    }
    private void OnEnable() {
        screencontrol.Enable();
    }

    private void OnDisable() {
        screencontrol.Disable();
    }
    void Start()
    {
        
    }
    bool gettouchpos(out Vector2 touchposition) {
        if(screencontrol.Touch.TouchInput.ReadValue<float>() > 0) {
            touchposition = screencontrol.Touch.TouchPosition.ReadValue<Vector2>();
            return true;
           
        }
        touchposition = default;
        return false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (screencontrol.Touch.Button.ReadValue<float>() > 0) {
        //     nextstage = true;
        // } else {
        //     if(!gettouchpos(out Vector2 touchposition)) {
        //         return;
        // }
        //     if(screencontrol.Touch.TouchInput.ReadValue<float>() > 0) {
        //         if (arRaycastmng.Raycast(touchposition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes)) {
        //             var hitpose = hits[0].pose;
        //             //startpoint = Instantiate(objectospawn1, hitpose.position, hitpose.rotation);

        //             //code to disable planemanager and planes
        //             //foreach(var plane in arPlaneManager.trackables) {
        //             //    plane.gameObject.SetActive(false);
        //             //}
        //             //arPlaneManager.enabled = false;
                    
        //             if (placedstartpoint == true && nextstage == false) {
        //                 startpoint.transform.SetPositionAndRotation(hitpose.position, hitpose.rotation);
        //             } else if(placedstartpoint == false && nextstage == false) {
        //                 startpoint = Instantiate(objectospawn1, hitpose.position, hitpose.rotation);
        //                 placedstartpoint = true;
        //                 Butt.SetActive(true);
        //             }
        //             if (placedstartpoint == true && nextstage == true) {
        //                 Butt.SetActive(false);
        //                 if (placedendpoint == true) {
        //                     endpoint.transform.SetPositionAndRotation(hitpose.position, hitpose.rotation);
        //                     Butt.SetActive(true);
        //                 } else {
        //                     endpoint = Instantiate(objectospawn2, hitpose.position, hitpose.rotation);
        //                     placedendpoint = true;
        //                     Butt.SetActive(true);
        //                 }
        //             }
        //         }
        //     }
        // }
        if (placedstartpoint == true) {
            timer += Time.deltaTime;
            if (timer > 1.0f) {
                delay = true;
            }
        }
        if (nextstage == false) {
            if (touch.activeFingers.Count == 1)
            {
            touch activeTouch = touch.activeFingers[0].currentTouch;
            if(activeTouch.phase == UnityEngine.InputSystem.TouchPhase.Began) {
                if (arRaycastmng.Raycast(activeTouch.startScreenPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes)) {
                    var hitpose = hits[0].pose;
                    
                    if (placedstartpoint == false && placedendpoint == false) {
                       startpoint = Instantiate(objectospawn1, hitpose.position, hitpose.rotation);
                       placedstartpoint = true;
                       Text1.SetActive(false);
                       Text2.SetActive(true);
                       x = hitpose.position;
                       y = hitpose.rotation;
                       
                    } else if(placedstartpoint == true && placedendpoint == false && delay == true) {
                        endpoint = Instantiate(objectospawn2, hitpose.position, hitpose.rotation);
                        placedendpoint = true;
                        Text2.SetActive(false);
                    } else if (placedstartpoint == true && placedendpoint == true) {
                        screencontrol.Disable();
                        nextstage = true;
                        }
                    }
                }
            //Debug.Log($"Phase: {activeTouch.phase} | Position: {activeTouch.startScreenPosition}");
            }   
            } else if (nextstage == true) {
                //character = Instantiate(character, x + new Vector3(0f, 0.5f, 0f), y);
                //GetComponent(PointPlacer).enabled = false;
                time.SetActive(true);
                character.SetActive(true);
                character.transform.SetPositionAndRotation(x + new Vector3(0f, 0.5f, 0f), new Quaternion(0f,0f,0f,0f));
                joystick.SetActive(true);
                jump.SetActive(true);
                boost.SetActive(true);
                this.enabled = false;
            }
        }
    }
