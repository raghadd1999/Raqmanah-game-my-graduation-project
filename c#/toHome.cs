using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;


public class toHome : MonoBehaviour
{
  // to suppot arabic interface we use this script : https://github.com/Konash/arabic-support-unity
    public void toHomePage() {




        Application.LoadLevel("home");
    }


    public void toProfilePage()
    {



        Application.LoadLevel("profile");
    }
    public void toGames()
    {



        Application.LoadLevel("games");
    }

    public void toInstruction()
    {



        Application.LoadLevel("instructions1");

    }
    public void toLeaderBoard()
    {



        Application.LoadLevel("leaderBoard1");
    }
    public void toLevels()
    {



        Application.LoadLevel("levels");
    }

    public void toScanCards()
    {



        Application.LoadLevel("scanCards");
    }

    public void toLogin()
    {

        Application.LoadLevel("logIn1");
    }


    public void toRegister()
    {

        Application.LoadLevel("register");
    }

    public void toEditProfile() {

        Application.LoadLevel("EditProfile");
    }
    public void toSampleScene()
    {

        Application.LoadLevel("SampleScene");
    }
    public void toReset_Pass()
    {

        Application.LoadLevel("Reset_Pass");
    }
}
