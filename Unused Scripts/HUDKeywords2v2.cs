using UnityEngine;
using HoloToolkit.Unity.InputModule;
using UnityEngine.UI;
using System.Text;



  public class HUDKeywords2v2 : MonoBehaviour, ISpeechHandler
  {
    static string[] keys = new string[14] {"Heart Rate","Suit Pressure",
    "SUB Pressure","SUB Temperature","Fan Tachometer","Oxygen Pressure",
    "Oxygen Rate","Battery Capacity","Water Vapor Pressure","Water Pressure",
    "Secondary Oxygen Pressure","Secondary Oxygen Rate","Battery Time",
    "Oxygen Time","Water Time"};

    // [{"create_date":"2018-04-16T14:56:11.107Z","heart_bpm":"86","p_suit":"3.99","p_sub":"7.98","t_sub":"5","v_fan":"39960","p_o2":"16","rate_o2":"0.9","cap_battery":"29","p_h2o_g":"16","p_h2o_l":"15","p_sop":"864","rate_sop":"1.0","t_battery":"9:59:19","t_oxygen":"9:59:55","t_water":"9:59:55"}]
    // Server address:

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
      }
    }

    public void ToggleObject(string command)
    {
      switch (command)
      {
        //Commands for opening
        case "Open " + keys[0] || "Show " + keys[0] || "Display " + keys[0]:
        GameObject.Find ("Heart Rate").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[1] || "Show " + keys[1] || "Display " + keys[1]:
        GameObject.Find ("Internal Suit Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[2] || "Show " + keys[2] || "Display " + keys[2]:
        GameObject.Find ("Sub Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[3] || "Show " + keys[3] || "Display " + keys[3]:
        GameObject.Find ("Sub Temperature").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[4] || "Show " + keys[4] || "Display " + keys[4]:
        GameObject.Find ("Fan Tachometer").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[5] || "Show " + keys[5] || "Display " + keys[5]:
        GameObject.Find ("Oxygen Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[6] || "Show " + keys[6] || "Display " + keys[6]:
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[7] || "Show " + keys[7] || "Display " + keys[7]:
        GameObject.Find ("Battery Capacity").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[8] || "Show " + keys[8] || "Display " + keys[8]:
        GameObject.Find ("H2O Gas Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[9] || "Show " + keys[9] || "Display " + keys[9]:
        GameObject.Find ("H2O Liquid Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[10] || "Show " + keys[10] || "Display " + keys[10]:
        GameObject.Find ("SOP Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[11] || "Show " + keys[11] || "Display " + keys[11]:
        GameObject.Find ("SOP Rate").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[12] || "Show " + keys[12] || "Display " + keys[12]:
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[13] || "Show " + keys[13] || "Display " + keys[13]:
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        break;
        case "Open " + keys[14] || "Show " + keys[14] || "Display " + keys[14]:
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        break;

        //Commands for closing
        case "Close " + keys[0] || "Hide " + keys[0]:
        GameObject.Find ("Heart Rate").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[1] || "Hide " + keys[1]:
        GameObject.Find ("Internal Suit Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[2] || "Hide " + keys[2]:
        GameObject.Find ("Sub Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[3] || "Hide " + keys[3]:
        GameObject.Find ("Sub Temperature").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[4] || "Hide " + keys[4]:
        GameObject.Find ("Fan Tachometer").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[5] || "Hide " + keys[5]:
        GameObject.Find ("Oxygen Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[6] || "Hide " + keys[6]:
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[7] || "Hide " + keys[7]:
        GameObject.Find ("Battery Capacity").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[8] || "Hide " + keys[8]:
        GameObject.Find ("H2O Gas Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[9] || "Hide " + keys[9]:
        GameObject.Find ("H2O Liquid Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[10] || "Hide " + keys[10]:
        GameObject.Find ("SOP Pressure").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[11] || "Hide " + keys[11]:
        GameObject.Find ("SOP Rate").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[12] || "Hide " + keys[12]:
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[13] || "Hide " + keys[13]:
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        break;
        case "Close " + keys[14] || "Hide " + keys[14]:
        GameObject.Find ("").GetComponent<Text> ().enabled = true;
        break;
      }
    }

    // public void Readout(string command)
    // {
    //     switch (command)
    //     {
    //         case "Basic on":
    //             GameObject.Find ("EVA Clock").GetComponent<Text> ().enabled = true;
    //             break;
    //         case "Basic off":
    //             GameObject.Find ("EVA Clock").GetComponent<Text> ().enabled = false;
    //             break;
    //     }
    // }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
      ToggleObject(eventData.RecognizedText);
    }

  }
