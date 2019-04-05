using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// hold all events 

public class DisplayToggle : MonoBehaviour 
{	
	// delegate to instance of event manager
	void Start()
	{
		//EventManager.ToggleDisplay += showOverlay;
	}

	// define events as methods (add another if statement for more overlays)
	void showOverlay()
	{	
		// Suit Info
		if (Input.GetKeyDown ("a")) {
			Canvas attached = GameObject.Find("Overlay-Suit Info").GetComponent<Canvas>();
			if (attached.enabled == false) {
				attached.enabled = true;
			} else {
				attached.enabled = false;
			}
		}
		// Clock
		if (Input.GetKeyDown ("b")) {
			Canvas attached = GameObject.Find("Overlay-Clock").GetComponent<Canvas>();
			if (attached.enabled == false) {
				attached.enabled = true;
			} else {
				attached.enabled = false;
			}
		}
	}
		
}
