using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;

public class Load_Check_Card : MonoBehaviour
{
    public Text T1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Statec_Values.selected_Game_ID == "1") // الجمع
        {
            if (Statec_Values.selected_Level_ID == "1") // المستوى الاول
            {
                T1.text= ArabicSupport.ArabicFixer.Fix("( 1 ، 2 ، 3 )", false, true);
            }
            if (Statec_Values.selected_Level_ID == "2") // المستوى الثاني
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 4 ، 5 ، 6 )", false, true);
            }
            if (Statec_Values.selected_Level_ID == "3") // المستوى الثالث
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 7 ، 8 ، 9 )", false, true);
            }

        }
        
        if (Statec_Values.selected_Game_ID == "2") // لعبه الطرح
        {
            if (Statec_Values.selected_Level_ID == "1") // المستوى الاول
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 10 ، 11 ، 12 )", false, true);
            }
            if (Statec_Values.selected_Level_ID == "2") // المستوى الثاني
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 13 ، 14 ، 15 )", false, true);
            }
            if (Statec_Values.selected_Level_ID == "3") // المستوى الثالث
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 16 ، 17 ، 18 )", false, true);
            }

        }
        if (Statec_Values.selected_Game_ID == "3") // لعبه ترتيب الاعداد
        {
            if (Statec_Values.selected_Level_ID == "1") // المستوى الاول
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 19 ، 20 ، 21 )", false, true);
            }
            if (Statec_Values.selected_Level_ID == "2") // المستوى الثاني
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 22 ، 23 ، 24 )", false, true);
            }
            if (Statec_Values.selected_Level_ID == "3") // المستوى الثالث
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 25 ، 26 ، 27 )", false, true);
            }

        }
        if (Statec_Values.selected_Game_ID == "4") // لعبه مقارنه الاعداد
        {
            if (Statec_Values.selected_Level_ID == "1") // المستوى الاول
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 28 ، 29 ، 30 )", false, true);
            }
            if (Statec_Values.selected_Level_ID == "2") // المستوى الثاني
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 31 ، 32 ، 33 )", false, true);
            }
            if (Statec_Values.selected_Level_ID == "3") // المستوى الثالث
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 34 ، 35 ، 36 )", false, true);
            }

        }
        if (Statec_Values.selected_Game_ID == "5") // لعبه الاشكال الهندسيه
        {
            if (Statec_Values.selected_Level_ID == "1") // المستوى الاول
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 37 ، 38 ، 39 )", false, true);
            }
            if (Statec_Values.selected_Level_ID == "2") // المستوى الثاني
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 40 ، 41 ، 42 )", false, true);
            }
            if (Statec_Values.selected_Level_ID == "3") // المستوى الثالث
            {
                T1.text = ArabicSupport.ArabicFixer.Fix("( 43 ، 44 ، 45 )", false, true);
            }

        }
    }
}
