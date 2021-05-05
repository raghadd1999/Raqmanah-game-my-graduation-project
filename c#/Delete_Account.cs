using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Delete_Account : MonoBehaviour
{
    
    public void calldelete()
    {

        StartCoroutine(Login1());

    }

    [System.Obsolete]
    IEnumerator Login1()
    {

        WWWForm form = new WWWForm();
        form.AddField("Ch_ID", Statec_Values.U_ID.ToString());
        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/Delete.php", form))
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

                    Application.LoadLevel("logIn1");

                }
                else
                {


                }




            }


        }
    }
}
