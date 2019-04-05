using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

// ------------------------------
// store functions to be triggered by voice commands
// ------------------------------

namespace VoiceCommands{

public class voiceCommands {
	// sub menu functions
	public void subMenuSelected(int subNum){
		// collect and toggle text objects
		GameObject.Find ("Overlay - Info").GetComponent<Canvas> ().enabled = false;

		// update text of sub menu based on subNum
		if(subNum == 1){
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = true;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		}
		if(subNum == 2){
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = true;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		}
		if(subNum == 3){
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = true;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		}
		if(subNum == 4){
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = true;
		}

	}
	public void subMenuRestore(){
		// collect and toggle text objects
		GameObject.Find ("Overlay - Info").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
	}
	// open an overlay
	public void openOverlay(int dispNum){
		if(dispNum == 1){
			Canvas selected = GameObject.Find ("Overlay - Info").GetComponent<Canvas> ();
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
			selected.enabled = true;
		}
		if(dispNum == 2){
			Canvas selected = GameObject.Find ("Overlay - Clock").GetComponent<Canvas> ();
			selected.enabled = true;
		}
		if(dispNum == 3){
			Canvas selected = GameObject.Find ("Overlay - Pad").GetComponent<Canvas> ();
			selected.enabled = true;
		}
		if(dispNum == 4){
			Canvas selected = GameObject.Find ("Overlay - Task").GetComponent<Canvas> ();
			selected.enabled = true;
		}
	}
	// clear an overlay
	public void clearOverlay(int dispNum){
		if(dispNum == 1){
			GameObject.Find ("Overlay - Info").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		}
		if (dispNum == 2) {
			Canvas selected = GameObject.Find ("Overlay - Clock").GetComponent<Canvas> ();
			selected.enabled = false;
		}
		if(dispNum == 3){
			Canvas selected = GameObject.Find ("Overlay - Pad").GetComponent<Canvas> ();
			selected.enabled = false;
		}
		if(dispNum == 4){
			Canvas selected = GameObject.Find ("Overlay - Task").GetComponent<Canvas> ();
			selected.enabled = false;
		}
	}
	// open all overlays
	public void allOn(){
		GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Overlay - Info").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("Overlay - Clock").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("Overlay - Pad").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("Overlay - Task").GetComponent<Canvas> ().enabled = true;

	}
	// clear all overlays
	public void alloff(){
		GameObject.Find ("Overlay - Info").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Overlay - Clock").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Overlay - Pad").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Overlay - Task").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
	}

}
}
