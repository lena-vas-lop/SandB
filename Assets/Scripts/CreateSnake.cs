using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateSnake : MonoBehaviour
{
    public int SizeSnakeStart;
    public int SizeSnake;
    public float SizeBody;
    public TMP_Text TextSnake;
    public TMP_Text Text;
    public GameObject HeadSnake;
    private List<GameObject> BodySnake = new List<GameObject>();
    public GameObject Body;
    private List<Vector3> PositionBody = new List<Vector3>();
    public int CounterBlok;
    private AudioSource audiosnake;
    public AudioClip Audio;  
    private void Awake()
    {
        PositionBody.Add(HeadSnake.transform.position);
        audiosnake = GetComponent<AudioSource>();
        AddSnake(SizeSnake);
    }
    void Update()
    {
        float distance = (HeadSnake.transform.position - PositionBody[0]).magnitude;
        if (distance > SizeBody)
        {
            Vector3 direction = (HeadSnake.transform.position - PositionBody[0]).normalized;
            PositionBody.Insert(0, PositionBody[0] + direction * SizeBody);
            PositionBody.RemoveAt(PositionBody.Count - 1);
            distance -= SizeBody;
        }
        for (int i = 0; i < BodySnake.Count; i++)
        {
            BodySnake[i].transform.position = Vector3.Lerp(PositionBody[i + 1], PositionBody[i], distance / SizeBody);
        }
    }
    public void AddSnake(int Add)
    {
        audiosnake.PlayOneShot(Audio);
        for (int i = 0; i < Add; i++)
        {
            GameObject New = Instantiate(Body, PositionBody[SizeSnakeStart-1] + new Vector3(SizeBody, 0f, 0f), Quaternion.identity);
            BodySnake.Add(New);
            PositionBody.Add(New.transform.position);
        }
        SizeSnakeStart += Add;
        TextSnake.text = SizeSnakeStart + string.Empty;
    }
    public void RemoveSnake(int Add)
    {
        audiosnake.Play();
        if (SizeSnakeStart > Add)
        {
            for (int i = 0; i < Add; i++)
            {
                Destroy(BodySnake[0]);
                BodySnake.RemoveAt(0);
                PositionBody.RemoveAt(1);
            }
            SizeSnakeStart -= Add;
            TextSnake.text = SizeSnakeStart + string.Empty;
            CounterBlok += Add;
            Text.text = CounterBlok + string.Empty;
        }
        else 
        {
            SceneManager.LoadScene(2);
        }
    }
}
