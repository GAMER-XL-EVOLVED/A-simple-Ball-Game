using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public BallController myBallController;
    public Text coinText;

    private void Update()
    {
        coinText.text = myBallController.coinsCollected.ToString();
    }
}
