using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using ArabicSupport;

public class Get_Ch_Order : MonoBehaviour
{
    public Text  Name_txt;//chaild name 
   // public InputField temp;
    public Text  scor_txt;//chaild ID
    // Start is called before the first frame get_order()
    void Start()// firstly it will execute  the code in get_order() 
    {
        StartCoroutine(get_order());// get_order() is called once per frame
    }

    

  
    [System.Obsolete]
    IEnumerator get_order()//the method that calculate the childern score
    {
        WWWForm form = new WWWForm();//empty form to execute the php script
        //call Get_Child_order method in the php code to  retrieve from the child table the top 10 children ordered descending by their scores.

        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/Get_Child_order.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)//if there is an error in the connection
            {

                Debug.Log(www.error);// show the error
            }
            else
            {
                //display the retreived usernams and scores 
                //scor_txt.text = ;
                string Res = www.downloadHandler.text;
                string[] dataChunks = Res.Split('|');
                for (int i = 2; i < 20; i += 2)
                {
                    try
                    {
                        scor_txt.text += "  " + ArabicFixer.Fix(dataChunks[i].ToString(), false, true)+" " + Environment.NewLine;

                    }
                    catch
                    { }

                }
                for (int i = 1; i < 20; i += 2)
                {
                    try
                    {
                        if (dataChunks[i].ToString() != "")
                        {
                            Name_txt.text +=  " : " + ArabicFixer.Fix(dataChunks[i].ToString(), false, true) + Environment.NewLine;

                        }
                    }
                    catch
                    { }






                }


            }
        }

    }
}
