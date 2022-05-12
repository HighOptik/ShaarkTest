using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    float foodTimer;
    public GameObject food;

    private void Update()
    {
        foodTimer += 1 * Time.deltaTime;
        if (foodTimer >= 5)
        {
            foodTimer = 0;
            StartCoroutine(SpawnFood());
        }
    }
    IEnumerator SpawnFood()
    {
        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            yield return new WaitForSeconds(1);
            GameObject foodobj = GameObject.Instantiate(food);
            foodobj.transform.position = CanvasManager.instance.player.transform.position + new Vector3(Random.Range(-10, 10), 10, 0);
        }
    }
}