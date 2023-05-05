using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public GameObject bulletPrefab, magoPrefab;
    public float moveSpeed;
    public int zombieCount;
    [HideInInspector] public int activeZombieCount;

    GameObject muzzle;
    [HideInInspector] public bool left;

    [HideInInspector] public int playerHealt = 100;
    public Text healtTxt;

    ButtonManager buttonManager;

    void Start()
    {
        muzzle = this.transform.GetChild(0).gameObject;
        buttonManager = GameObject.Find("Scripts").GetComponent<ButtonManager>();
        startGame();

    }

    public void startGame()
    {
        Time.timeScale = 1;
        StartCoroutine(zombieMaker());
        activeZombieCount = zombieCount;

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(1 * moveSpeed, 0, 0);
            this.transform.rotation = Quaternion.Euler(0, -180, 0);

            left = true;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * moveSpeed, 0, 0);
            this.transform.rotation = Quaternion.Euler(0, 0, 0);

            left = false;

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            fire();
        }

    }

    void fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, muzzle.transform.position, Quaternion.identity);
        Destroy(bullet, 3);
    }

    public Transform enemyGO;
    IEnumerator zombieMaker()
    {
        for (int i = 0; i < zombieCount; i++)
        {

            int leftRight = Random.Range(0, 2);

            if (leftRight == 0) // Soldan yarat
            {
                GameObject mago = Instantiate(magoPrefab, new Vector3(-8.3f, -4.5f, 0), Quaternion.identity);
                mago.transform.GetComponent<Zombie>().left = true;
            }
            else
            {
                GameObject mago = Instantiate(magoPrefab, new Vector3(8.3f, -4.5f, 0), Quaternion.Euler(0, 180, 0));
                mago.transform.GetComponent<Zombie>().left = false;

            }

            if (i == zombieCount - 1)
            {
                break;
            }
            yield return new WaitForSeconds(2.2f);

        }

    }

    public Canvas loseCanvas, winCanvas;

    public void loseGame()
    {
        loseCanvas.enabled = true;
        StopCoroutine(zombieMaker());

        Time.timeScale = 0;
        Destroy(this.gameObject);
    }

    public void winGame()
    {
        winCanvas.enabled = true;
        StopCoroutine(zombieMaker());

        if (buttonManager.stage == 5)
        {
            winCanvas.transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            winCanvas.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().text = "Oyunu Bitti !";
        }

        Time.timeScale = 0;

    }



}
