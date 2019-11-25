using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestRecord : MonoBehaviour
{
    public Text bestRecordText;

    void Update()
    {
        bestRecordText.text = PlayerPrefs.GetInt("Score").ToString();
    }
}
