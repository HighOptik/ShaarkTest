using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerFollow : MonoBehaviour
{
    public Transform target;
    public float followSpeed;
    public Vector3 offset;
    void Update()
    {
        if (!CanvasManager.instance.gameOver)
        {
            transform.DOMove(target.position + offset, followSpeed);
        }
    }
}
