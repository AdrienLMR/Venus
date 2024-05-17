using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private bool main = false;
    private bool stepOne = false;

    [Header("Screens")]
    [SerializeField] private GameObject titleScreen = default;
    [SerializeField] private GameObject mapScreen = default;
    [SerializeField] private GameObject stepOneScreen = default;

    [Header("Musics")]
    [SerializeField] private List<AudioSource> Themes;

    [Header("Sounds")]
    [SerializeField] private List<AudioSource> sfx;

    public static GameManager Instance = default;

	private void Awake()
	{
        if (Instance != null)
            Destroy(gameObject);

        Instance = this;
	}

	// Update is called once per frame
	void Update()
    {
        if (!main && (titleScreen.activeSelf || mapScreen.activeSelf))
        {
            main = true;
            playOnlyMusic(0);
            stepOne = false;
        }
        else if (!stepOne && stepOneScreen.activeSelf)
        {
            stepOne = true;
            playOnlyMusic(1);
            main = false;
        }

        if(Input.GetMouseButtonDown(0))
        {
            sfx[0].Play();
        }
    }

    void playOnlyMusic(int music)
    {
        // 0 : Menu & Map
        // 1 : Dialog
        // 2 : Leopold
        // 3 : Esther
        // 4 : Louise
        // 5 : Tobias
        for (int i = 0; i < Themes.Count; i++)
        {
            if(i == music)
                Themes[i].Play();
            else
                Themes[i].Stop();
        }
    }

    void playOnlySfx(int effect)
    {
        // 1 : Victory
        // 2 : Game Over
        // 3 : Bell
        // 4 : Angry Kid
        // 5 : Wood Crack
        // 6 : Book
        // 7 : Cough
        for (int i = 1; i < sfx.Count; i++)
        {
            if (i == effect)
                sfx[i].Play();
            else
                sfx[i].Stop();
        }
    }

    public void leopoldMusicOn()
    {
        playOnlyMusic(2);
        playOnlySfx(4);
    }

    public void louiseMusicOn()
    {
        playOnlyMusic(4);
        playOnlySfx(7);
    }

    public void tobiasMusicOn()
    {
        playOnlyMusic(5);
        playOnlySfx(5);
    }

    public void estherMusicOn()
    {
        playOnlyMusic(3);
        playOnlySfx(3);
    }
}
