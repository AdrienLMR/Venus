using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool main = false;
    private bool stepOne = false;

    [Header("Screens")]
    [SerializeField] private GameObject titleScreen = default;
    [SerializeField] private GameObject mapScreen = default;
    [SerializeField] private GameObject stepOneScreen = default;

    [Header("Sounds")]
    [SerializeField] private List<AudioSource> Themes;

    // Start is called before the first frame update
    void Start()
    {
        main = true;
        playOnly(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!main && (titleScreen.activeSelf || mapScreen.activeSelf))
        {
            main = true;
            playOnly(0);
            stepOne = false;
        }
        else if (!stepOne && stepOneScreen.activeSelf)
        {
            stepOne = true;
            playOnly(1);
            main = false;
        }
    }

    void playOnly(int music)
    {
        // 0 : Menu & Map
        // 1 : Dialog
        for (int i = 0; i < Themes.Count; i++)
        {
            if(i == music)
                Themes[i].Play();
            else
                Themes[i].Stop();
        }
    }
}
