using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using Random = UnityEngine.Random;

public class register : MonoBehaviour
{

    public InputField email1;
    public InputField userName;
    public InputField pass1;
    public InputField pass2;
    public Button ButtonRegiser;
    public Button Check_Bt;
    public GameObject E_Ok_Msg;
    public GameObject E_No_Msg;
    public GameObject Ch_Ok_Msg;
    public GameObject Ch_No_Msg;
    public Text Temp;
    public Text code_txt;
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

        // hash password using PBKDF2 https://stackoverflow.com/questions/4329909/hashing-passwords-with-md5-or-sha-256-c-sharp ,
        // https://stackoverflow.com/questions/13172185/should-i-store-password-with-salt-in-the-database-or-hashed-password-and-salt/13172766
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
        ButtonRegiser.enabled = false;

    }
     //virefy child email
    public void sendEmail()
    {


        try
        {
            //generate random number
            R = Random.Range(234567, 987654);
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("raqmana20@gmail.com", "987654321#"),
                EnableSsl = true,
            };

            smtpClient.Send("raqmana20@gmail.com", email1.text, ".اهلا بك في رقمنه ", "شكرا لتسجيلك في رقمنه هذا رمز التفعيل : " + R.ToString());
            E_Ok_Msg.SetActive(true); // "تم ارسال الرساله بنجاح"
            Check_Bt.enabled = true; //enable code button 
        }
        catch
        {

            E_No_Msg.SetActive(true); //"البريد الالكتروني غير صحيح"
        }
    }

    public void Check_Click()
    {
        if (code_txt.text == R.ToString())
        {
            Ch_Ok_Msg.SetActive(true); //"الرمز الذي ادخلته صحيح"
            ButtonRegiser.enabled = true; //enable register button
        }
        else
        {
            Ch_No_Msg.SetActive(true);
            //"الكود الذي ادخلته غير صحيح"

        }
    }

    public void callRegister()
    {
        Temp.text = " ";
        StartCoroutine(Register());

    }

    // Update is called once per frame
    [System.Obsolete]
    IEnumerator Register()
    {
        string p1= CreateHash(pass1.text);


        WWWForm form = new WWWForm();
        form.AddField("email", email1.text);
        form.AddField("username", userName.text);
        form.AddField("password", p1);
        Temp.text = " ";

        using (UnityWebRequest www = UnityWebRequest.Post("https://group3grp.000webhostapp.com/register.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Temp.text = " ";
                Debug.Log(www.error);
            }
            else
            {
                Temp.text = www.downloadHandler.text;
                Debug.Log(www.downloadHandler.text);
                Statec_Values.U_Name = userName.text;
                Statec_Values.U_Email = email1.text;
                Statec_Values.U_Total = 0;
                Statec_Values.U_ID = int.Parse(www.downloadHandler.text);
                Application.LoadLevel("home");
            }
        }



    }



    public void verifyInput(){

      ButtonRegiser.interactable=(userName.text.Length >= 5 && pass1.text.Length >= 8 && pass1.text == pass2.text);


    }
}
