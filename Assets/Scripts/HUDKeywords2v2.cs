using UnityEngine;
using UnityEngine.UI;
using System.Text;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class HUDKeywords2 : MonoBehaviour, ISpeechHandler
    {
      static string[] keys = new string[19] {"Heart Rate","Suit Pressure",
      "SUB Pressure","SUB Temperature","Fan Tachometer","Oxygen Pressure",
      "Oxygen Rate","Battery Capacity","Water Vapor Pressure","Water Pressure",
      "Secondary Oxygen Pressure","Secondary Oxygen Rate","Battery Time",
      "Oxygen Time","Water Time"};

      [{"create_date":"2018-04-16T14:56:11.107Z","heart_bpm":"86","p_suit":"3.99","p_sub":"7.98","t_sub":"5","v_fan":"39960","p_o2":"16","rate_o2":"0.9","cap_battery":"29","p_h2o_g":"16","p_h2o_l":"15","p_sop":"864","rate_sop":"1.0","t_battery":"9:59:19","t_oxygen":"9:59:55","t_water":"9:59:55"}]
      Server address:


        public void ToggleObject(string command)
        {
          switch (command)
          {
            case "Open" + keys[0]:
            GameObject.Find ("Heart Rate").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[1]:
            GameObject.Find ("Internal Suit Pressure").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[2]:
            GameObject.Find ("Sub Pressure").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[3]:
            GameObject.Find ("Sub Temperature").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[4]:
            GameObject.Find ("Fan Tachometer").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[5]:
            GameObject.Find ("Oxygen Pressure").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[6]:
            GameObject.Find ("").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[7]:
            GameObject.Find ("Battery Capacity").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[8]:
            GameObject.Find ("H2O Gas Pressure").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[9]:
            GameObject.Find ("H2O Liquid Pressure").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[10]:
            GameObject.Find ("SOP Pressure").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[11]:
            GameObject.Find ("SOP Rate").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[12]:
            GameObject.Find ("").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[13]:
            GameObject.Find ("").GetComponent<Text> ().enabled = true;
            break;
            case "Open" + keys[14]:
            GameObject.Find ("").GetComponent<Text> ().enabled = true;
            break;




          }
        }

        public void Readout(string command)
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
}
