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
    public List<string> defaultStats = new List<string> {"def_def", "menulist_def"};
    public List<string> intStats = new List<string> { "int", "p_suit", "p_o2", "rate_o2", "t_oxygen" };
    public List<string> miscStats = new List<string> { "misc", "cap_battery", "t_battery", "v_fan"};
    public List<string> subStats = new List<string> { "sub", "t_sub", "p_sub" };
    public List<string> h20Stats = new List<string> { "h2o", "p_h2o_g", "p_h2o_l", "t_water"};
    public List<string> sopStats = new List<string> { "sop", "p_sop", "rate_sop" };

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
        //PhraseRecognizedEventArgs.confidence = high;
        // Debug.Log("Recognition result summary:");
        // Debug.Log(
        // "  Recognized phrase: {0}\n" +
        // "  Confidence score {1}\n" +
        // "  Grammar used: {2}\n",
        // args.Result.Text, args.Result.Confidence, args.Result.Grammar.Name);
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
                } else if (defaultStats.Contains(sm.values[0])) {
                    mainSubMenu.Show("Default");
                } else if (subStats.Contains(sm.values[0])) {
                    mainSubMenu.Show("Sub");
                } else if (sopStats.Contains(sm.values[0])) {
                    mainSubMenu.Show("SOP");
                } else if (h20Stats.Contains(sm.values[0])) {
                    mainSubMenu.Show("H2O");
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
                } else if (defaultStats.Contains(sm.values[0])) {
                    mainSubMenu.Hide("Default");
                } else if (subStats.Contains(sm.values[0])) {
                    mainSubMenu.Hide("Sub");
                } else if (sopStats.Contains(sm.values[0])) {
                    mainSubMenu.Hide("SOP");
                } else if (h20Stats.Contains(sm.values[0])) {
                    mainSubMenu.Hide("H2O");
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
                    //PleaseRepeatCommand();
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
