using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using ArabicSupport;

public class Check_Questions : MonoBehaviour
{
    public Text T;
    public Text A1;
    public Text A2;
    public Text A3;
    public Text MSG;
    public Text test;
    public Image Q_img;
    public Image Victory_img;
    public Image Wrong_img;
    public Sprite Tru;
    public Sprite Defult;
    public Sprite fals;
    private string R_A;
    public Button BA1;
    public Button BA2;
    public Button BA3;
    public Text Q_txt;
    Question Q = new Question(); // our data sturcture

    public bool ShowTashkeel;
    public bool UseHinduNumbers;


    // Start is called before the first frame update
    void Start()
    {
        MSG.enabled = false; // cards message erorrs
        test.text = Statec_Values.selected_Game_NAME_EN;
        Victory_img.gameObject.active = false; //correct reaction
        Wrong_img.gameObject.active = false; //false reaction
        Q_img.gameObject.active = false; // question/answer box
        T.text = "0"; // name 3D object
    }

    // Update is called once per frame
    void Update()
    {
        if (T.text != "0") // 3D object is found
        {

            Q_img.gameObject.active = true; // disblay the question box(image), not the question

            Q = Statec_Values.Ques(T.text); //call method Ques from Statec_Values (cs) and send 3D object name for retrieve the question
            if (T.text.Contains(Statec_Values.selected_Game_NAME_EN )) //return the name of the game to ensure the user is in the correct game
            {
                if (Q.Q_level.ToString() == Statec_Values.selected_Level_ID) //return the level number to ensure the user is in the correct level
                {
                    StartCoroutine(Check_Q()); // if the game and the level number are correct, go to Check_Q Function
                }
                else
                {
                    BA1.gameObject.active = false;
                    BA2.gameObject.active = false;
                    BA3.gameObject.active = false;
                    MSG.enabled = true;
                    //in case the child scan incorrect card thats does not beloong to the current level
                    MSG.text = ArabicSupport.ArabicFixer.Fix("هذه البطاقة لاتنتمي لهذا المستوى ", ShowTashkeel, true);
                }


            }
            else
            {

                BA1.gameObject.active = false;
                BA2.gameObject.active = false;
                BA3.gameObject.active = false;
                MSG.enabled = true;
                //in case the child scan incorrect card thats does not beloong to the current game
                MSG.text = ArabicSupport.ArabicFixer.Fix("هذه البطاقة لاتنتمي لهذة اللعبه ", ShowTashkeel, true);
            }
        }
        else
        {

            MSG.text = "";
            MSG.enabled = false;
            A1.text = "";
            A2.text = "";
            A3.text = "";
            Q_img.gameObject.active = false;
            BA1.image.overrideSprite = Defult;
            BA2.image.overrideSprite = Defult;
            BA3.image.overrideSprite = Defult;
        }

    }

    public void on_Next_Click()
    {
        BA1.enabled = BA2.enabled = BA3.enabled = true;
        Victory_img.gameObject.active = false;
        Wrong_img.gameObject.active = false;
        Q_img.gameObject.active = false;
        T.text = "0";
    }
    public void on_ReTry_Click()
    {
        BA1.enabled = BA2.enabled = BA3.enabled = true;
        Victory_img.gameObject.active = false;
        Wrong_img.gameObject.active = false;
        Q_img.gameObject.active = false;
        T.text = "0";
    }
    // evaluat child answer
    public void on_click(Button BT)
    {
        BA1.enabled = BA2.enabled = BA3.enabled = false;
        Text CH_T= BT.GetComponentInChildren(typeof(Text)) as Text;
      if (CH_T.text == R_A)//check the child anwser if it is correct
      {
          BT.image.overrideSprite = Tru;// display green color
          StartCoroutine(Updat_Data());// 5 points of the correct answer
          StartCoroutine(Add_Child_Q());// add to the total score the 5 points
          Victory_img.gameObject.active=true; // الاجابه صحيحه
      }
      else
      {
          BT.image.overrideSprite = fals;// display red color
            Wrong_img.gameObject.active = true; // الاجابه خاطئه اعد المحاوله
        }
    }
    [System.Obsolete]
    IEnumerator Updat_Data()
    {
        WWWForm form = new WWWForm();
        form.AddField("Ch_ID", Statec_Values.U_ID.ToString());
        form.AddField("L_ID", Statec_Values.selected_Game_ID);

        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/Update_Data.php", form))
        {
            yield return www.SendWebRequest();
            Statec_Values.selected_Level_Score =Convert.ToString(int.Parse(Statec_Values.selected_Level_Score) + 5);
            Statec_Values.U_Total = Statec_Values.U_Total + 5;// update child score
            //if the child finish a level.the numbers means (15:level 1 ,30:level 2, 45 level 3)

            if (Statec_Values.selected_Level_Score == "15" || Statec_Values.selected_Level_Score == "30" || Statec_Values.selected_Level_Score == "45" )
                {
                    Application.LoadLevel("levelUP");
                }



        }
    }
    [System.Obsolete]
    IEnumerator Add_Child_Q()
    {
        WWWForm form = new WWWForm();
        form.AddField("Ch_ID", Statec_Values.U_ID.ToString());
        form.AddField("Q_ID", T.text);

        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/add_child_Q.php", form))
        {
            yield return www.SendWebRequest();
        }


    }

    [System.Obsolete]
    IEnumerator Check_Q()
    {
        WWWForm form = new WWWForm();
        form.AddField("Ch_ID", Statec_Values.U_ID.ToString());
        form.AddField("Q_ID", T.text ); //game ID
        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/Check_Q.php", form))
        {
            yield return www.SendWebRequest();


            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);

            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log(responseText);



                if (responseText.Contains("Success"))
                {
                    BA1.gameObject.active = false;
                    BA2.gameObject.active = false;
                    BA3.gameObject.active = false;
                    MSG.enabled = true;
                    // if the child aready anwser the question
                    MSG.text = ArabicSupport.ArabicFixer.Fix("لقد اجبت بالفعل على هذا السؤال ", ShowTashkeel, true);
                }
                else
                {
                    BA1.gameObject.active = true;
                    BA2.gameObject.active = true;
                    BA3.gameObject.active = true;
                    MSG.text = "";
                    MSG.enabled=false;

                    A1.text = ArabicSupport.ArabicFixer.Fix(Q.A1, ShowTashkeel, true);
                    A2.text = ArabicSupport.ArabicFixer.Fix(Q.A2, ShowTashkeel, true);
                    A3.text = ArabicSupport.ArabicFixer.Fix(Q.A3, ShowTashkeel, true);
                    R_A = ArabicSupport.ArabicFixer.Fix(Q.R_A, ShowTashkeel, true); ;
                    Q_txt.text = ArabicSupport.ArabicFixer.Fix(Q.Q_T , ShowTashkeel, true); ;
                }





            }


        }
    }


}
