using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUnpin : MonoBehaviour {
    public GameObject uIB;
    public GameObject parentOfuIB;
    public GazeCommands Instance { get; private set; }
    public GameObject FocusedObject { get; private set; }
    public Vector3 newPosition;
    
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
}
