using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingImage : MonoBehaviour
{
    public Sprite spriteToUse;
    public Image imgToChange;

    public void ChangeImg() 
    {
        imgToChange.GetComponent<Image>().sprite = spriteToUse;
    }

}
