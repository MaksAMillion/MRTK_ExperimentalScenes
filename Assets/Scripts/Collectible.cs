using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float timer;
    public WaitForSeconds effectTimer;

    public ParticleSystem _ParticleSystem;

    private Animator _AnimatorController;

    private void Awake()
    {
        effectTimer = new WaitForSeconds(timer);
        _ParticleSystem.transform.position = gameObject.transform.position;

        _AnimatorController = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject collectible = other.gameObject;

        if (collectible.tag == "IndexFinger")
        {
            if (gameObject.name == "SciFiGun")
            {
                StartCoroutine(Effect());
            }
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Destroyed gun or picked up");
    }

    private IEnumerator Effect()
    {
        _ParticleSystem.Play();

        _AnimatorController.SetTrigger("Collected");
        Debug.Log("Effect Started");
        yield return effectTimer;

        Debug.Log("Effect Finished");
        _ParticleSystem.gameObject.GetComponent<Deactivate>().DeactivateEffect();
        Destroy(gameObject);
    }
}