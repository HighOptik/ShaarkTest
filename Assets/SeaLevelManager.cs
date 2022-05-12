using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SeaLevelManager : MonoBehaviour
{
    public Transform target;
    public float followSpeed;
    void Update()
    {
        transform.DOMove(new Vector3(target.position.x,0,0),followSpeed);
    }
}
