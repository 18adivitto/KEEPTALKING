using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateBomb : MonoBehaviour
{
    //prefabs
    public GameObject TimerModule;
    public GameObject EmptyModule;
    
    //variables to change
    public int ModuleAmount = 1;
    public int MaxModules = 5;
    
    //Set in inspector
    public List<GameObject> ModulesToSpawnFrom = new List<GameObject>();
    public int[] LocationsToSpawn; //choose potential index to spawn from
    public Vector3[] Locations; //actual location relative to object
    //debugging purposes
    public List<GameObject> ModulesToSpawn = new List<GameObject>();
    public List<GameObject> SpawnedModules = new List<GameObject>();
    
    

    
    // Start is called before the first frame update
    void Start()
    {
        PickModules();
        //shuffle order of where each module is spawned
        Shuffle(LocationsToSpawn);
        SpawnModules();
    }

    // Update is called once per frame
    void Update()
    {
        //restart for debugging
        Restart();
    }

    //choose modules to spawn from 
    void PickModules()
    {
        int i = Mathf.Min(ModuleAmount, MaxModules);
        while (i > 0)
        {
            int rand = Random.Range(0, ModulesToSpawnFrom.Count);
            ModulesToSpawn.Add(ModulesToSpawnFrom[rand]);
            ModulesToSpawnFrom.Remove(ModulesToSpawnFrom[rand]);
            i--;
        }
    }
    //spawn modules
    void SpawnModules()
    {
        //go through all modules and spawn empty or module
        for(int i = 0; i < LocationsToSpawn.Length; i++)
        {
            int index = LocationsToSpawn[i];
            Debug.Log(index);
            Vector3 location = Locations[index];
            GameObject module = null;
            if (i < ModulesToSpawn.Count)
            {
                module = ModulesToSpawn[i];
            }
            GameObject spawned;
            //check if module exists
            if (module != null)
            {
                spawned = Instantiate(module, transform.position + location, Quaternion.identity);
                spawned.transform.parent = transform;
                SpawnedModules.Add(spawned);
            }
            //if no module, spawn empty module
            else
            {
                spawned = Instantiate(EmptyModule, transform.position + location, Quaternion.identity);
                spawned.transform.parent = transform;
            }
            
        }
        //spawn timer: always spawns at top middle of front: can be adjusted if need be
        GameObject timer = Instantiate(TimerModule, transform.position + Locations[1], Quaternion.identity);
        timer.transform.parent = transform;
    }
    
    //randomize order
    public static void Shuffle<T>(T[] deck)
    {
        for (int i = deck.Length - 1; i >= 1; i--) {
            int randomIndex = Random.Range(0, i + 1);
            T swapTemp = deck[randomIndex];
            deck[randomIndex] = deck[i];
            deck[i] = swapTemp;
        }
    }

    //debugging restart scene
    public void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }
}
