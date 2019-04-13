using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionAnchor : MonoBehaviour {
    public GameObject directionArrow;
    public GameObject defaultCursor;
    public Vector3 gazePos ;
    // Use this for initialization
    void Start() {
        
        
       // gazePos = defaultCursor.transform.position;

        
    }

    // Update is called once per frame
    void Update()
    {
        gazePos = defaultCursor.transform.position;

    }
    public void Place(GameObject place)
    {
            Instantiate(directionArrow, gazePos, Quaternion.identity);
    }
}

