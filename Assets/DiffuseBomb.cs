using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DiffuseBomb : MonoBehaviour
{
    public GameObject Success;
    public GameObject Fail;

    public static bool inArea = false;
    public float needTime = 5f;
    public float timer = 0f;
    public bool diffused;
    public Image progressBar;
    public GameObject progressBarBack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        Diffuse();
    }

    void Diffuse()
    {
        if (!inArea)
        {
            return;
        }
        progressBar.fillAmount = timer / needTime;
        if (Input.GetKey(KeyCode.E))
        {
            progressBarBack.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= 3.5f)
            {
                if (!EnemyRange.killedAll)
                {
                    progressBarBack.SetActive(false);
                    progressBar.fillAmount = 0;
                    timer = 0f;
                    Fail.SetActive(true);
                    StartCoroutine(Restart());
                }

            }


            if (timer >= needTime)
            {
                progressBarBack.SetActive(false);
                progressBar.fillAmount = 0;
                timer = 0f;
                diffused = true;
                Success.SetActive(true);
                StartCoroutine(Restart());

            }
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            progressBarBack.SetActive(false);
            if (!diffused)
            {
                timer = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other!=null)
        {
            if (other.CompareTag("BombArea"))
            {
                Debug.Log("Enter Bomb Area");
                inArea = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other != null)
        {
            if (other.CompareTag("BombArea"))
            {
                Debug.Log("Left Bomb Area");
                inArea = false;
                progressBarBack.SetActive(false);
                progressBar.fillAmount = 0;
                timer = 0f;
            }
        }
    }

    IEnumerator Restart()
    {
        yield return new WaitForSeconds(3f);
        Application.Quit();
    }
}
