using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


#if !UNITY_EDITOR // if in hololens
	using System.Linq;
	using System.Runtime.InteropServices.WindowsRuntime;
	using Windows.Networking;
	using Windows.Networking.Sockets;
	using Windows.Storage.Streams;
#endif


public class NetworkClient : MonoBehaviour
{
	string temp;
	string newMessage;
	const int INT_SIZE = 8;
	int maxDecimals = 1; // max number of decimal places
	Text informatic;
	Byte[] receiveBytes;
	Dictionary<string, string> telemetry = new Dictionary<string, string> ();
	static string[] keys = new string[20] {"EVA Time","O2 Off Toggle","SOP Toggle","Battery Capacity","Fan Failure Toggle","Fan Tachometer","H20 Gas Pressure","Internal Suit Pressure",
		"No Vent Flow Toggle","Oxygen Pressure","Oxygen Rate","SOP Pressure","SOP Rate","Spacesuit Presser Emergency Toggle","Sub Pressure",
		"Sub Temperature","Time Life Battery","Time Life Oxygen","Time Life Water","Vehicle Power Present"}; 
	static string holoLensIP = "127.0.0.1";
	int port = 5005;
	#if !UNITY_EDITOR // if in hololens	
		//static string holoLensIP = "127.0.0.1";
		DatagramSocket socket = new DatagramSocket();
		HostName host = new HostName(holoLensIP);
		//int port = 5005;
	#else
		// Define network
		UdpClient client;
		int receivePort = 5005;
		string serverIP;
		IPEndPoint remoteEP;
	#endif


	// Use this for initialization
	void Start()
	{
		informatic = gameObject.GetComponent<Text> ();	// set variable as Text game object
		informatic.text = "Connecting to Server";
		#if !UNITY_EDITOR // only run on the hololens
		/*
			socket.MessageReceived += socket_MessageReceived;
			System.Diagnostics.Debug.WriteLine("Attempting to Connect...");
			socket.BindEndpointAsync(host, port.ToString());
			System.Diagnostics.Debug.WriteLine("Listening...");
			
			// build dictionary
			foreach (string info in keys) {
			telemetry.Add (info, "");
			}
		*/
		#else
		// build dictionary
		foreach (string info in keys) {
			telemetry.Add (info, "");
		}

		// initialize network
		Debug.Log("Starting Client");
		remoteEP = new IPEndPoint(IPAddress.Any, receivePort);
		client = new UdpClient(remoteEP);

		// initialize text object
		informatic = gameObject.GetComponent<Text> ();	// set variable as Text game object
		informatic.text = "Connecting to Server";
		#endif
	}



	// Update is called once per frame
	void Update()
	{
		#if !UNITY_EDITOR // only run on the hololens
		//informatic.text = BitConverter.ToString(receiveBytes, 0);

		#else 
		int counter = 0;
		// import telemetry
		if (client.Available > 0) {
			byte[] data = client.Receive(ref remoteEP);
			temp = Encoding.ASCII.GetString(data);
			String[] substrings = temp.Split(','); // spliat at ,
			foreach (var substring in substrings){
				if (counter < 20) {
					String[] subsubstrings = substring.Split (':'); // splot at :
					//truncate decimal places
					String[] value = subsubstrings[1].Split('.'); // split at decimal
					if (value.Length == 2 && value [0].Length > maxDecimals){
						telemetry [keys[counter]] = value [0] + '.' +  value [1].Substring(0,maxDecimals);
					}else{
						telemetry [keys[counter]] = value [0];
					}
					counter = counter + 1;
				}
			}
			informatic.text = keys [0] + ':' + telemetry [keys [0]] + '\n';
			foreach (string info in keys){
				informatic.text = informatic.text + info + ':' + telemetry [info] + '\n';
			}

		}
		#endif
	}


	/*
	#if !UNITY_EDITOR
	void socket_MessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
	{
	receiveBytes = args.GetDataReader().ReadBuffer(256).ToArray();
	newMessage = BitConverter.ToString(receiveBytes, 0);

	}
	#endif
	*/
}
