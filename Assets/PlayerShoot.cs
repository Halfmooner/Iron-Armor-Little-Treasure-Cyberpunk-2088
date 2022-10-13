using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public AudioClip[] audioclips;
    public bool isShooting;
    public ParticleSystem muzzleFlash;
    private Animator animator;
    private AudioSource audiosource;

    public GameObject fireRange;
    void Start()
    {
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        HandleShoot();
    }



    void HandleShoot()
    {
        if (isShooting)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            isShooting = true;
            animator.SetBool("isShooting", true);
            fireRange.SetActive(true);
            StartCoroutine(ResetShooting());
        }
    }

    IEnumerator ResetShooting()
    {
        audiosource.clip = audioclips[0];
        audiosource.Play();
        yield return new WaitForSeconds(0.08f);
        muzzleFlash.Play();
        yield return new WaitForSeconds(0.5f);
        fireRange.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isShooting", false);
        isShooting = false;

    }
        
        
}
