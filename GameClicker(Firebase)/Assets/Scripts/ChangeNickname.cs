using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeNickname : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameText;
    [SerializeField] private UserData userData;

    public void ChangeName()
    {
        userData.ChangeNickname(nicknameText.text);
    }


}
