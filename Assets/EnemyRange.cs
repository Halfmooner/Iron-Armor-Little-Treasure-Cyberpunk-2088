using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public static int enemyAmount = 5;
    public static int enemyKilled = 0;
    public static bool killedAll = false;
    public GameObject aimed;
    private void Update()
    {
        if (enemyKilled == enemyAmount)
        {
            killedAll = true;
            Destroy(aimed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
                enemyKilled++;
                if (enemyKilled >= enemyAmount)
                {
                    killedAll = true;
                }
            }
        }
    }
}
