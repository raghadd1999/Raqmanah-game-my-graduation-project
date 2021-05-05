using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class login : MonoBehaviour
{
    public InputField email;
    public InputField password;
    public Button ButtonLogin;
    public Text error;


    bool isLoggedIn = false;

    //Logged-in user data
    string userName = "";
    string userEmail = "";
    int U_ID;

     // hash password using PBKDF2 https://stackoverflow.com/questions/4329909/hashing-passwords-with-md5-or-sha-256-c-sharp ,
     // https://stackoverflow.com/questions/13172185/should-i-store-password-with-salt-in-the-database-or-hashed-password-and-salt/13172766
     public const int ITERATION_INDEX = 0;
     public const int SALT_INDEX = 1;
     public const int PBKDF2_INDEX = 2;
    private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
     {
         // added salt to each password instance before its hashing.
         Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
         pbkdf2.IterationCount = iterations;
         return pbkdf2.GetBytes(outputBytes);
     }
     private static bool SlowEquals(byte[] a, byte[] b)
     {
         uint diff = (uint)a.Length ^ (uint)b.Length;
         for (int i = 0; i < a.Length && i < b.Length; i++)
             diff |= (uint)(a[i] ^ b[i]);
         return diff == 0;
     }
     // Validates a password given a hash of the correct one
     public static bool ValidatePassword(string password, string correctHash)
     {
         // Extract the parameters from the hash
         char[] delimiter = { ':' };
         string[] split = correctHash.Split(delimiter);
         int iterations = Int32.Parse(split[ITERATION_INDEX]);
         byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
         byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

         byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
         return SlowEquals(hash, testHash);
     }


    // Start is called before the first frame update
    public void callLogin()
    {

        StartCoroutine(Login1());

    }

    [System.Obsolete]
    IEnumerator Login1()
    {

        WWWForm form = new WWWForm();
        form.AddField("User", email.text);
        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/login1.php", form))
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

                if (responseText.Contains("wrong"))
                {
                    // البريد الالكتروني غير صحيح
                    error.text = "ﺢﻴﺤﺻ ﺮﻴﻏ ﻲﻧﻭﺮﺘﻜﻟﻻﺍ ﺪﻳﺮﺒﻟﺍ";
                }

                else
                {
                  if (ValidatePassword(password.text, responseText))
                  {

                      StartCoroutine(Login());

                  }
                  else
                  {
                      // كلمه المرور غير صحيحه
                      error.text = "ﻪﺤﻴﺤﺻ ﺮﻴﻏ رﻭﺮﻤﻟﺍ ﺔﻤﻠﻛ";

                  }





                }




            }


        }
    }
    [System.Obsolete]
    IEnumerator Login()
    {

        WWWForm form = new WWWForm();
        form.AddField("User", email.text);


        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/login.php", form))
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
                error.text = responseText;



                if (responseText.Contains("Success"))
                {

                    error.text = "Login Success with email: " + email.text;

                    //store user info
                    string[] dataChunks = responseText.Split('|');
                    userName = dataChunks[1];
                    Statec_Values.U_Name = userName;
                    userEmail = dataChunks[2];
                    Statec_Values.U_Email= userEmail;
                    U_ID = int.Parse(dataChunks[3]);
                    Statec_Values.U_ID= U_ID;
                    Statec_Values.U_Total = int.Parse(dataChunks[4]); // child score
                    isLoggedIn = true;

                    Application.LoadLevel("home");

                }
                else
                {
                   //يوجد خطأ بالبريد الالكتروني او كلمه المرور
                    error.text = " رﻭﺮﻤﻟﺍ ﺔﻤﻠﻛ وﺍ ﻲﻧﻭﺮﺘﻛﻻﺍ ﺪﻳﺮﺒﻟﺍ ﻲﻓ ﺎﻄﺧ ﺪﺟﻮﻳ ";

                }




            }


        }
    }
}
