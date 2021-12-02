using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteText : MonoBehaviour
{
    [SerializeField]
    private InputField ipf;

    public void onClick()
    {
        ipf.text = "";
    }
}
