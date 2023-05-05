using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    GameObject Player;

    public float speed = 0.2f;

    Character characterSc;

    bool thisLeft;

    private void Start()
    {
        Player = GameObject.Find("Player");

        characterSc = Player.GetComponent<Character>();

        thisLeft = characterSc.left;
    }

    void Update()
    {
        if (thisLeft)
        {
            transform.Translate(-1 * speed, 0, 0);
        }
        else
        {
            transform.Translate(1 * speed, 0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie")
        {
            GameObject zombie = collision.gameObject;
            Zombie zombieSc = zombie.GetComponent<Zombie>();

            zombieSc.magoHealt -= Random.Range(15,20);

            if (zombieSc.magoHealt <= 0)
            {
                Destroy(zombie.gameObject);
                characterSc.activeZombieCount--;

                if (characterSc.activeZombieCount <=0)
                {
                    characterSc.winGame();
                }
            }

            Destroy(this.gameObject);

        }
    }
}
