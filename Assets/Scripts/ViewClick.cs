using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewClick : MonoBehaviour
{
    [SerializeField] private GameObject gmView;
    private bool isViewing = false;

    public void ViewOn()
    {
        if(!isViewing) {
            gmView.SetActive(true);
            isViewing = true;
        }
    }

    public void ViewOff()
    {
        if(isViewing){
            gmView.SetActive(false);
            isViewing = false;
        }
    }
}