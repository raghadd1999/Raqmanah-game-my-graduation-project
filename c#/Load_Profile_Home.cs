using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_Profile_Home : MonoBehaviour
{

    // to support arabic in script : https://www.marahil.org/%D8%A7%D9%84%D9%86%D8%B5%D9%88%D8%B5-%D8%A8%D8%A7%D9%84%D9%84%D8%BA%D8%A9-%D8%A7%D9%84%D8%B9%D8%B1%D8%A8%D9%8A%D8%A9-%D9%85%D8%AD%D8%B1%D9%83-unity/
    public Text User_Name;
    public Text score;
    public bool ShowTashkeel;
    public bool UseHinduNumbers;
    // Start is called before the first frame update
    void Start()
    {
        User_Name.text = " ";
        User_Name.text += " " + ArabicSupport.ArabicFixer.Fix(Statec_Values.U_Name, ShowTashkeel, UseHinduNumbers); ;
        score.text = " " + ArabicSupport.ArabicFixer.Fix(Statec_Values.U_Total.ToString(), ShowTashkeel, true); ;
    }


}
