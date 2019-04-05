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

namespace Network{
	public class NetworkConnect
	{
		// preallocate inputs
		static public string serverIP;
		static public int receivePort;

		// preallocate and predefine
		string newMessage;
		string temp;
		Byte[] receiveBytes;
		const int INT_SIZE = 8;
		int maxDecimals = 1; // max number of decimal places
		static string[] keys = new string[19] {"EVA Time","O2 Off Toggle","SOP Toggle","Battery Capacity","Fan Failure Toggle","Fan Tachometer","H20 Gas Pressure","Internal Suit Pressure",
			"No Vent Flow Toggle","Oxygen Pressure","Oxygen Rate","SOP Pressure","SOP Rate","Spacesuit Pressure Emergency Toggle","Sub Pressure",
			"Sub Temperature","Time Life Battery","Time Life Oxygen","Time Life Water"}; 

		#if !UNITY_EDITOR // if in hololens	
		static string holoLensIP = serverIP;
		DatagramSocket socket = new DatagramSocket();
		HostName host = new HostName(holoLensIP);
		int port = receivePort;
		#else
		// Define network
		UdpClient client;
		IPEndPoint remoteEP;
		#endif

		// Define network
		public static Dictionary<string, string> telemetry = new Dictionary<string, string> (); // holds all information!!!!

		// define inputs
		public NetworkConnect(string ip, int port)
		{
			serverIP = ip;
			receivePort = port;
		}

		// build dictionary and connect
		public void onStart()
		{
			#if !UNITY_EDITOR
				socket.MessageReceived += socket_MessageReceived;
				System.Diagnostics.Debug.WriteLine("Attempting to Connect...");
				socket.BindEndpointAsync(host, port.ToString());
				System.Diagnostics.Debug.WriteLine("Listening...");

				// build dictionary
				foreach (string info in keys) {
				telemetry.Add (info, "");
				}
			#else
				foreach (string info in keys) 
				{
					telemetry.Add (info, "");
				}
				// initialize network
				Debug.Log ("Starting Client");
				remoteEP = new IPEndPoint (IPAddress.Any, receivePort);
				client = new UdpClient (remoteEP);
			#endif
		}
			
		// function to decode data stream and parce data into a dictionary 
		public Dictionary<string, string> onUpdate()
		{
			#if !UNITY_EDITOR
				return telemetry;
			#else
				int counter = 0;
				// import telemetry
				if (client.Available > 0) 
				{
					byte[] data = client.Receive(ref remoteEP);
					temp = Encoding.ASCII.GetString(data);
					String[] substrings = temp.Split(','); // split at ,
					foreach (var substring in substrings)
					{
					if (counter < keys.Length)
						{
							String[] subsubstrings = substring.Split (':'); // splot at :
							//truncate decimal places
							String[] value = subsubstrings[1].Split('.'); // split at decimal
							if (value.Length == 2 && value [0].Length > maxDecimals){
								telemetry [keys[counter]] = value [0] + '.' +  value [1].Substring(0,maxDecimals); // define dictionary values
							}else
							{
								telemetry [keys[counter]] = value [0];
							}
							counter = counter + 1;
						}
					}
				}
				return telemetry;
			#endif
		}


	#if !UNITY_EDITOR
	void socket_MessageReceived(DatagramSocket sender, DatagramSocketMessageReceivedEventArgs args)
	{
	receiveBytes = args.GetDataReader().ReadBuffer(256).ToArray();
	newMessage = BitConverter.ToString(receiveBytes, 0);
	}
	#endif


	}
}
