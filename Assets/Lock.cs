using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock : MonoBehaviour
{
    bool locked;
    public GameObject crosshair;
    public Camera myCamera;
    Transform target;

    List<GameObject> enemiesInGame = new List<GameObject>();
    List<GameObject> enemiesOnScreen = new List<GameObject>();
    void Start()
    {
        crosshair.SetActive(false);
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject e in allEnemies)
        {
            enemiesInGame.Add(e);
        }
    }
    void Update()
    {
        if (enemiesInGame.Count > 0)
        {
            for (int i = 0; i < enemiesInGame.Count; i++)
            {
                Vector3 enemyPos = myCamera.WorldToViewportPoint(enemiesInGame[i].transform.position);
                if(enemyPos.z > 0 && enemyPos.x >0 && enemyPos.x<1 && enemyPos.y>0 && enemyPos.y < 1 && !enemiesOnScreen.Contains(enemiesInGame[i]))
                {
                    enemiesOnScreen.Add(enemiesInGame[i]);
                }
                else if (enemiesOnScreen.Contains(enemiesInGame[i]))
                {
                    enemiesOnScreen.Remove(enemiesInGame[i]);
                }
            }
        }
        target = enemiesOnScreen[0].transform;
        crosshair.transform.position = myCamera.WorldToScreenPoint(target.position);
    }
}
