using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public TextMeshProUGUI left;
    public TextMeshProUGUI right;
    private void FixedUpdate()
    {
        left.text = PartyManager.Instance.scoreLeft.ToString();
        right.text = PartyManager.Instance.scoreRight.ToString();
    }
}

