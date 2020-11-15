using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void StartSimulation()
    {
        if (!StepManager.Instance.IsGoingToNextStep())
        {
            StepManager.Instance.IsGoingToNextStep();
        }
    }
}
