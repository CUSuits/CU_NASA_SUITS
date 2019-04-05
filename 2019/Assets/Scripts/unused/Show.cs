using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.XR.WSA.Input;

public class Show : MonoBehaviour {

	public Canvas Overlay1;
	public string Trigger1;
	public Canvas Overlay2;
	public string Trigger2;

	#if !UNITY_EDITOR
		GestureRecognizer recognizer;
	#endif

	// Update is called once per frame
	void Update () 
	{
		#if !UNITY_EDITOR
			recognizer = new GestureRecognizer();
			recognizer.Tapped += (args) =>
			{
				if (Overlay1.enabled == false)
				{
					Overlay1.enabled = true;
				}else
				{
					Overlay1.enabled = false;
				}
			};
			recognizer.StartCapturingGestures();
		#else
			toCheck_Unity (Overlay1, Trigger1);
			toCheck_Unity (Overlay2, Trigger2);
		#endif
	}

	// check canvas is enabled or disbsabled and switch its state	
	void toCheck_Unity(Canvas overlay, string trigger) 
	{
		if (Input.GetKeyDown (trigger)) {
			if (overlay.enabled == false) {
				overlay.enabled = true;
			} else {
				overlay.enabled = false;
			}
		}
	}
}
