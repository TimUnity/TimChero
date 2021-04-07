using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{ 
    //����� ���������� �� ���������� ���� � ������

    [SerializeField] float healthLimit = 100f; 

    private void ReduceHeath(float reduceValue)
    {
        if (healthLimit >= reduceValue)
        {
            healthLimit -= reduceValue;
        }
        else
        {
            healthLimit = 0;
        }

        if (healthLimit <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void IncreaseHeath(float increaseValue)
    { 
        healthLimit += increaseValue; 
    }

    private void OnTriggerEnter(Collider other)
    {
        //��� ������������ �� ���������
        if (other.transform.CompareTag("PROJECTILE") && 
            gameObject.transform.tag.Contains(other.GetComponent<ProjectileControl>().GetTargetTag()))
        {
            var hitPower = other.GetComponent<ProjectileControl>().GetHitPower();
            ReduceHeath(hitPower); 
        }  


        //��� ������������ � ��������
        if (other.transform.CompareTag("COIN"))
        {
            IncreaseHeath(25);
            Destroy(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collider)
    {
        //��� ������������ � ������
        if (collider.transform.tag.Contains("ENEMY") && gameObject.transform.CompareTag("Player"))
        {
            try
            {
                var hitPower = collider.gameObject.GetComponent<ProjectileControl>().GetHitPower();
                ReduceHeath(hitPower * 2); 
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return;
            } 
        } 
        //print("collided with: " + collider.gameObject.name);
    }

    public void SetHealth(int value)
    {
        if (value >= 0)
        {
            healthLimit = value;
        }
    }
}
