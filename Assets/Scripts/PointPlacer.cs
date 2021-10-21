using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.InputSystem;
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
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject time;
    public bool placedstartpoint = false;
    public bool nextstage = false;
    public bool placedendpoint = false;
    private ARRaycastManager arRaycastmng;
    private ARPlaneManager arPlaneManager;
    [SerializeField] public GameObject character;
    [SerializeField] public GameObject objectospawn1;
    [SerializeField] public GameObject objectospawn2;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    // Start is called before the first frame update
    void Awake()
    {
        screencontrol = new Screencontrol();
        arRaycastmng = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();    
    }
    private void OnEnable() {
        screencontrol.Enable();
    }

    private void OnDisable() {
        screencontrol.Disable();
    }
    void Start()
    {
        foreach(var plane in arPlaneManager.trackables) {
                Destroy(plane);
            }
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
        if (nextstage == false) {
        if(!gettouchpos(out Vector2 touchposition)) {
                return;
        }
            if(screencontrol.Touch.TouchInput.ReadValue<float>() > 0) {
                if (arRaycastmng.Raycast(touchposition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes)) {
                    var hitpose = hits[0].pose;
                    
                    if (placedstartpoint == false && placedendpoint == false) {
                       startpoint = Instantiate(objectospawn1, hitpose.position, hitpose.rotation);
                       placedstartpoint = true;
                       Text1.SetActive(false);
                       Text2.SetActive(true);
                       x = hitpose.position;
                       y = hitpose.rotation;
                    } else if(placedstartpoint == true && placedendpoint == false) {
                        endpoint = Instantiate(objectospawn2, hitpose.position, hitpose.rotation);
                        placedendpoint = true;
                        Text2.SetActive(false);
                    } else if (placedstartpoint == true && placedendpoint == true) {
                        screencontrol.Disable();
                        nextstage = true;
                        }
                    }
                }
            } else if (nextstage == true) {
                //character = Instantiate(character, x + new Vector3(0f, 0.5f, 0f), y);
                //GetComponent(PointPlacer).enabled = false;
                time.SetActive(true);
                character.SetActive(true);
                character.transform.SetPositionAndRotation(x + new Vector3(0f, 0.5f, 0f), new Quaternion(0f,0f,0f,0f));
                button1.SetActive(true);
                button2.SetActive(true);
                button3.SetActive(true);
                button4.SetActive(true);
                button5.SetActive(true);
                button6.SetActive(true);
                this.enabled = false;
            }
        }
    }
