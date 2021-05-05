using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using ArabicSupport;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Security.Cryptography;
using Random = UnityEngine.Random;

public class Reset_pass : MonoBehaviour
{
    public InputField email1;
    public Button Check_Bt; // button check email
    public Button update_Bt; // button check code
    public Text Temp;
    public InputField code_txt;
    public InputField pass1;
    public InputField pass2;
    public GameObject Panel1;
    public GameObject Panel2; // تم استعاده كلمه المرور بنجاح
    public Button ButtonRegiser; // button update pass
    public GameObject E_Ok_Msg;
    public GameObject E_No_Msg;
    public GameObject Ch_Ok_Msg;
    public GameObject Ch_No_Msg;
    bool ShowTashkeel;
    bool UseHinduNumbers;

     private int R;




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
        Check_Bt.enabled = false;
        update_Bt.enabled = false;
        Panel1.SetActive(true);
        Panel2.SetActive(false);
    }


    public void callUpdate()
    {
        Temp.text = "";
        if (pass1.text == pass2.text)
        {
            StartCoroutine(Update_pass());
        }
        else
        {
            Temp.text = ArabicSupport.ArabicFixer.Fix("كلمة المرور الجديدة غير متطابقة", ShowTashkeel, UseHinduNumbers);
        }
    }
    public void Check_Click()
    {
        if (code_txt.text == R.ToString())
        {
            Ch_Ok_Msg.SetActive(true); // تم التحقق بنجاح
            update_Bt.enabled = true; // enabled update pass button
        }
        else
        {
            Ch_No_Msg.SetActive(true); // رمز التحقق غير صحيح

        }
    }

    public void on_click()
    {

        StartCoroutine(Check_Email());
    }

    [System.Obsolete]
    IEnumerator Check_Email()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", email1.text );
        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/Check_Email.php", form))
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
                Temp.text= " "; 


                if (responseText.Contains("Success"))
                {

                    try
                    {
                        R = Random.Range(234567, 987654);
                        // Sending email via GMail in C#/.NET using SmtpClient: https://ithoughthecamewithyou.com/post/sending-email-via-gmail-in-cnet-using-smtpclient
                        var smtpClient = new SmtpClient("smtp.gmail.com")
                        {
                            Port = 587,
                            Credentials = new NetworkCredential("raqmana20@gmail.com", "987654321#"),
                            EnableSsl = true,
                        };

                        smtpClient.Send("raqmana20@gmail.com", email1.text, "رمز استعادة كلمة المرور: ", R.ToString());
                        E_Ok_Msg.SetActive(true); // تم ارسال كلمه الرساله بنجاح
                        Check_Bt.enabled = true; // enabled check code button

                    }
                    catch
                    {
                        E_No_Msg.SetActive(true); // يوجد خطأ بالبريد الرجاء المحاوله مره اخرى

                    }
                }
                else
                {
                    Temp.text = ArabicSupport.ArabicFixer.Fix("هذا لايميل غير موجود", ShowTashkeel, UseHinduNumbers);
                }





            }


        }
    }


    // Update is called once per frame
    [System.Obsolete]
    IEnumerator Update_pass()
    {

        string p1 = CreateHash(pass1.text);

        WWWForm form = new WWWForm();

        form.AddField("email", email1.text);

        form.AddField("password", p1);
        form.AddField("password_confirm", p1);

        Temp.text = Statec_Values.U_ID.ToString();

        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/Reset_Pass.php", form))
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

        ButtonRegiser.interactable = (pass1.text.Length >= 8 && pass1.text == pass2.text);


    }
}
