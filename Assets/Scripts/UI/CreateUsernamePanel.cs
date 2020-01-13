using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateUsernamePanel : MonoBehaviour
{
    [SerializeField] Animator popupAnimator;
    [SerializeField] InputField nameInputField;
    [SerializeField] Button okButton;

    //Action closeAction;

    public void OnClickOKButtion()
    {
        //서버에 ID 요청하기
        string username = nameInputField.text;

        if (username != "")
        {
            okButton.enabled = false;
            nameInputField.interactable = false;
            
            /*
            Network.Instance.GetServerID(username, () =>
            {
                Close();
            },
            () =>
            {
                okButton.interactable = true;
                nameInputField.interactable = true;
                nameInputField.text = "";
            });
            */

            Debug.Log($"Username '{username}' Registered");
        }
    }
}
