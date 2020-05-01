using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlaceObject : MonoBehaviour
{
    public static ARTapToPlaceObject artapInstace
    {
        get;
        set;
    }
    
     GameObject objectToPlace;
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    public GameObject placementIndicator;

    private ARRaycastManager arRaycastManager;
    private Pose placementPose;
    private bool placementPoseIsValid = false;

    GameObject obj;
   // GameObject obj2;
   
   public bool isobj1 = false;
    public bool isobj2 = false;
    public bool isobj3 = false;

    private void Awake()
    {
        artapInstace = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("hello");
        arRaycastManager = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        UpdatePlacementPose();
        UpdatePlacementIndicator();
        if (placementPoseIsValid && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            setpos();
        }
    }

    public void setpos()
    {
        obj.transform.position = placementIndicator.transform.position;
        obj.transform.rotation = placementIndicator.transform.rotation;
    }
    public void setobj1() {
        isobj1 = true;
        isobj2 = false;
        isobj3 = false;
        Debug.Log(isobj2);

    }
    public void setobj2()
    {
        isobj1 =false;
        isobj2 = true;
        isobj3 = false;
    }
    public void setobj3()
    {
        isobj1 = false;
        isobj2 = false;
        isobj3 = true;

    }
    public void PlaceObject()
    {
        if (obj != null)
        {
            Destroy(obj);
        }
        if (isobj1)
        {
            obj = Instantiate(object1, placementIndicator.transform.position,placementIndicator.transform.rotation);
        }
        else if (isobj2)
        {
            obj = Instantiate(object2, placementIndicator.transform.position,placementIndicator.transform.rotation);
        }
        else if (isobj3)
        {
            obj = Instantiate(object3, placementIndicator.transform.position, placementIndicator.transform.rotation);
        }
        
    }
    private void UpdatePlacementPose()
    {   
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arRaycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        placementPoseIsValid = hits.Count > 0;
        if (placementPoseIsValid)
        {
            placementPose = hits[0].pose;           
        }
    }

    private void UpdatePlacementIndicator()
    {
        if (placementPoseIsValid)
        {
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else
        {
            placementIndicator.SetActive(false);
        }
    }
}