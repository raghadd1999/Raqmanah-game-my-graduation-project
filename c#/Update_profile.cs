using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Update_profile : MonoBehaviour
{
    public InputField email1;
    public InputField userName;
    public InputField pass1;
    public InputField pass2;
    public Button ButtonRegiser;
    public GameObject  Panel1;
    public GameObject  Panel2;
    public Text Temp;



    public const int SALT_BYTE_SIZE = 24;
    public const int HASH_BYTE_SIZE = 24;
    public const int PBKDF2_ITERATIONS = 1000;



    public static string CreateHash(string password)
    {
        // Generate a random salt
        RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
        byte[] salt = new byte[SALT_BYTE_SIZE];
        csprng.GetBytes(salt);

        // Hash the password and encode the parameters
        byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
        return PBKDF2_ITERATIONS + ":" +
               Convert.ToBase64String(salt) + ":" +
               Convert.ToBase64String(hash);
    }
    private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
    {
        Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
        pbkdf2.IterationCount = iterations;
        return pbkdf2.GetBytes(outputBytes);
    }




    // Start is called before the first frame update
    void Start()
    {
        Panel1.SetActive(true);
        Panel2.SetActive(false);
        email1.text = Statec_Values.U_Email;
        userName.text = Statec_Values.U_Name;

    }

    public void callUpdate()
    {
        Temp.text = "";
        if (pass1.text == pass2.text)
        {
            StartCoroutine(Update_pro());
        }
        else
        {
            Temp.text = ArabicSupport.ArabicFixer.Fix("كلمة المرور الجديدة غير متطابقة", false , true );
        }


    }

    // Update is called once per frame
    [System.Obsolete]
    IEnumerator Update_pro()
    {
        string p1 = CreateHash(pass1.text);
        WWWForm form = new WWWForm();
        form.AddField("Ch_ID", Statec_Values.U_ID.ToString());
        form.AddField("email", email1.text);
        form.AddField("username", userName.text);
        form.AddField("password", p1);
        form.AddField("password_confirm", p1);


        Temp.text = Statec_Values.U_ID.ToString();

        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/Update_Profile_Data.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Temp.text = "Network_Erorr";
                Debug.Log(www.error);
            }
            else
            {
                if (www.downloadHandler.text.Contains("Success"))
                {
                    Panel1.SetActive(false);
                    Panel2.SetActive(true); 
                    Debug.Log(www.downloadHandler.text);

                }
                else
                {
                    Temp.text = www.downloadHandler.text;
                }


            }
        }

    }



    public void verifyInput()
    {

        ButtonRegiser.interactable = (userName.text.Length >= 5 && pass1.text.Length >= 8 && pass1.text == pass2.text);


    }
}
