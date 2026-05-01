using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public DayNIght time;    

    public float mapWidth, mapHeight;

    public List<EnemyEntry> enemiesDay;
    public List<EnemyEntry> enemiesNight;

    void Update()
    {    
        if (Random.Range(0, 500/(1+(time.round/100)))==2)
        {
            Debug.Log("o");
            if (time.day)
            {
                Debug.Log("d");
                int enemyIndex = Random.Range(0, enemiesDay.Count);
                Instantiate(enemiesDay[enemyIndex].obj, new Vector3(Random.Range(-mapWidth/2, mapWidth/2), Random.Range(-mapHeight/2, mapHeight/2), enemiesDay[enemyIndex].startHeight), transform.rotation);
            } else
            {
                Debug.Log("n");
                int enemyIndex = Random.Range(0, enemiesNight.Count);
                Instantiate(enemiesNight[enemyIndex].obj, new Vector3(Random.Range(-mapWidth/2, mapWidth/2), Random.Range(-mapHeight/2, mapHeight/2), enemiesNight[enemyIndex].startHeight), transform.rotation);
            }
        }
    }


[System.Serializable]
    public class EnemyEntry
    {
        public GameObject obj;
        public float startHeight;
        public EnemyEntry(GameObject obj, float startHeight, float startingHealth)
        {
            this.obj = obj;
            this.startHeight = startHeight;
        }
    }
}
