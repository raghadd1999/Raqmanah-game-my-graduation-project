using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Load_Sup_Profile : MonoBehaviour
{
    public Text U_Name;
    public Text Sel_Game;
    public Text Sel_Game_Score;
    public Text error;
    public Button L1;
    public Button L2;
    public Button L3;
    public Sprite Light2;
    public Sprite Dark2;
    public Sprite Light3;
    public Sprite Dark3;
    public Text Sel_Game1;

    public bool ShowTashkeel;
    public bool UseHinduNumbers;
    // Start is called before the first frame update
    void Start()
    {

        U_Name.text = ArabicSupport.ArabicFixer.Fix(Statec_Values.U_Name, ShowTashkeel, UseHinduNumbers);
        Sel_Game.text =  ArabicSupport.ArabicFixer.Fix(Statec_Values.selected_Game_NAME, ShowTashkeel, UseHinduNumbers) ;
        Sel_Game1.text = " : " + ArabicSupport.ArabicFixer.Fix(Statec_Values.selected_Game_NAME , ShowTashkeel, true) ; //display game name in the interface
        L2.enabled = false; // to locked level 2 and 3
        L3.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        Sel_Game_Score.text = Statec_Values.selected_Level_Score; //display game score in the interface

        if (int.Parse(Statec_Values.selected_Level_Score) < 15)
        {
            L2.enabled = false;
            L3.enabled = false;
            L2.image.overrideSprite = Dark2;
            L3.image.overrideSprite = Dark3;
        }
        if (int.Parse(Statec_Values.selected_Level_Score) >= 15 && int.Parse(Statec_Values.selected_Level_Score) < 30)
        {
            L2.enabled = true;
            L3.enabled = false;
            L2.image.overrideSprite = Light2;
            L3.image.overrideSprite = Dark3;
        }
        if (int.Parse(Statec_Values.selected_Level_Score) >= 30)
        {
            L2.enabled = true;
            L3.enabled = true;
            L2.image.overrideSprite = Light2;
            L3.image.overrideSprite = Light3;
        }
    }

}
