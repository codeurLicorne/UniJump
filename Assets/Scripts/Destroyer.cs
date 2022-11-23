using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject player;
    public GameObject platformPrefab;
    public GameObject springPrefab;
    //private GameObject myPlat;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.StartsWith("Platform"))
        {
            if(Random.Range (1, 13) == 1)
            {
                Destroy(collision.gameObject);
                Instantiate(springPrefab, new Vector2(Random.Range(-2f, 2f),
                    player.transform.position.y + (6 + Random.Range(0.2f, 1f))), Quaternion.identity);
            }
            else
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-2f, 2f),
                    player.transform.position.y + (6 + Random.Range(0.2f, 1f)));
            }
        }
        else if (collision.gameObject.name.StartsWith("Spring"))
        {
            if (Random.Range(1, 13) == 1)
            {
                collision.gameObject.transform.position = new Vector2(Random.Range(-2f, 2f),
                    player.transform.position.y + (6 + Random.Range(0.2f, 1f)));

            }
            else
            {
                Destroy(collision.gameObject);
                Instantiate(platformPrefab, new Vector2(Random.Range(-2f, 2f),
                    player.transform.position.y + (6 + Random.Range(0.2f, 1f))), Quaternion.identity);
            }
        }



    }
}

/*
private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Random.Range(1,13)>1)
        {
            myPlat = (GameObject)Instantiate(platformPrefab, new Vector2(Random.Range(-2f, 2f),
            player.transform.position.y + (6 + Random.Range(0.5f, 1f))), Quaternion.identity);

        }
        else
        {
            myPlat = (GameObject)Instantiate(springPrefab , new Vector2(Random.Range(-2f, 2f),
            player.transform.position.y + (6 + Random.Range(0.5f, 1f))), Quaternion.identity);
        }

        
        Destroy(collision.gameObject);

    }
*/
