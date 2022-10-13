using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public int enemyAmount = 4;
    public int enemyKilled = 0;
    public static bool killedAll = false;
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
