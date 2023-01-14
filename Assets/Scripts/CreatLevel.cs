using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreatLevel : MonoBehaviour
{
    public GameObject Block;
    private TMP_Text Text;
    public GameObject Wool;
    public GameObject Eat;
    public Material[] ColorBlock;
    public float DistanceBlock;
    public Vector3[] PositionBlock;
    public Vector3[] PositionWool;
    public float SizeWool;
    public int level
    {
        get => PlayerPrefs.GetInt("level", 0);
        private set
        {
            PlayerPrefs.SetInt("level", value);
            PlayerPrefs.Save();
        }
    }
    private float Delta;
    public void NextLevel()
    {
        level++;
        SceneManager.LoadScene(1);
    }
    void Awake()
    {
        int level1=level+1;
        Delta = DistanceBlock / 2;
        System.Random random = new System.Random(level);
        for (int j = 1; j < 12; j++)
        {
            for (int i = 0; i < 4; i++)
            {
                if (random.Next(0, 21) >= 8)
                {
                    GameObject eat = Instantiate(Eat, new Vector3(PositionWool[i].x + Delta, PositionWool[i].y, (float)random.Next(0,140)-70f), Quaternion.identity);
                    TMP_Text number = eat.GetComponentInChildren<TMP_Text>();
                    number.text = random.Next(1, 4*level1) + string.Empty;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                int r = random.Next(0, 30)/4;
                if (r == 1)
                {
                    GameObject Blok = Instantiate(Wool, PositionWool[i], Quaternion.identity);
                }
                else if (r == 2)
                {
                    GameObject Blok = Instantiate(Wool, PositionWool[i], Quaternion.identity);
                    Blok = Instantiate(Wool, new Vector3(PositionWool[i].x+SizeWool, PositionWool[i].y,  PositionWool[i].z), Quaternion.identity);
                    Blok = Instantiate(Wool, new Vector3(PositionWool[i].x - SizeWool, PositionWool[i].y, PositionWool[i].z), Quaternion.identity);
                }
                else if (r==3)
                {
                    GameObject Blok = Instantiate(Wool, new Vector3(PositionWool[i].x + SizeWool, PositionWool[i].y, PositionWool[i].z), Quaternion.identity);
                    Blok = Instantiate(Wool, new Vector3(PositionWool[i].x - SizeWool, PositionWool[i].y, PositionWool[i].z), Quaternion.identity);
                }
                PositionWool[i].x += DistanceBlock;
            }
            for (int i = 0; i < 5; i++)
            {
                
                if (random.Next(0, 21)>= 3)
                {
                    GameObject Blok = Instantiate(Block, PositionBlock[i], Quaternion.identity) as GameObject;
                    Renderer _renderer = Blok.GetComponent<Renderer>();
                    _renderer.material = ColorBlock[random.Next(0, 4)];
                    TMP_Text number = Blok.GetComponentInChildren<TMP_Text>();
                    number.text = random.Next(1, 5*level1) + string.Empty;
                    PositionBlock[i].x += DistanceBlock;
                }
            }
        }
    }
}
