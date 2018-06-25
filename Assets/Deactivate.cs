using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    private WaitForSeconds _Timer;

    void Start () {
        _Timer = new WaitForSeconds(1.5f);
    }

    public void DeactivateEffect()
    {
        StartCoroutine(DestroyGameObject());
    }

    private IEnumerator DestroyGameObject()
    {
        yield return _Timer;

        Destroy(gameObject);
    }
}
