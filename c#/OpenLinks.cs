using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinks : MonoBehaviour
{
    // open goodle drive to downloda the cards
    public void GoogleDrive()
    {
        Application.OpenURL ("https://drive.google.com/file/d/1v4GVtxRNJQ7xJeE1RWE8fjSCaFsrdjT6/view");
    }
    // open youtube
    public void Youtube()
    {
        Application.OpenURL ("https://youtu.be/_QuaEyX1L-o");
    }

}
