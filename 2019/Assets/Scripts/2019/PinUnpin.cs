using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUnpin : MonoBehaviour {
    public GameObject uIB;
    public GameObject parentOfuIB;
    public GazeCommands Instance { get; private set; }
    public GameObject FocusedObject { get; private set; }
    public Vector3 newPosition;
    public Billboard billboard;
    public Tagalong tagAlong;
    public DirectionIndicator directionIndicator;
   
    // Use this for initialization
    void Start ()
    {
        FocusedObject = null;
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject oldFocusedObject = FocusedObject;
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;
        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo, 20.0f,Physics.DefaultRaycastLayers))
        {
            FocusedObject = hitInfo.collider.gameObject;
            newPosition = FocusedObject.transform.position;

            //this.transform.position = hitInfo.point;
        }
    }
    public void Pin(Transform parentofuIB)
    {
        if (FocusedObject)
        {
            FocusedObject.transform.parent = parentOfuIB.transform;
        }
    }
  
    public void Unpin()
    {
        if (FocusedObject)
        {
            FocusedObject.transform.SetParent(null);
            FocusedObject.transform.position = newPosition;
        }

    }
    public void UnpinAll()
    {
        parentOfuIB.transform.DetachChildren();
    }
    public void ActivateAnchor()
    {
        FocusedObject.AddComponent<UnityEngine.XR.WSA.WorldAnchor>();
    }
    public void AddDirectionalAnchor()
    {

    }
    public void FaceMe()
    {
       billboard = FocusedObject.GetComponent<Billboard>();
        billboard.enabled = true;
    }
    public void FollowMe()
    {
        tagAlong = FocusedObject.GetComponent<Tagalong>();
        tagAlong.enabled = true;
    }
    public void NavigationCursor()
    {
        directionIndicator = FocusedObject.GetComponent<DirectionIndicator>();
        directionIndicator.enabled = true;
    }
}
