using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnTriggerEnter(Collider collaider)
    {
        if (collaider.TryGetComponent(out CreateSnake createSnake))
        { 
            TMP_Text number = gameObject.GetComponentInChildren<TMP_Text>();
            int Add = int.Parse(number.text);
            createSnake.RemoveSnake(Add);
            Destroy(gameObject);            
        }      
    }
}
