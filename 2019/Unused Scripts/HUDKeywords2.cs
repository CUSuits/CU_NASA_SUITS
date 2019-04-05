using UnityEngine;
using UnityEngine.UI;
using System.Text;
using HoloToolkit.Unity.InputModule;

public class HUDKeywords2 : MonoBehaviour, ISpeechHandler
    {

        public void ToggleObject(string command)
        {
            switch (command)
            {
                case "Basic on":
	                  GameObject.Find ("EVA Clock").GetComponent<Text> ().enabled = true;
                    break;
                case "Basic off":
                    GameObject.Find ("EVA Clock").GetComponent<Text> ().enabled = false;
                    break;
            }
        }

        public void OnSpeechKeywordRecognized(SpeechEventData eventData)
        {
            ToggleObject(eventData.RecognizedText);
        }

    }
