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
	
	void Start ()
    {
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
        int random = Random.Range(0, Enemy.Length);
        yield return new WaitForSeconds(SpawnStart);
        for (int w = 0; w < waves; ++w)
        {
            for(int i = 0; i< Enemies; i++)
            {
                Quaternion SpawnRotation = Quaternion.identity;
                if (random == 0)
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
                    Vector3 SpawnPosition1 = new Vector3(-10.0f, -2.0f, 0.0f);
                    Instantiate(Enemy[random], SpawnPosition1, SpawnRotation);
                }
                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(SpawnDelay);
        }
        GameController.instance.WinGame();
    }
}
