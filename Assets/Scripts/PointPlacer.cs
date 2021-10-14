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
    //public GameObject Butt;
    public bool placedstartpoint = false;
    public bool nextstage = false;
    public bool placedendpoint = false;
    private ARRaycastManager arRaycastmng;
    private ARPlaneManager arPlaneManager;
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

    }
    public void button() {
        nextstage = true;
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
        if(!gettouchpos(out Vector2 touchposition)) {
            return;
        }

        if(screencontrol.Touch.TouchInput.ReadValue<float>() > 0) {
            if (arRaycastmng.Raycast(touchposition, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes)) {
                var hitpose = hits[0].pose;
                //startpoint = Instantiate(objectospawn1, hitpose.position, hitpose.rotation);

                //code to disable planemanager and planes
                //foreach(var plane in arPlaneManager.trackables) {
                //    plane.gameObject.SetActive(false);
                //}
                //arPlaneManager.enabled = false;
                
                if (placedstartpoint == true && nextstage == false) {
                    startpoint.transform.SetPositionAndRotation(hitpose.position, hitpose.rotation);
                } else if(placedstartpoint == false && nextstage == false) {
                    startpoint = Instantiate(objectospawn1, hitpose.position, hitpose.rotation);
                    placedstartpoint = true;
                    //Butt.SetActive(true);
                }
                if (placedstartpoint == true && nextstage == true) {
                    if (placedendpoint == true) {
                        endpoint.transform.SetPositionAndRotation(hitpose.position, hitpose.rotation);
                    } else {
                        endpoint = Instantiate(objectospawn2, hitpose.position, hitpose.rotation);
                        placedendpoint = true;
                    }
                }
            }
        }
    }
}
