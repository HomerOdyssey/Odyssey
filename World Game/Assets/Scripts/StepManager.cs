using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    public static StepManager Instance;

    private DateTime _startDate;
    private DateTime _currentDate = DateTime.Now;
    private int _steps = 1;
    private Coroutine _goingToNextStep;

    [SerializeField] private Region[] _regions;

    [SerializeField] private TMP_Text dateTextfield;

    [SerializeField] private float speedInSeconds;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    public void StartGoingToNextStep()
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
            dateTextfield.text = _currentDate.ToString("dd/MM/yyyy");
            _currentDate = _currentDate.AddDays(1);
            
            UIManager.Instance.NextDay();
            
            yield return new WaitForSeconds(speedInSeconds);
        }

        for (int i = 0; i < _regions.Length; i++)
            _regions[i].NextTurn();

        _steps++;
        _goingToNextStep = null;
    }
}
