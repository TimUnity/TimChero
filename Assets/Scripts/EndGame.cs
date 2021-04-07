using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{  
    //При столкновении игрока с точкой завершения уровня происходит завершение уровня
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            print("Level Complitted");
        }
    }
}
