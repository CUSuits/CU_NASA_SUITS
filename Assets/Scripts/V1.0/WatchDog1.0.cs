using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Network;

// watchdog class: hold limit information on suit data and check if data is in range. Flag out of range data

namespace WatchDog{
	
	public class watchDog{
		public int state{ get; set; } // -1: below min, 0: nominal, 1: above max
		public int min{ get; set; }
		public int max{ get; set; }
		public int toggle{ get; set; } // 1: on, 0: off (default for non toggled values is 1)
		public string current{ get; set; }

		public int checkStatus(string value) // input form telemetry
		{
			if(Convert.ToDouble(value) < min){
				state = -1;
			}
			if(Convert.ToDouble(value) > max){
				state = 1;
			}
			if(min < Convert.ToDouble(value) && Convert.ToDouble(value) < max){
				state = 0;
			}
			return state;
		}
	}
				
}