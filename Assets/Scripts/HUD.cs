using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public BallController myBallController;
    public Text coinText;
    public Door myDoor;
    private void Update()
    {
        coinText.text = myBallController.coinsCollected.ToString();
        if (myDoor.coinsRequired <= myBallController.coinsCollected)
        {
            myDoor.myAnimator.SetTrigger("Open");
        }
    }
}
