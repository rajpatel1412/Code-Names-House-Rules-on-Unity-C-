using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowButtonController : MonoBehaviour
{
    public GameObject cover;
    public void OnShowButtonClick()
    {
        cover.SetActive(false);
    }
    
}
