using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using HoloToolkit.Unity;

public class GrammarManager : MonoBehaviour {
    [Tooltip("The file name (including filetype) of the SRGS file to use for recognition. This file must be in the StreamingAssets/SRGS folder.")]
    public string SRGSFileName;

    private GrammarRecognizer grammarRecognizer;
    public TextToSpeech textToSpeechService;
    public StatSpeechToText statToTextSevice;
    public SubMenuBehavior mainSubMenu;
    public SubMenuPadBehavior padSubMenu;
    public MenuStatManager menuStatManager;

    [Tooltip("Dictionary of stats associated with each SubMenu")]
    public List<string> intStats = new List<string> { "suit pressure", "internal pressure", "internal suit pressure", "oxygen pressure","o2 pressure", "oxygen rate", "o2 rate", "oxygen time", "o2 time" };
    public List<string> miscStats = new List<string> { "battery capacity", "battery", "battery time", "fan tachometer", "fan speed", "heart rate" };
    public List<string> subStats = new List<string> { "sublimator temperature", "sub temp", "sublimator pressure", "sub pressure" };
    public List<string> h20Stats = new List<string> { "h2o gas pressure","h2o vapor pressure","h2o gas", "water gas", "water gas pressure", "water vapor pressure", "water liquid", "water liquid temperature", "h2o liquid", "h2o liquid pressure", "h2o time", "water time" };
    public List<string> sopStats = new List<string> { "secondary oxgygen pressure", "secondary o2 pressure", "sop pressure", "secondary oxygen rate", "secondary o2 rate", "sop rate" };

    // Use this for initialization
    void Start () {
        if (string.IsNullOrEmpty(SRGSFileName)) {
            Debug.LogError("Please specify an SRGS file name in GrammarManager.cs on " + this.name + " GameObject.");
            return;
        }
        // Instantiate the GrammarRecognizer, passing in the path to the SRGS file in the StreamingAssets folder.
        try {
            grammarRecognizer = new GrammarRecognizer(Application.streamingAssetsPath + "/SRGS/"+ SRGSFileName);
            grammarRecognizer.OnPhraseRecognized += Grammar_OnPhraseRecognized;
            grammarRecognizer.Start();
        }
        catch {
            // If the file specified to the GrammarManager doesn't exist, let the user know.
            Debug.LogError("Check the SRGS file name in the Inspector on GrammarManager.cs and that the file's in the StreamingAssets folder.");
        }
    }

    private void Grammar_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
        SemanticMeaning[] meanings = args.semanticMeanings;
        string spokenWords = args.text.ToLower();
        Debug.Log(spokenWords);

        foreach (SemanticMeaning sm in meanings) {
            Debug.Log(sm.key+":"+sm.values[0]);
        }
        //Check if Open,Show,Display Command
        if (spokenWords.Contains("open") || spokenWords.Contains("show") || spokenWords.Contains("display")) {
            HandleOpenCommand(meanings);
        }
        //Check if Close, Hide Command
        else if (spokenWords.Contains("close") || spokenWords.Contains("hide")) {
            HandleCloseCommand(meanings);
        }
        //Check if Push Command
        else if (spokenWords.Contains("push")) {
            HandlePushCommand(meanings);
        }
        //Check  if Read command
        else if (spokenWords.Contains("read") || spokenWords.Contains("what is")) {
            HandleReadCommand(meanings);
        }
        //Check  if Clear command
        else if (spokenWords.Contains("clear")) {
            HandleClearCommand(meanings);
        } else {
        Debug.Log("Dont recognize command");
        }
    }

    private void HandleOpenCommand(SemanticMeaning[] meanings) {
        foreach (SemanticMeaning sm in meanings) {
            if (sm.key == "stat") {
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
            } else if (sm.key == "submenu") {
                mainSubMenu.Show(sm.values[0]);
            } else {
                PleaseRepeatCommand();
            }
        }
    }

    private void HandleCloseCommand(SemanticMeaning[] meanings) {
        foreach (SemanticMeaning sm in meanings) {
            if (sm.key == "stat") {
                if (intStats.Contains(sm.values[0])) {
                    mainSubMenu.Hide("Int");
                } else if (miscStats.Contains(sm.values[0])) {
                    mainSubMenu.Hide("Misc");
                } else if (subStats.Contains(sm.values[0])) {
                    mainSubMenu.Hide("Sub");
                } else if (sopStats.Contains(sm.values[0])) {
                    mainSubMenu.Hide("SOP");
                } else if (h20Stats.Contains(sm.values[0])) {
                    mainSubMenu.Hide("H20");
                } else {
                    PleaseRepeatCommand();
                }
            } else if (sm.key == "submenu") {
                mainSubMenu.Hide(sm.values[0]);
            } else {
                PleaseRepeatCommand();
            }
        }
    }

    private void HandlePushCommand(SemanticMeaning[] meanings) {
        foreach (SemanticMeaning sm in meanings) {
            if (sm.key == "stat") {
                Debug.Log("push: "+sm.values[0]);
                try {
                    MenuStat menuStat = menuStatManager.subMenuDictionary[sm.values[0]];
                    padSubMenu.Push(menuStat);
                } catch {
                    PleaseRepeatCommand();
                }
            } else {
                PleaseRepeatCommand();
            }
        }
    }

    private void HandleReadCommand(SemanticMeaning[] meanings) {
        foreach (SemanticMeaning sm in meanings) {
            if (sm.key == "stat") {
                Debug.Log("read: " + sm.values[0]);
                try {

                    MenuStat menuStat = menuStatManager.subMenuDictionary[sm.values[0]];
					statToTextSevice.ReadOutStat(menuStat.dataRequestName, menuStat.readoutName, menuStat.readOutUnits);

                } catch {
                    PleaseRepeatCommand();
                }
            } else {
                PleaseRepeatCommand();
            }
        }
    }

    private void HandleClearCommand(SemanticMeaning[] meanings) {

        foreach (SemanticMeaning sm in meanings) {
            if (sm.key == "stat") {
                Debug.Log("clear: " + sm.values[0]);
                try {
                    MenuStat menuStat = menuStatManager.subMenuDictionary[sm.values[0]];
                    padSubMenu.Clear(menuStat);
                } catch {
                    PleaseRepeatCommand();
                }
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
