using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;          // List of all the waves to spawn
    [SerializeField] int startingWave = 0;                  // Starting wave index  
    [SerializeField] bool looping = false;                  // Bool to decide if you want to loop or not

    // Start is called before the first frame update
    IEnumerator Start()
    {
        foreach(WaveConfig config in waveConfigs)
        {
            config.SetHasStarted(false);
        }
        do
        {
            // Start SpawnAllCarsInWave coroutine
            yield return StartCoroutine(SpawnAllWaves());
        } while (looping);
    }

    // Spawn all waves in waveConfigs list
    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            // Set current wave
            var currentWave = waveConfigs[waveIndex];
            if (waveConfigs[waveIndex].GetHasStarted() == false)
            {
                waveConfigs[waveIndex].SetHasStarted(true);
                yield return StartCoroutine(SpawnAllCarsInWave(currentWave));
            }
        }
    }

    // Coroutine for spawning all the cars
    private IEnumerator SpawnAllCarsInWave(WaveConfig waveConfig)
    {
        for (int carCount = 0; carCount < waveConfig.GetNumberOfCars(); carCount++)
        {
            // Instantiate a new car
            var newCar = Instantiate(waveConfig.GetCarPrefab(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity);
            // Set the waveConfig for the car
            newCar.GetComponent<CarPathing>().SetWaveConfig(waveConfig);
            newCar.GetComponent<CarPathing>().SetCarNumber(carCount);
            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawns());
        }
    }
}
