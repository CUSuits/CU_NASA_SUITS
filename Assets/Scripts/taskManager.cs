using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.UI;
using System.Text;

namespace TaskManager{
	
	public class taskManager
	{
		//-----------------------------------------------------------
		// hold task in string array
		public Dictionary<int, string> task = new Dictionary<int, string>()
		{
			{0, "--"},
			{1, "Step 1"},
			{2, "Step 2"},
			{3, "Step 3"},
			{4, "Step 4"},
			{5, "Step 5"},
			{6, "Step 6"},
			{7, "--"}
		};

		// define counters
		public int taskLength = 6;
		public int previousStep = 0;
		public int currentStep = 1; 
		public int nextStep = 2; 	// get text objects

		public void initializeTask()
		{
			Text current = GameObject.Find("Current").GetComponent<Text>();
			Text next = GameObject.Find("Next").GetComponent<Text>();
			Text previous = GameObject.Find("Previous").GetComponent<Text>();
			// initialize text objects
			previous.text = task[0];
			current.text = task[1];
			next.text = task [2];
		}

		// function to be called in voice manager to go to next step
		public void NextStep(){
			Text current = GameObject.Find("Current").GetComponent<Text>();
			Text next = GameObject.Find("Next").GetComponent<Text>();
			Text previous = GameObject.Find("Previous").GetComponent<Text>();
			if (0 <= currentStep+1 && currentStep+1 <= taskLength) {
				//iterate step location
				previousStep = previousStep + 1;
				currentStep = currentStep + 1; 
				nextStep = nextStep + 1;
				// update text objects
				previous.text = task [previousStep];
				current.text = task [currentStep];
				next.text = task [nextStep];
			}
		}

		// function to be called in voice manager to go to previous step
		public void PrevioustStep(){
			Text current = GameObject.Find("Current").GetComponent<Text>();
			Text next = GameObject.Find("Next").GetComponent<Text>();
			Text previous = GameObject.Find("Previous").GetComponent<Text>();
			if (2 <= currentStep && currentStep <= taskLength) {
				//iterate step location
				previousStep = previousStep - 1;
				currentStep = currentStep - 1; 
				nextStep = nextStep - 1;
				// update text objects
				previous.text = task [previousStep];
				current.text = task [currentStep];
				next.text = task [nextStep];
			}
		}
		// function to switch task procedures


	}



	}
