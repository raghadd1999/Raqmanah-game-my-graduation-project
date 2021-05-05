using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ArabicSupport;

public struct Question//our data sturcture
{
    public string Q_T;
    public string A1;
    public string A2;
    public string A3;
    public string R_A;
    public int Q_level;
    public int Q_Game;

};



public class Statec_Values : MonoBehaviour
{

    public static int U_ID;
    public static int U_Total;
    public static string U_Name;
    public static string U_Email;
    public static string selected_Game_NAME;
    public static string selected_Game_NAME_EN;
    public static string selected_Game_ID;
    public static string selected_Level_ID;
    public static string selected_Level_Score;


    public static Question Ques( string a ) // Question display function , The Check_Questions(cs) sends the 3D object for display question
    {
      Question Q = new Question();//all qustions and thier possable anwsers and there are 45 qustions


        switch (a)
        {
            case "ADD1-1":
            {

               Q.A1 = "2";
               Q.A2 = "1";
               Q.A3 = "0";
               Q.R_A = "2";
               Q.Q_Game = 1; // الجمع
               Q.Q_level = 1; // المستوى الاول
            }
                break;
            case "ADD1-2":
            {

                Q.A1 = "1";
                Q.A2 = "3";
                Q.A3 = "2";
                Q.R_A = "3";
                Q.Q_Game = 1; // الجمع
                Q.Q_level = 1; // المستوى الاول
            }

                break;
            case "ADD1-3":
            {

                Q.A1 = "1";
                Q.A2 = "0";
                Q.A3 = "3";
                Q.R_A = "3";
                Q.Q_Game = 1;
                Q.Q_level = 1;
            }
                break;
            case "ADD2-1":
            {

                Q.A1 = "5";
                Q.A2 = "6";
                Q.A3 = "4";
                Q.R_A = "6";
                Q.Q_Game = 1; // الجمع
                Q.Q_level = 2; // المستوى الثاني
            }
                break;
            case "ADD2-2":
            {

                Q.A1 = "4";
                Q.A2 = "6";
                Q.A3 = "5";
                Q.R_A = "4";
                Q.Q_Game = 1;
                Q.Q_level = 2;
            }

                break;
            case "ADD2-3":
            {

                Q.A1 = "6";
                Q.A2 = "4";
                Q.A3 = "5";
                Q.R_A = "5";
                Q.Q_Game = 1;
                Q.Q_level = 2;
            }
                break;
            case "ADD3-1":
            {

                Q.A1 = "11";
                Q.A2 = "7";
                Q.A3 = "10";
                Q.R_A = "11";
                Q.Q_Game = 1;
                Q.Q_level = 3;
            }
                break;
            case "ADD3-2":
            {

                Q.A1 = "10";
                Q.A2 = "12";
                Q.A3 = "9";
                Q.R_A = "12";
                Q.Q_Game = 1;
                Q.Q_level = 3;
            }

                break;
            case "ADD3-3":
            {

                Q.A1 = "7";
                Q.A2 = "11";
                Q.A3 = "8";
                Q.R_A = "8";
                Q.Q_Game = 1;
                Q.Q_level = 3;
            }
                break;
            case "SUB1-1":
            {

                Q.A1 = "0";
                Q.A2 = "1";
                Q.A3 = "2";
                Q.R_A = "0";
                Q.Q_Game = 2;
                Q.Q_level = 1;
            }
                break;

            case "SUB1-2":
            {

                Q.A1 = "1";
                Q.A2 = "2";
                Q.A3 = "4";
                Q.R_A = "4";
                Q.Q_Game = 2;
                Q.Q_level = 1;
            }
                break;
            case "SUB1-3":
            {

                Q.A1 = "1";
                Q.A2 = "2";
                Q.A3 = "3";
                Q.R_A = "2";
                Q.Q_Game = 2;
                Q.Q_level = 1;
            }
                break;
            case "SUB2-1":
            {

                Q.A1 = "2";
                Q.A2 = "9";
                Q.A3 = "3";
                Q.R_A = "3";
                Q.Q_Game = 2;
                Q.Q_level = 2;
            }
                break;

            case "SUB2-2":
            {

                Q.A1 = "1";
                Q.A2 = "6";
                Q.A3 = "5";
                Q.R_A = "6";
                Q.Q_Game = 2;
                Q.Q_level = 2;
            }
                break;
            case "SUB2-3":
            {

                Q.A1 = "8";
                Q.A2 = "0";
                Q.A3 = "4";
                Q.R_A = "8";
                Q.Q_Game = 2;
                Q.Q_level = 2;
            }
                break;
            case "SUB3-1":
            {

                Q.A1 = "2";
                Q.A2 = "5";
                Q.A3 = "3";
                Q.R_A = "5";
                Q.Q_Game = 2;
                Q.Q_level = 3;
            }
                break;

            case "SUB3-2":
            {

                Q.A1 = "1";
                Q.A2 = "6";
                Q.A3 = "7";
                Q.R_A = "7";
                Q.Q_Game = 2;
                Q.Q_level = 3;
            }
                break;
            case "SUB3-3":
            {

                Q.A1 = "6";
                Q.A2 = "0";
                Q.A3 = "4";
                Q.R_A = "6";
                Q.Q_Game = 2;
                Q.Q_level = 3;
            }
                break;
            case "GUM1-1":
            {
                Q.Q_T = "اختر اسم هذا المجسم ";
                Q.A1 = "مكعب";
                Q.A2 = "كرة";
                Q.A3 = "مخروط";
                Q.R_A = "مكعب";
                Q.Q_Game = 3;
                Q.Q_level = 1;
            }
                break;

            case "GUM1-2":
            {
                Q.Q_T = "اختر اسم هذا المجسم ";
                Q.A1 = "مكعب";
                Q.A2 = "كرة";
                Q.A3 = "مخروط";
                Q.R_A = "كرة";
                Q.Q_Game = 3;
                Q.Q_level = 1;
            }
                break;
            case "GUM1-3":
            {
                Q.Q_T = "اختر اسم هذا المجسم ";
                Q.A1 = "مكعب";
                Q.A2 = "كرة";
                Q.A3 = "مخروط";
                Q.R_A = "مخروط";
                Q.Q_Game = 3;
                Q.Q_level = 1;
            }
                break;
            case "GUM2-1":
            {
                Q.Q_T = "هذا المجسم  ";
                    Q.A1 = "يتدحرج";
                Q.A2 = "ينزلق";
                Q.A3 = "يتراص";
                Q.R_A = "يتراص";
                Q.Q_Game = 3;
                Q.Q_level = 2;
            }
                break;

            case "GUM2-2":
            {

                Q.Q_T = "هذا المجسم  ";
                Q.A1 = "يتدحرج";
                Q.A2 = "ينزلق";
                Q.A3 = "يتراص";
                    Q.R_A = "ينزلق";
                Q.Q_Game = 3;
                Q.Q_level = 2;
            }
                break;
            case "GUM2-3":
            {

                Q.Q_T = "هذا المجسم  ";
                Q.A1 = "يتدحرج";
                Q.A2 = "ينزلق";
                Q.A3 = "يتراص";
                    Q.R_A = "يتدحرج";
                Q.Q_Game = 3;
                Q.Q_level = 2;
            }
                break;
            case "GUM3-1":
            {
                Q.Q_T = "اختر عدد الأضلاع و الرؤوس للشكل المستوي  ";
                    Q.A1 = "٣ أضلاع و ٣ رؤوس";
                Q.A2 = "٤ أضلاع ٤ رؤوس";
                Q.A3 = "٠ أضلاع ٠ رؤوس";
                Q.R_A = "٤ أضلاع ٤ رؤوس";
                Q.Q_Game = 3;
                Q.Q_level = 3;
            }
                break;

            case "GUM3-2":
            {

                Q.Q_T = "اختر عدد الأضلاع و الرؤوس للشكل المستوي  ";
                Q.A1 = "٣ أضلاع و ٣ رؤوس";
                Q.A2 = "٤ أضلاع ٤ رؤوس";
                Q.A3 = "٠ أضلاع ٠ رؤوس";
                    Q.R_A = "٠ أضلاع ٠ رؤوس";
                Q.Q_Game = 3;
                Q.Q_level = 3;
            }
                break;
            case "GUM3-3":
            {

                Q.Q_T = "اختر عدد الأضلاع و الرؤوس للشكل المستوي  ";
                Q.A1 = "٣ أضلاع و ٣ رؤوس";
                Q.A2 = "٤ أضلاع ٤ رؤوس";
                Q.A3 = "٠ أضلاع ٠ رؤوس";
                    Q.R_A = "٣ أضلاع و ٣ رؤوس";
                Q.Q_Game = 3;
                Q.Q_level = 3;
            }
                break;
            case "CMP1-1":
                {
                    Q.Q_T = "١ ؟ ١ ";
                    Q.A1 = "١>١";
                    Q.A2 = "١<١";
                    Q.A3 = "١=١";
                    Q.R_A = "١=١";
                    Q.Q_Game = 4;
                    Q.Q_level = 1;
                }
                break;

            case "CMP1-2":
                {
                    Q.Q_T = "٦؟٤ ";
                    Q.A1 = "٦>٤";
                    Q.A2 = "٦<٤";
                    Q.A3 = "٦=٤";
                    Q.R_A = "٦>٤";
                    Q.Q_Game = 4;
                    Q.Q_level = 1;
                }
                break;
            case "CMP1-3":
                {
                    Q.Q_T = "٥ ؟ ٩ ";
                    Q.A1 = "٥>٩";
                    Q.A2 = "٥<٩";
                    Q.A3 = "٥=٩";
                    Q.R_A = "٥<٩";
                    Q.Q_Game = 4;
                    Q.Q_level = 1;
                }
                break;
            case "CMP2-1":
                {
                    Q.Q_T = "١٧؟١٢ ";
                    Q.A1 = "١٧=١٢";
                    Q.A2 = "١٧<١٢";
                    Q.A3 = "١٧>١٢";
                    Q.R_A = "١٧>١٢";
                    Q.Q_Game =4;
                    Q.Q_level = 2;
                }
                break;

            case "CMP2-2":
                {

                    Q.Q_T = "٢٠؟٢٨ ";
                    Q.A1 = "٢٠>٢٨";
                    Q.A2 = "٢٠<٢٨";
                    Q.A3 = "٢٠=٢٨";
                    Q.R_A = "٢٠<٢٨";
                    Q.Q_Game = 4;
                    Q.Q_level = 2;
                }
                break;
            case "CMP2-3":
                {

                    Q.Q_T = "٤٠؟٣٢ ";
                    Q.A1 = "٤٠>٣٢";
                    Q.A2 = "٤٠<٣٢";
                    Q.A3 = "٤٠=٣٢";
                    Q.R_A = "٤٠>٣٢";
                    Q.Q_Game = 4;
                    Q.Q_level = 2;
                }
                break;
            case "CMP3-1":
                {
                    Q.Q_T = "٥٤؟٥١  ";
                    Q.A1 = "٥٤>٥١";
                    Q.A2 = "٥٤<٥١";
                    Q.A3 = "٥٤=٥١";
                    Q.R_A = "٥٤>٥١";
                    Q.Q_Game = 4;
                    Q.Q_level = 3;
                }
                break;

            case "CMP3-2":
                {

                    Q.Q_T = "٦٣؟٧٧  ";
                    Q.A1 = "٦٣=٧٧";
                    Q.A2 = "٦٣>٧٧";
                    Q.A3 = "٦٣<٧٧";
                    Q.R_A = "٦٣<٧٧";
                    Q.Q_Game = 4;
                    Q.Q_level = 3;
                }
                break;
            case "CMP3-3":
                {

                    Q.Q_T = "٤٠؟٣٢  ";
                    Q.A1 = "٤٠>٣٢";
                    Q.A2 = "٤٠<٣٢";
                    Q.A3 = "٤٠=٣٢";
                    Q.R_A = "٤٠>٣٢";
                    Q.Q_Game = 4;
                    Q.Q_level = 3;
                }
                break;
            case "ORD1-1":
                {
                    Q.Q_T = "العدد الذي يسبق ٢٨ ";
                    Q.A1 = "٢٥";
                    Q.A2 = "٢٧";
                    Q.A3 = "٢٦";
                    Q.R_A = "٢٧";
                    Q.Q_Game =5;
                    Q.Q_level = 1;
                }
                break;

            case "ORD1-2":
                {
                    Q.Q_T = "العدد الذي يلي ٣٣ ؟ ";
                    Q.A1 = "٣٥";
                    Q.A2 = "٣٠";
                    Q.A3 = "٣٤";
                    Q.R_A = "٣٤";
                    Q.Q_Game = 5;
                    Q.Q_level = 1;
                }
                break;
            case "ORD1-3":
                {
                    Q.Q_T = "العدد الواقع بين العددين ٢٣ ، ... ، ٢١  ";
                    Q.A1 = "٢٢";
                    Q.A2 = "٢٤";
                    Q.A3 = "١٩";
                    Q.R_A = "٢٢";
                    Q.Q_Game = 5;
                    Q.Q_level = 1;
                }
                break;
            case "ORD2-1":
                {
                    Q.Q_T = "العدد الذي يسبق ٤٥ ؟";
                    Q.A1 = "٤٦";
                    Q.A2 = "٤٧";
                    Q.A3 = "٤٤";
                    Q.R_A = "٤٤";
                    Q.Q_Game = 5;
                    Q.Q_level = 2;
                }
                break;

            case "ORD2-2":
                {

                    Q.Q_T = "العدد الذي يلي ٥٧ ؟";
                    Q.A1 = "٥٨";
                    Q.A2 = "٥٥";
                    Q.A3 = "٥٦";
                    Q.R_A = "٥٨";
                    Q.Q_Game = 5;
                    Q.Q_level = 2;
                }
                break;
            case "ORD2-3":
                {

                    Q.Q_T = "العدد الواقع بين العددين ٦٢ ، ... ، ٦٠";
                    Q.A1 = "٦٤";
                    Q.A2 = "٦١";
                    Q.A3 = "٦٣";
                    Q.R_A = "٦١";
                    Q.Q_Game = 5;
                    Q.Q_level = 2;
                }
                break;
            case "ORD3-1":
                {
                    Q.Q_T = "العدد الذي يسبق ٧٩ ؟";
                    Q.A1 = "٧٦";
                    Q.A2 = "٧٨";
                    Q.A3 = "٧٧";
                    Q.R_A = "٧٨";
                    Q.Q_Game = 5;
                    Q.Q_level = 3;
                }
                break;

            case "ORD3-2":
            {

                Q.Q_T = "العدد الذي يلي ٨٣ ؟ ";
                    Q.A1 = "٨٥";
                    Q.A2 = "٨١";
                    Q.A3 = "٨٤";
                    Q.R_A = "٨٤";
                    Q.Q_Game = 5;
                    Q.Q_level = 3;
                }
                break;
            case "ORD3-3":
                {

                    Q.Q_T = "العدد الواقع بين العددين ٩٤ ، ... ، ٩٢ ";
                    Q.A1 = "٩٣";
                    Q.A2 = "٩٠";
                    Q.A3 = "٩١";
                    Q.R_A = "٩٣";
                    Q.Q_Game = 5;
                    Q.Q_level = 3;
                }
                break;

            default:

                break;
        }
        return Q;
    }
}
