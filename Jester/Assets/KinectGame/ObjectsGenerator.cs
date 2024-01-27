using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Assets.KinectGame.Enums;

public class ObjectsGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject TargetPrefab;
    private GameObject[] Targets = new GameObject[4];
    private bool redrawObjects = true;
    private List<Vector3[]> TargetPositions = new List<Vector3[]>()
    {
        //                       LH,                RH,              LF,                RF
        //new Vector3[4] { new Vector3(1.3f,2), new Vector3(-1.3f,2), new Vector3(-1.3f,-3), new Vector3(1.3f,-3), }, //cross hands
        new Vector3[4] { new Vector3(-1.3f, 2), new Vector3(1.3f,2), new Vector3(-1.3f,-3), new Vector3(1.3f,-3)  }, //spread
        new Vector3[4] { new Vector3(-2f,0), new Vector3(2f, 0), new Vector3(0f,-3), new Vector3(1.3f,-2)  }, //RF up
        new Vector3[4] { new Vector3(-2f,2), new Vector3(2f, 2), new Vector3(-0.5f,-3), new Vector3(0.5f,-3)  }, //Y
        new Vector3[4] { new Vector3(-0.5f,2), new Vector3(0.5f, 2), new Vector3(-0.5f,-3), new Vector3(0.5f,-3)  }, //M
        new Vector3[4] { new Vector3(1f,0), new Vector3(2f, 0), new Vector3(-0.5f,-3), new Vector3(0.5f,-3)  }, //C
        new Vector3[4] { new Vector3(-0.5f,3), new Vector3(0.5f, 3), new Vector3(-0.5f,-3), new Vector3(0.5f,-3)  }, //A

    };

    void Start()
    {
        Targets = new GameObject[4];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (redrawObjects)
        {
            redrawObjects = false;
            RestartTargets(true);
        }
        TriggerTargets();
        redrawObjects = CheckIfAllTargetsDestroyed();
    }

    void RestartTargets(bool usePresets)
    {
        if (usePresets)
        {
            int selectedPreset = UnityEngine.Random.Range(0, TargetPositions.Count);
            for (int i = 0; i != Targets.Length; i++)
            {
                if (Targets[i] == null || Targets[i].GetComponent<TargetController>().shouldDestroy)
                {
                    GameObject targetToDelete = Targets[i];
                    LimbType lt = (LimbType)(i + 1);
                    Targets[i] = Instantiate(TargetPrefab);
                    if (targetToDelete != null)
                    {
                        Destroy(targetToDelete);
                    }
                    Targets[i].name = "Target" + lt;
                    TargetController tc = Targets[i].GetComponent<TargetController>();
                    tc.transform.position = TargetPositions[selectedPreset][i];
                    tc.TargetLimbType = lt;
                    tc.shouldRandomize = false;
                }
            }
        }
        else
        {
            for (int i = 0; i != Targets.Length; i++)
            {
                if (Targets[i] == null || Targets[i].GetComponent<TargetController>().shouldDestroy)
                {
                    LimbType lt = (LimbType)(i + 1);
                    Targets[i] = Instantiate(TargetPrefab);
                    Targets[i].name = "Target" + lt;
                    TargetController tc = Targets[i].GetComponent<TargetController>();
                    tc.TargetLimbType = lt;
                    tc.shouldRandomize = true;
                }
            }
        }
    }

    bool CheckIfAllTargetsDestroyed()
    {
        for (int i = 0; i != Targets.Length; i++)
        {
            if (!Targets[i].GetComponent<TargetController>().shouldDestroy)
                return false;
        }
        Debug.Log("BRAWO!");
        return true;
    }

    void TriggerTargets()
    {
        bool success = true;
        for (int i = 0; i != Targets.Length; i++)
        {
            success &= Targets[i].GetComponent<TargetController>().IsTriggered();
        }
        for (int i = 0; i != Targets.Length; i++)
        {
            if (success)
            {
                Targets[i].GetComponent<TargetController>().StartProgressBar();
            }
            else
            {
                Targets[i].GetComponent<TargetController>().StopProgressBar();
            }
        }
    }
}
