using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Game_Click : MonoBehaviour
{
    // Start is called before the first frame update
    public  Text L_ID;
    public  Text L_Name;
    public  Text L_Name_EN;
    public  Text error;
    public  Text error1;
    public  Text error2;


    public void on_Click()
    {
        // when the child select game, we store the game info here, Game ID,Game Nam, and Game name in english.
        Statec_Values.selected_Game_ID = L_ID.text;
        Statec_Values.selected_Game_NAME  = L_Name.text;
        Statec_Values.selected_Game_NAME_EN = L_Name_EN.text;

        // call GetData to bring child ID, and Level.
        StartCoroutine(GetData());
    }
    // Update is called once per frame
    [System.Obsolete]
    IEnumerator GetData()
    {
        WWWForm form = new WWWForm();
        form.AddField("Ch_ID", Statec_Values.U_ID.ToString());
        form.AddField("L_ID", Statec_Values.selected_Game_ID );
        error1.text = Statec_Values.U_ID.ToString(); // to show X
        error2.text = Statec_Values.selected_Level_ID; // to show X
        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/Get_Data.php", form))
        {
            yield return www.SendWebRequest();
            error.text = www.downloadHandler.text;

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                error.text = www.downloadHandler.text;
            }
            else
            {
                string responseText = www.downloadHandler.text;
                Debug.Log(responseText);
                //  Debug.Log(responseText.StartsWith("true"));
                error.text = www.downloadHandler.text;

                if (responseText.Contains("Success"))
                {

                    string[] dataChunks = responseText.Split('|');
                    Statec_Values.selected_Level_Score = dataChunks[2]; //bring child score in the current game from DB bevore child enter level page
                    error1.text = Statec_Values.selected_Level_Score;
                    Application.LoadLevel("levels");
                }





            }


        }
    }
}
