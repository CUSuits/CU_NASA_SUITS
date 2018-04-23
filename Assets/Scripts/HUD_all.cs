using UnityEngine;
using UnityEngine.UI;
using System.Text;
using HoloToolkit.Unity.InputModule;

//{
  public class HUD_all : MonoBehaviour, ISpeechHandler
  {
    // static string[] keys = new string[15] {"Heart Rate","Suit Pressure",
    // "SUB Pressure","SUB Temperature","Fan Tachometer","Oxygen Pressure",
    // "Oxygen Rate","Battery Capacity","Water Vapor Pressure","Water Pressure",
    // "Secondary Oxygen Pressure","Secondary Oxygen Rate","Battery Time",
    // "Oxygen Time","Water Time"};
    public void ToggleAll(string command)
    {
      switch (command)
      {
        case "Open all":
        GameObject.Find ("Heart Rate").GetComponent<Text> ().enabled = true;
        GameObject.Find ("Internal Suit Pressure").GetComponent<Text> ().enabled = true;
        GameObject.Find ("Sub Pressure").GetComponent<Text> ().enabled = true;
        GameObject.Find ("Sub Temperature").GetComponent<Text> ().enabled = true;
        GameObject.Find ("Fan Tachometer").GetComponent<Text> ().enabled = true;
        GameObject.Find ("Oxygen Pressure").GetComponent<Text> ().enabled = true;
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        GameObject.Find ("Battery Capacity").GetComponent<Text> ().enabled = true;
        GameObject.Find ("H2O Gas Pressure").GetComponent<Text> ().enabled = true;
        GameObject.Find ("H2O Liquid Pressure").GetComponent<Text> ().enabled = true;
        GameObject.Find ("SOP Pressure").GetComponent<Text> ().enabled = true;
        GameObject.Find ("SOP Rate").GetComponent<Text> ().enabled = true;
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        break;
        case "Close all":
        GameObject.Find ("Heart Rate").GetComponent<Text> ().enabled = false;
        GameObject.Find ("Internal Suit Pressure").GetComponent<Text> ().enabled = false;
        GameObject.Find ("Sub Pressure").GetComponent<Text> ().enabled = false;
        GameObject.Find ("Sub Temperature").GetComponent<Text> ().enabled = false;
        GameObject.Find ("Fan Tachometer").GetComponent<Text> ().enabled = false;
        GameObject.Find ("Oxygen Pressure").GetComponent<Text> ().enabled = false;
        GameObject.Find ("").GetComponent<Text> ().enabled = false;
        GameObject.Find ("Battery Capacity").GetComponent<Text> ().enabled = false;
        GameObject.Find ("H2O Gas Pressure").GetComponent<Text> ().enabled = false;
        GameObject.Find ("H2O Liquid Pressure").GetComponent<Text> ().enabled = false;
        GameObject.Find ("SOP Pressure").GetComponent<Text> ().enabled = false;
        GameObject.Find ("SOP Rate").GetComponent<Text> ().enabled = false;
        GameObject.Find ("").GetComponent<Text> ().enabled = false;
        GameObject.Find ("").GetComponent<Text> ().enabled = false;
        GameObject.Find ("").GetComponent<Text> ().enabled = false;
        break;
      }
    }
    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        ToggleAll(eventData.RecognizedText);
    }
  }
