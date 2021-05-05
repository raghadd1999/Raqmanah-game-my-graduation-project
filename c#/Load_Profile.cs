using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ArabicSupport;
using UnityEngine.Networking;

public class Load_Profile : MonoBehaviour
{
    public Text User_Name;
    public Text score; // total score
    public Text score1; // +
    public Text score2; // -
    public Text score3; // ترتيب الاعداد
    public Text score4; // المقارنه
    public Text score5; // الاشكال الهندسيه
    public bool ShowTashkeel;
    public bool UseHinduNumbers;
    // Start is called before the first frame update
    void Start()
    {
        User_Name.text = " ";
        User_Name.text +=" " + ArabicSupport.ArabicFixer.Fix(Statec_Values.U_Name, ShowTashkeel, UseHinduNumbers); ;
        score.text =" " + ArabicSupport.ArabicFixer.Fix(Statec_Values.U_Total.ToString(), ShowTashkeel, true); ;

        StartCoroutine(GetData("1")); // +
        StartCoroutine(GetData("2")); // -
        StartCoroutine(GetData("3"));
        StartCoroutine(GetData("4"));
        StartCoroutine(GetData("5"));
    }

    // Update is called once per frame
    void Update()
    {

    }
    [System.Obsolete]
    IEnumerator GetData( string  GID)
    {
        WWWForm form = new WWWForm();
        form.AddField("Ch_ID", Statec_Values.U_ID.ToString());
        form.AddField("L_ID", GID); //game ID

        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/Get_Data.php", form))
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
                //  Debug.Log(responseText.StartsWith("true"));


                if (responseText.Contains("Success"))
                {

                    string[] dataChunks = responseText.Split('|');
                    if (GID == "1")
                    {
                        score1.text = " " + ArabicSupport.ArabicFixer.Fix(dataChunks[2], ShowTashkeel, true);
                    }
                    if (GID == "2")
                    {
                        score2.text = " " + ArabicSupport.ArabicFixer.Fix(dataChunks[2], ShowTashkeel, true);
                    }
                    if (GID == "3")
                    {
                        score3.text = " " + ArabicSupport.ArabicFixer.Fix(dataChunks[2], ShowTashkeel, true);
                    }
                    if (GID == "4")
                    {
                        score4.text = " " + ArabicSupport.ArabicFixer.Fix(dataChunks[2], ShowTashkeel, true);
                    }
                    if (GID == "5")
                    {
                        score5.text = " " + ArabicSupport.ArabicFixer.Fix(dataChunks[2], ShowTashkeel, true);
                    }

                }





            }


        }
    }
}
