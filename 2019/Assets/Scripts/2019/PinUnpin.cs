using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinUnpin : MonoBehaviour {
    public GameObject uIB;
    public GameObject parentOfuIB;
    public GazeCommands Instance { get; private set; }
    public GameObject FocusedObject { get; private set; }
    
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
            FocusedObject.transform.parent = null;
        }
        
    }
    public void UnpinAll()
    {

    }
    public void PinAll()
    {

    }
}
