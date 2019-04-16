using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


 
 public class ButtonNetwork : MonoBehaviour
{
    CustomNetworkManager manager;
    public Text text;
    public MeshRenderer m_ButtonHighlight;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<CustomNetworkManager>();
    }
    public void OnGaze(bool hasGaze)
    {
        m_ButtonHighlight.enabled = hasGaze;
    }

    public void OnSelect()
    {
        text.text = "Pressed";
        manager.JoinGame();
    }
}

