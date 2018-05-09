using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity;

public class GrammarRecog : MonoBehaviour {
    private GrammarRecognizer grammarRecognizer;
    public TextToSpeech textToSpeechService;

    // Use this for initialization
    void Start () {

        grammarRecognizer = new GrammarRecognizer(Application.streamingAssetsPath + "/SRGS/grammar.xml");

        grammarRecognizer.OnPhraseRecognized += Grammar_OnPhraseRecognized;
        grammarRecognizer.Start();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Grammar_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        SemanticMeaning[] meanings = args.semanticMeanings;
        foreach (SemanticMeaning sm in meanings) {
            Debug.Log(sm.key);
            foreach (string value in sm.values) {
                Debug.Log(value);
                textToSpeechService.StartSpeaking(value);
            }
                
        }
    }
}
