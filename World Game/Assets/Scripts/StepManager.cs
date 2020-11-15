using System;
using System.Collections;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    public static StepManager Instance;

    private DateTime _startDate;
    private DateTime _currentDate = DateTime.Now;
    private int _steps = 1;
    private Coroutine _goingToNextStep;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void StartGoingToNextStep()
    {
        _goingToNextStep = StartCoroutine(GoToNextStep());
    }

    public bool IsGoingToNextStep()
    {
        return _goingToNextStep != null;
    }

    IEnumerator GoToNextStep()
    {
        DateTime targetDate = _currentDate.AddDays(365);

        while (_currentDate < targetDate)
        {
            _currentDate = _currentDate.AddDays(1);
            yield return new WaitForSeconds(0.01f);
        }

        _steps++;
        _goingToNextStep = null;
    }
}
