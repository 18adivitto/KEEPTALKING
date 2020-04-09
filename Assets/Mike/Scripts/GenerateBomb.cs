using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

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
    
    //Strikes
    public int MaxStrikes = 2;
    private int CurrentStrikes = 0;
    
    
    //EXTERNAL MODULES //
    
    //serial number
    public string SerialN = "";
    public bool IsEven;
    public bool HasVowel;
    public int BatteryNum;

    //indicators
    public List<string> Indicators = new List<string>();
    private string[] IndicatorsToAdd = new[] {"SND", "CLR", "CAR","IND","FRQ","SIG","NSA","MSA","TRN","BOB","FRK"};
    private int MaxIndicators = 5;
    private float LikelihoodToBeOn = .6f;
    public List<Indicator> AddedIndicators = new List<Indicator>();
    // Start is called before the first frame update
    void Start()
    {
        PickModules();
        //shuffle order of where each module is spawned
        RandFuncs.Shuffle(LocationsToSpawn);
        
        //Construct bomb
        SpawnModules();
        CreateSerial();
        AddIndicators();
        AddBatteries();
    }

    // Update is called once per frame
    void Update()
    {
        //restart for debugging
        Restart();

        Debug.Log(SerialN);
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
            //Debug.Log(index);
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
    
    

    //debugging restart scene
    public void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    //strike occurs
    public void BombStrikes()
    {
        CurrentStrikes++;
        if (CurrentStrikes > MaxStrikes)
        {
            //Game Over
            GameOver();
        }
    }

    public void GameOver()
    {
        
    }
    List<char> serial = new List<char>();
    public void CreateSerial()
    {
        //randomly select five chars [at least 1 number and 2 letters]
        
        
        //guarantee two letters and one number
        serial.Add(RandomLetter());
        serial.Add(RandomLetter());
        serial.Add(RandomNum(false));
        
        //Pick 2 more nums or letters
        for (int i = 0; i < 2; i++)
        {
            
            if (Random.Range(0f, 1f) < .5f)
            {
                serial.Add(RandomLetter());
            }
            else
            {
                serial.Add(RandomNum(false));
            }
        }
        
        //shuffle the first 5 chars
        RandFuncs.Shuffle(serial);
        
        //add final number to the string and check if it is even
        serial.Add(RandomNum(true));
        foreach (char c in serial)
        {
            SerialN += c;
        }
    }

    public char RandomLetter()
    {
        int letter = Random.Range(0, 26);
        
        //Repick a number that does not correspond with the letter Y
        while (letter == 25)
        {
            letter = Random.Range(0, 26);
        }
        //letter
        char c = (char) ('A' + letter);
        //check if is a vowel
        if (c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
        {
            HasVowel = true;
        }
        return c;
    }
    
    
    //for serialization
        
    public char RandomNum(bool checkForEven)
    {
        int num = Random.Range(0, 10);
        if (checkForEven && num % 2 == 0)
        {
            IsEven = true;
        }
        Debug.Log(num.ToString());
        Debug.Log(num);
        return num.ToString()[0];
    }

    void AddIndicators()
    {
        foreach (string indicator in IndicatorsToAdd)
        {
            Indicators.Add(indicator);
        }
        
        //min range is 1 to MaxIndicators
        int indicNums = Random.Range(1, MaxIndicators + 1);
        
        //create the number of indicators and add to list
        for(int i = 0; i < indicNums; i++)
        {
            Indicator indic = new Indicator();
            //pick one of the indicator strings
            int index = Random.Range(0, Indicators.Count);
            string str = Indicators[index];
            Indicators.Remove(str);
            indic.str = str;
            //randomize if light is on or off
            indic.IsOn = Random.Range(0f, 1f) < LikelihoodToBeOn;
            AddedIndicators.Add(indic);
        }
    }
    
    void AddBatteries()
    {
        //randomize batteries-0 to 2 batteries-currently equal likelihood
        int batteryNum = Random.Range(0, 3);
        BatteryNum = batteryNum;

    }
    
    
}

public struct Indicator
{
    public string str;
    public bool IsOn;
}
