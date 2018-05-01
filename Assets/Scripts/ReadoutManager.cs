using UnityEngine;

namespace HoloToolkit.Unity.InputModule {
  public class ReadoutManager : MonoBehaviour {

    // Use this for initialization
    void Start () {
      var soundManager = GameObject.Find("Audio Manager");
      TextToSpeech textToSpeech = soundManager.GetComponent<TextToSpeech>();
      textToSpeech.Voice = TextToSpeechVoice.Mark;
      #if !UNITY_EDITOR && UNITY_WSA
      textToSpeech.PlaySpeech("Hello Complicated World");
      #endif
    }

    // Update is called once per frame
    void Update () {

    }
  }
}
