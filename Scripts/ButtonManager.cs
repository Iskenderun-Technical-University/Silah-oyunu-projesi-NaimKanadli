using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [HideInInspector] public int stage = 1;

    Character characterSc;
    Transform Player;

    [HideInInspector] public List<GameObject> levelList;

    private void Awake()
    {
        Player = GameObject.Find("Player").transform;

    }

    private void Start()
    {
        characterSc = Player.GetComponent<Character>();

        GameObject BG = GameObject.Find("BG");

        for (int i = 0; i < BG.transform.childCount; i++)
        {
            levelList.Add(BG.transform.GetChild(i).gameObject);
        }
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void backMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void nextStage()
    {
        switch (stage)
        {

            case 1:
                Player.transform.position = new Vector2(0, Player.transform.position.y);
                characterSc.zombieCount = 5;

                levelList[stage - 1].SetActive(false);
                levelList[stage].SetActive(true);

                break;
            case 2:
                Player.transform.position = new Vector2(0, Player.transform.position.y);
                characterSc.zombieCount = 7;

                levelList[stage - 1].SetActive(false);
                levelList[stage].SetActive(true);

                break;
            case 3:
                Player.transform.position = new Vector2(0, Player.transform.position.y);
                characterSc.zombieCount = 9;

                levelList[stage - 1].SetActive(false);
                levelList[stage].SetActive(true);

                break;
            case 4:
                Player.transform.position = new Vector2(0, Player.transform.position.y);
                characterSc.zombieCount = 12;

                levelList[stage - 1].SetActive(false);
                levelList[stage].SetActive(true);

                break;


        }
        stage++;
        characterSc.winCanvas.enabled = false;
        characterSc.startGame();

    }
}
