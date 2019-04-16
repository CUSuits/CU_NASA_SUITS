using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class CustomNetworkManager : NetworkManager{

    // Use this for initialization
    public void StarupHost()
    {
        setPort();
        NetworkManager.singleton.StartHost();
    }
    public void JoinGame()
    {
        SetIPAddress();
        setPort();
        NetworkManager.singleton.StartClient();
    }
    private void SetIPAddress()
    {
        string Address = "";
        NetworkManager.singleton.networkAddress = Address;
    }
    private void setPort()
    {
        NetworkManager.singleton.networkPort = 7777;
    }
}
