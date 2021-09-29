using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public static int enemiesAlive;
    [SerializeField] WaveConfig[] waveLists;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float countDown = 2f;
    private int waveIndex = 0;

    [SerializeField] Text waveCountDownText;

    public GameManager gameManager;
    
    void Start()
    {
        enemiesAlive = 0;
    }

    void Update()
    {
        Debug.Log("Enemis Alive: " + enemiesAlive);

        if (enemiesAlive > 0)
        {
            return;
        }

        if (waveIndex == waveLists.Length)
        {
            gameManager.WinLevel();
            this.enabled = false;
        }

        WaveTimeControl();
    }

    void WaveTimeControl()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
            return;
        }

        countDown -= Time.deltaTime;
        countDown = Mathf.Clamp(countDown,0f,Mathf.Infinity);
        waveCountDownText.text = string.Format("{0:00.00}", countDown);
    }

    IEnumerator SpawnWave()
    {

        WaveConfig wave = waveLists[waveIndex];

        for(int i = 0; i < wave.GetEnemyNumber(); i++)
        {
            SpawnEnemy(wave);
            yield return new WaitForSeconds(wave.GetEnemySpawnTime());
        }

        //enemiesAlive = wave.GetEnemyNumber();
        waveIndex++;
        
        PlayerStats.rounds++;
    }

   void SpawnEnemy(WaveConfig currentWave)
    {
        var enemy = Instantiate(currentWave.GetEnemyPrefab(), transform.position, Quaternion.identity);
        enemy.GetComponent<EnemyMovement>().SetWaveConfig(currentWave);
        enemiesAlive++;
    }
}
