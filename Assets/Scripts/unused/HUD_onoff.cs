using UnityEngine;
using UnityEngine.UI;
using System.Text;
using HoloToolkit.Unity.InputModule;
//{

public class HUD_onoff : MonoBehaviour, ISpeechHandler
{
  // static string[] keys = new string[15] {"Heart Rate","Suit Pressure",
  // "SUB Pressure","SUB Temperature","Fan Tachometer","Oxygen Pressure",
  // "Oxygen Rate","Battery Capacity","Water Vapor Pressure","Water Pressure",
  // "Secondary Oxygen Pressure","Secondary Oxygen Rate","Battery Time",
  // "Oxygen Time","Water Time"};
  public void ToggleObject(string command)
  {
    switch (command)
    {
      //Commands for opening
      case "Open heart rate":
      case "Show heart rate":
      case "Display heart rate":
      GameObject.Find ("Heart Rate").GetComponent<Text> ().enabled = true;
      break;
      case "Open suit pressure":
      case "Show suit pressure":
      case "Display Suit Pressure":
      GameObject.Find ("Internal Suit Pressure").GetComponent<Text> ().enabled = true;
      break;
      case "Open sub pressure":
      case "Show sub pressure":
      case "Display sub pressure":
      GameObject.Find ("Sub Pressure").GetComponent<Text> ().enabled = true;
      break;
      case "Open sub temperature":
      case "Show sub temperature":
      case "Display sub temperature":
      GameObject.Find ("Sub Temperature").GetComponent<Text> ().enabled = true;
      break;
      case "Open fan tachometer":
      case "Show fan tachometer":
      case "Display fan tachometer":
      case "Open fan speed":
      case "Show fan speed":
      case "Display fan speed":
      GameObject.Find ("Fan Tachometer").GetComponent<Text> ().enabled = true;
      break;
      case "Open oxygen pressure":
      case "Show oxygen pressure":
      case "Display oxygen pressure":
      GameObject.Find ("Oxygen Pressure").GetComponent<Text> ().enabled = true;
      break;
      case "Open oxygen rate":
      case "Show oxygen rate":
      case "Display oxygen rate":
      GameObject.Find ("").GetComponent<Text> ().enabled = true;
      break;
      case "Open battery capacity":
      case "Show battery capacity":
      case "Display battery capacity":
      GameObject.Find ("Battery Capacity").GetComponent<Text> ().enabled = true;
      break;
      case "Open water vapor pressure":
      case "Show water vapor pressure":
      case "Display water vapor pressure":
      GameObject.Find ("H2O Gas Pressure").GetComponent<Text> ().enabled = true;
      break;
      case "Open water pressure":
      case "Show water pressure":
      case "Display water pressure":
      GameObject.Find ("H2O Liquid Pressure").GetComponent<Text> ().enabled = true;
      break;
      case "Open Secondary oxygen pressure":
      case "Show Secondary oxygen pressure":
      case "Display Secondary oxygen pressure":
      GameObject.Find ("SOP Pressure").GetComponent<Text> ().enabled = true;
      break;
      case "Open secondary oxygen rate":
      case "Show secondary oxygen rate":
      case "Display secondary oxygen rate":
      GameObject.Find ("SOP Rate").GetComponent<Text> ().enabled = true;
      break;
      case "Open battery time":
      case "Show battery time":
      case "Display battery time":
      GameObject.Find ("").GetComponent<Text> ().enabled = true;
      break;
      case "Open oxygen time":
      case "Show oxygen time":
      case "Display oxygen time":
      GameObject.Find ("").GetComponent<Text> ().enabled = true;
      break;
      case "Open water time":
      case "Show water time":
      case "Display water time":
      GameObject.Find ("").GetComponent<Text> ().enabled = true;
      break;
      // case "Open Heart Rate":
      // case "Show Heart Rate":
      // case "Display Heart Rate":
      // GameObject.Find ("EVA Clock").GetComponent<Text> ().enabled = true;
      // break;


      //Commands for closing
      case "Close heart rate":
      case "Hide heart rate":
      case "Remove heart rate":
      GameObject.Find ("Heart Rate").GetComponent<Text> ().enabled = false;
      break;
      case "Close suit pressure":
      case "Hide suit pressure":
      case "Remove suit pressure":
      GameObject.Find ("Internal Suit Pressure").GetComponent<Text> ().enabled = false;
      break;
      case "Close sub pressure":
      case "Hide sub pressure":
      case "Remove sub pressure":
      GameObject.Find ("Sub Pressure").GetComponent<Text> ().enabled = false;
      break;
      case "Close sub temperature":
      case "Hide sub temperature":
      case "Remove sub temperature":
      GameObject.Find ("Sub Temperature").GetComponent<Text> ().enabled = false;
      break;
      case "Close fan tachometer":
      case "Hide fan tachometer":
      case "Remove fan tachometer":
      case "Close fan speed":
      case "Hide fan speed":
      case "Remove fan speed":
      GameObject.Find ("Fan Tachometer").GetComponent<Text> ().enabled = false;
      break;
      case "Close oxygen pressure":
      case "Hide oxygen pressure":
      case "Remove oxygen pressure":
      GameObject.Find ("Oxygen Pressure").GetComponent<Text> ().enabled = false;
      break;
      case "Close oxygen rate":
      case "Hide oxygen rate":
      case "Remove oxygen rate":
      GameObject.Find ("").GetComponent<Text> ().enabled = false;
      break;
      case "Close battery capacity":
      case "Hide battery capacity":
      case "Remove battery capacity":
      GameObject.Find ("Battery Capacity").GetComponent<Text> ().enabled = false;
      break;
      case "Close water vapor pressure":
      case "Hide water vapor pressure":
      case "Remove water vapor pressure":
      GameObject.Find ("H2O Gas Pressure").GetComponent<Text> ().enabled = false;
      break;
      case "Close water pressure":
      case "Hide water pressure":
      case "Remove water pressure":
      GameObject.Find ("H2O Liquid Pressure").GetComponent<Text> ().enabled = false;
      break;
      case "Close secondary oxygen pressure":
      case "Hide secondary oxygen pressure":
      case "Remove secondary oxygen pressure":
      GameObject.Find ("SOP Pressure").GetComponent<Text> ().enabled = false;
      break;
      case "Close secondary oxygen rate":
      case "Hide secondary oxygen rate":
      case "Remove secondary oxygen rate":
      GameObject.Find ("SOP Rate").GetComponent<Text> ().enabled = false;
      break;
      case "Close battery time":
      case "Hide battery time":
      case "Remove battery time":
      GameObject.Find ("").GetComponent<Text> ().enabled = false;
      break;
      case "Close oxygen time":
      case "Hide oxygen time":
      case "Remove oxygen time":
      GameObject.Find ("").GetComponent<Text> ().enabled = false;
      break;
      case "Close water time":
      case "Hide water time":
      case "Remove water time":
      GameObject.Find ("").GetComponent<Text> ().enabled = false;
      break;
      // case "Close Heart Rate":
      // case "Hide Heart Rate":
      // case "Remove Heart Rate":
      // GameObject.Find ("EVA Clock").GetComponent<Text> ().enabled = false;
      // break;
    }
  }
  public void OnSpeechKeywordRecognized(SpeechEventData eventData)
  {
      ToggleObject(eventData.RecognizedText);
  }
}
