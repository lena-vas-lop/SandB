using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public CreatLevel CreatLevel;
    private void OnTriggerEnter(Collider collaider)
    {
        if (collaider.TryGetComponent(out CreateSnake createSnake))
        {
            CreatLevel.NextLevel();            
        }
    }
}
