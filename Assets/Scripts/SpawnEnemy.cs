using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] Enemy;
    public Vector3 SpawnLocation;
    public float SpawnStart; //wait x seconds after the game start.
    public float SpawnWait;  //wait x seconds between each enemy spawn.
    public float SpawnDelay; //wait x seconds between each spawn wave.
    public int Enemies;      //total enemies spawn each wave.
    public int waves;        // Amount of waves spawn before game is won
    public GameObject[] spawnLocation; //Spawn Locations for jumper.
	void Start ()
    {
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {    
        yield return new WaitForSeconds(SpawnStart);
        for (int w = 0; w < waves; ++w)
        {
            //int random = 1;
            //int spawnRandom = 0;
            int random = Random.Range(0, Enemy.Length);
            int spawnRandom = Random.Range(0, spawnLocation.Length);
            //print("spawnrandom:" + spawnRandom);
            //print("random:" + random);
            for (int i = 0; i< Enemies; i++)
            {
                Quaternion SpawnRotation = Quaternion.identity;
                if (random == 0 || random == 2)
                {
                    Vector3 SpawnPosition = new Vector3
                    (
                         Random.Range(-SpawnLocation.x, SpawnLocation.x),
                         6.0f,
                         0.0f
                    );
                    Instantiate(Enemy[random], SpawnPosition, SpawnRotation);
                }
                else
                {   
                    if (spawnRandom == 0)
                    {
                        Instantiate(Enemy[random], spawnLocation[0].transform.position, spawnLocation[0].transform.rotation);
                    }
                    else
                    {
                        Instantiate(Enemy[random], spawnLocation[1].transform.position, spawnLocation[1].transform.rotation);
                    }
                }
                yield return new WaitForSeconds(SpawnWait);
            }
            GameObject[] LiveEnemies;
            do
            {
                LiveEnemies = GameObject.FindGameObjectsWithTag("Enemy");
                yield return new WaitForEndOfFrame();
            }while (LiveEnemies.Length != 0);
            //yield return new WaitForSeconds(SpawnDelay);
        }
        GameController.instance.WinGame();
    }
}
