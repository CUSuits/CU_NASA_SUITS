using HoloToolkit.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using System;
using UnityEngine.XR.WSA.Input;
using UnityEngine.Windows.Speech;

public class GazeCommands : MonoBehaviour{
    KeywordRecognizer keywordRecognizer;
    public GameObject target;
    public Tagalong tagalong;
    public Billboard billboard;
    public MeshRenderer meshRenderer;
    public GazeManager gazeManager;
    public RaycastHit hitinfo;
    public static GazeCommands Instance { get; private set; }
    public GameObject FocusedObject { get; private set; }
    GestureRecognizer recognizer;
    private WorldAnchorManager WAM;
    
    // Use this for initialization
    void Start () {
        tagalong = GetComponent<Tagalong>();
        billboard = GetComponent<Billboard>();
        //recognizer = new GestureRecognizer();
        //Instance = this;
        //  if (FocusedObject != null)
        // {
        //     FocusedObject.SendMessageUpwards("onSelect", SendMessageOptions.DontRequireReceiver);
        // }   
	}
	void Update () {

        GameObject oldFocusedObject = FocusedObject;
        var headPosition = Camera.main.transform.position;
        var gazeDirection = Camera.main.transform.forward;
        RaycastHit hitInfo;
        if (Physics.Raycast(headPosition, gazeDirection, out hitInfo))
        {
            FocusedObject = hitInfo.collider.gameObject;
            FocusedObject.GetComponent<Tagalong>();
            FocusedObject.GetComponent<Billboard>();
        }
        else {
            FocusedObject = null;
            if (FocusedObject != oldFocusedObject)
            {
                //recognizer.CancelGestures();
                //recognizer.StartCapturingGestures();
            }
        }
       
        
    }
  
    public void Drag()
    {
        if (FocusedObject)
        {
            FocusedObject.transform.parent = null;
            tagalong = FocusedObject.GetComponent<Tagalong>();
            tagalong.enabled = true;
            billboard = FocusedObject.GetComponent<Billboard>();
            billboard.enabled = true;
        }
       
    
    }
    public void PinHere()
    { 
       tagalong = FocusedObject.GetComponent<Tagalong>();
       tagalong.enabled = false;
    }
    public void PinAll() {
        tagalong.enabled = true;
    }
    public void UnpinAll()
    {
        tagalong.enabled = false;
    }
   
}

