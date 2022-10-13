using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilled : MonoBehaviour
{
    private void OnDestroy()
    {
        EnemyRange.enemyKilled++;
    }
}
