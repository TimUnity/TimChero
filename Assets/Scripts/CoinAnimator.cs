using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CoinAnimator : MonoBehaviour
{
    private void Start()
    {
        DOTween.SetTweensCapacity(500,50);
        gameObject.transform.DOLocalRotate(new Vector3(0f, 180f, 0f),  5f, RotateMode.Fast);
    }

    void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
