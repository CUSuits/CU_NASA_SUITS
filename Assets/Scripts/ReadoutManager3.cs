using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HoloToolkit.Unity.InputModule {
  public class ReadoutManager3 : MonoBehaviour {
    public TextToSpeech textToSpeech;

    // Use this for initialization
    void Start () {
      textToSpeech.Voice = TextToSpeechVoice.Mark;
    }

    public void PlayAudio(){
      #if !UNITY_EDITOR && UNITY_WSA
       textToSpeech.StartSpeaking("Hello Complicated World");
       #endif
    }
  }
}
