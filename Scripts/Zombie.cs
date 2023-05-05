using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public GameObject bulletMago;
    GameObject muzzle;

    [HideInInspector] public bool left;

    Character characterSc;

    [HideInInspector] public int magoHealt = 100;
    Transform Player;
    float distance;

    public float followSpeed;
    bool allowHit = true;

    void Start()
    {
        Player = GameObject.Find("Player").transform;
        characterSc = Player.GetComponent<Character>();

        muzzle = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        distance = Vector2.Distance(this.transform.position, Player.transform.position);
        if (distance > 5f)
        {
            this.transform.position = Vector2.MoveTowards(this.transform.position,
             new Vector2(Player.position.x, this.transform.position.y), followSpeed * Time.deltaTime); //  oyuncuya doðru gitsin
        }
        else
        {
            if (allowHit)
            {
                StartCoroutine(shoot());

            }

        }


    }

    IEnumerator shoot()
    {
        allowHit = false;

        GameObject bullet = Instantiate(bulletMago, muzzle.transform.position, Quaternion.identity);
        Destroy(bullet, 3);

        if (left)
        {
            bullet.GetComponent<bulletMago>().thisLeft = true;
        }
        else
        {
            bullet.GetComponent<bulletMago>().thisLeft = false;
        }

        if (characterSc.playerHealt <= 0)
        {
            characterSc.loseGame();
        }

        yield return new WaitForSeconds(1);

        allowHit = true;

    }

}
