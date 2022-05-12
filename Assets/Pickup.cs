using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject effect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"));
        {
            GameObject fx = GameObject.Instantiate(effect);
            fx.transform.position = transform.position;
            CanvasManager.instance.Hunger(75);
            CanvasManager.instance.AddPoints(75);
            Destroy(gameObject);
        }
    }

}
