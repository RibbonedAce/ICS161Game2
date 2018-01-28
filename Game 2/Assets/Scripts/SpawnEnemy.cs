using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject Enemy;
    public Vector3 SpawnLocation;
    public float SpawnStart; //wait x seconds after the game start.
    public float SpawnWait;  //wait x seconds between each enemy spawn.
    public float SpawnDelay; //wait x seconds between each spawn wave.
    public int Enemies;      //total enemies spawn each wave.
    private bool IsGameOver; 
	// Use this for initialization
	// Update is called once per frame
	void Start ()
    {
        IsGameOver = false;
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(SpawnStart);
        while(true)
        {
            for(int i = 0; i< Enemies; i++)
            {
                Vector3 SpawnPosition = new Vector3
                (
                     Random.Range(-SpawnLocation.x, SpawnLocation.x),
                     Random.Range(-2.0f,SpawnLocation.y),
                     0.0f
                );
                Quaternion SpawnRotation = Quaternion.identity;
                Instantiate(Enemy,SpawnPosition,SpawnRotation);
                yield return new WaitForSeconds(SpawnWait);
            }
            yield return new WaitForSeconds(SpawnDelay);
            if (IsGameOver)
            {
                break; //stop spawning if Game is over.
            }
        }
    }
}
