using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HungerManager : MonoBehaviour
{
    public float hungerCost;
    void Update()
    {
        if (!CanvasManager.instance.gameOver)
        {
            GetComponent<CanvasManager>().Hunger(-hungerCost);
        }
    }
}