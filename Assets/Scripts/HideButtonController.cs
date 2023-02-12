using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideButtonController : MonoBehaviour
{
    public GameObject cover;
    public void OnHideButtonClick()
    {
        cover.SetActive(true);
    }
}
