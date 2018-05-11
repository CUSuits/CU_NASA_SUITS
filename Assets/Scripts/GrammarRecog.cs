using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity;

public class GrammarRecog : MonoBehaviour {
    private GrammarRecognizer grammarRecognizer;
    public TextToSpeech textToSpeechService;
    public SubMenuBehavior mainSubMenu;
    public SubMenuPadBehavior padSubMenu;

    public List<string> intStats = new List<string> { "suit pressure", "oxygen pressure", "oxygen rate" };
    public List<string> miscStats = new List<string> { "battery capacity" };
    public List<string> subStats = new List<string> { "sublimator temperature", "sublimator pressure" };
    public List<string> h20Stats = new List<string> { "a", "b" };
    public List<string> sopStats = new List<string> { "secondary oxgygen pressure", "secondary oxygen rate" };

    // Use this for initialization
    void Start () {
        //grammar2
        grammarRecognizer = new GrammarRecognizer(Application.streamingAssetsPath + "/SRGS/grammar.xml");
        grammarRecognizer.OnPhraseRecognized += Grammar_OnPhraseRecognized;
        grammarRecognizer.Start();
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    private void Grammar_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        SemanticMeaning[] meanings = args.semanticMeanings;
        string spokenWords = args.text.ToLower();
        Debug.Log(spokenWords);
        foreach (SemanticMeaning sm in meanings) {
            Debug.Log(sm.key);
        }
        //Check if Open,Show,Display Command
        if (spokenWords.Contains("open") || spokenWords.Contains("show") || spokenWords.Contains("display")) {
            HandleOpenCommand(meanings);
        }
        //Check if Close, Hide Command

        //Check if Push Command

        //Check  if Read command
        else {
            Debug.Log("Dont recognize command");
        }
    }

    private void HandleOpenCommand(SemanticMeaning[] meanings) {
        foreach (SemanticMeaning sm in meanings) {
            if (sm.key == "Stat") {
                if (intStats.Contains(sm.values[0])) {
                    mainSubMenu.Show("Int");
                } else if (miscStats.Contains(sm.values[0])) {
                    mainSubMenu.Show("Misc");
                } else if (subStats.Contains(sm.values[0])) {
                    mainSubMenu.Show("Sub");
                } else if (sopStats.Contains(sm.values[0])) {
                    mainSubMenu.Show("SOP");
                } else if (h20Stats.Contains(sm.values[0])) {
                    mainSubMenu.Show("H20");
                } else {
                    PleaseRepeatCommand();
                }
            } else if (sm.key == "SubMenu") {
                mainSubMenu.Show(sm.values[0]);
            } else {
                PleaseRepeatCommand();
            }
        }
    }


    private void PleaseRepeatCommand() {
        Debug.Log("Could not parse command");
        textToSpeechService.StartSpeaking("Sorry please repeat your command");
    }
}
