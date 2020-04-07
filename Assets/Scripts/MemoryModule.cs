using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class MemoryModule : MonoBehaviour
{

    public List<int[]> stages = new List<int[]>();
    public int[] stage01 = { 1, 2, 3, 4 };
    public int[] stage02 = { 1, 2, 3, 4 };
    public int[] stage03 = { 1, 2, 3, 4 };
    public int[] stage04 = { 1, 2, 3, 4 };
    public int[] stage05 = { 1, 2, 3, 4 };
    public int curstage = 1;
    public int bigNumber;
    int stage01index;
    int stage02index;
    int stage03index;
    int stage04index;
    int stage05index;


    //__________________________________________
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public GameObject bigtext;


    void Start()
    {
        stages.Add(stage01);
        stages.Add(stage02);
        stages.Add(stage03);
        stages.Add(stage04);
        stages.Add(stage05);

        // Randomize the order of number in each stage
        foreach (int[] stage in stages)
        {
            for (int i = 0; i < 2; i++)
            {
                int temp;
                int index1 = Random.Range(0, 4);
                int index2 = Random.Range(0, 4);
                temp = stage[index1];
                stage[index1] = stage[index2];
                stage[index2] = temp;
            }
        }

        startStage();
    }

    void startStage()
    {
        curstage = 1;
        bigNumber = Random.Range(1, 5);
        refresh();
    }

    public void bottonClick(int index)
    {
        switch (curstage)
        {
            case 1:
                stage1check(index);
                break;
            case 2:
                stage2check(index);
                break;
            case 3:
                stage3check(index);
                break;
            case 4:
                stage4check(index);
                break;
            case 5:
                stage5check(index);
                break;

       }
    }

    void nextStage()
    {
        curstage++;
        bigNumber = Random.Range(1, 5);
        refresh();
    }

    void stage1check(int index)
    {
        stage01index = index;
        if (bigNumber == 1 && index == 1)
        {
            nextStage();
            return;
        }

        if (bigNumber == 2 && index == 1)
        {
            nextStage();
            return;
        }

        if (bigNumber == 3 && index == 2)
        {
            nextStage();
            return;

        }
        if (bigNumber == 4 && index == 3)
        {
            nextStage();
            return;
        }

        startStage();
    }

    void stage2check(int index)
    {
        stage02index = index;
        if (bigNumber == 1 && stage02[index] == 4)
        {
            nextStage();
            return;
        }

        if (bigNumber == 2 && index == stage01index)
        {
            nextStage();
            return;
        }

        if (bigNumber == 3 && index == 0)
        {
            nextStage();
            return;

        }
        if (bigNumber == 4 && index == stage01index)
        {
            nextStage();
            return;
        }

        startStage();
    }

    void stage3check(int index)
    {
        stage03index = index;
        if (bigNumber == 1 && stage03[index] == stage02[stage02index])
        {
            nextStage();
            return;
        }

        if (bigNumber == 2 && stage03[index] == stage01[stage01index])
        {
            nextStage();
            return;
        }

        if (bigNumber == 3 && index == 2)
        {
            nextStage();
            return;

        }
        if (bigNumber == 4 && stage03[index] == 4)
        {
            nextStage();
            return;
        }

        startStage();
    }

    void stage4check(int index)
    {
        stage04index = index;
        if (bigNumber == 1 && index == stage01index)
        {
            nextStage();
            return;
        }

        if (bigNumber == 2 && index == 0)
        {
            nextStage();
            return;
        }

        if (bigNumber == 3 && index == stage02index)
        {
            nextStage();
            return;

        }
        if (bigNumber == 4 && index == stage02index)
        {
            nextStage();
            return;
        }

        startStage();
    }

    void stage5check(int index)
    {
        stage05index = index;
        if (bigNumber == 1 && stage05[index] == stage01[stage01index])
        {
            nextStage();
            return;
        }

        if (bigNumber == 2 && stage05[index] == stage02[stage02index])
        {
            nextStage();
            return;
        }

        if (bigNumber == 3 && stage05[index] == stage03[stage03index])
        {
            nextStage();
            return;

        }
        if (bigNumber == 4 && stage05[index] == stage04[stage04index])
        {
            nextStage();
            return;
        }

        startStage();
    }


    void refresh()
    {
        if (curstage == 6)
        {
            bigtext.GetComponent<Text>().text = "complete";
            return;
        }
        bigtext.GetComponent<Text>().text = "" + bigNumber;
        text1.GetComponent<Text>().text = "" + stages[curstage - 1][0];
        text2.GetComponent<Text>().text = "" + stages[curstage - 1][1];
        text3.GetComponent<Text>().text = "" + stages[curstage - 1][2];
        text4.GetComponent<Text>().text = "" + stages[curstage - 1][3];
        
    }

}
