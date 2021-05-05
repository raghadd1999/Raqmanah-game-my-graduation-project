using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Click : MonoBehaviour
{

    // Start is called before the first frame update
    public void on_Click( string  L_ID)
    {
        Statec_Values.selected_Level_ID = L_ID;
    }
}
