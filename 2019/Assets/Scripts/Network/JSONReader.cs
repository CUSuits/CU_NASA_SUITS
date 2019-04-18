using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to connect to networks and place switch/suit data into classes
/// </summary>
public class JSONReader : MonoBehaviour
{
    // change IP address here in URL
    public string url_data;
    public string url_switch;
    // store suit and switch data
    public SuitData suitData;
    public SwitchData switchData;
    // if/if-not coroutine is running
    private bool isFetchingSwitch;
    private bool isFetchingData;


    /// <summary>
    /// Get suit data and update class attributes
    /// </summary>
    IEnumerator FetchData()
    {
        isFetchingData = true;
        string websiteText_data;
        using (WWW www = new WWW(url_data))
        {
            yield return www;
            websiteText_data = www.text;
        }
        websiteText_data = websiteText_data.TrimEnd(']');
        websiteText_data = websiteText_data.TrimStart('[');
        suitData = JsonUtility.FromJson<SuitData>(websiteText_data);
        isFetchingData = false;
    }

    /// <summary>
    /// Get switch data and update class attributes
    /// </summary>
    IEnumerator FetchSwitch()
    {
        isFetchingSwitch = true;
        string websiteText_switch;
        using (WWW www = new WWW(url_switch))
        {
            yield return www;
            websiteText_switch = www.text;
        }
        websiteText_switch = websiteText_switch.TrimEnd(']');
        websiteText_switch = websiteText_switch.TrimStart('[');
        switchData = JsonUtility.FromJson<SwitchData>(websiteText_switch);
        isFetchingSwitch = false;
    }

    // update class attributes
    private void Update()
    {
        if (!isFetchingData)
        {
            StartCoroutine(FetchData());
            
        }
        if (!isFetchingSwitch)
        {
            StartCoroutine(FetchSwitch());
            
        }
    }
}