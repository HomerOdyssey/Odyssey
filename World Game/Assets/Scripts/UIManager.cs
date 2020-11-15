using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image qualityOfLifeSlider;
    [SerializeField] private Image stabilitySlider;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Canvas ui;


    [Header("Budget")]
    [SerializeField] private TextMeshProUGUI budgetText;
    [SerializeField] private TextMeshProUGUI militaryBudgetText;
    [SerializeField] private Canvas iconsCanvas;


    [SerializeField] private long budget;
    [SerializeField] private long militaryBudget;

    public event Action OnNextTurn;

    private Region active;
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        Render();
    }

    public void Show(Region region)
    {
        active = region;
        Render();
    }

    public void Add(Choice choice)
    {
        if (active == null)
        {
            return;
        }

        if (militaryBudget - choice.costMilitary <= 0 || budget - choice.costHospitality <= 0)
        {
            choice.Reject();
            return;

        }

        militaryBudget -= choice.costMilitary;
        budget -= choice.costHospitality;
        active.Add(choice);
        Render();
    }


    public void NextTurn()
    {
        OnNextTurn?.Invoke();
        
        StepManager.Instance.StartGoingToNextStep();
    }

    public void Render()
    {
        militaryBudgetText.text = $"$ {militaryBudget}";
        budgetText.text = $"$ {budget}";
        if (active == null)
        {
            ui.enabled = false;
            iconsCanvas.enabled = false;
            return;
        }
        ui.enabled = true;
        iconsCanvas.enabled = true;


        nameText.text = active.GetName();
        stabilitySlider.fillAmount = active.GetStability();
        qualityOfLifeSlider.fillAmount = active.GetQuality();
    }
    
    public void NextDay()
    {
        if (active == null) return;
        
        qualityOfLifeSlider.fillAmount += (active.GetStability() - qualityOfLifeSlider.fillAmount) / 365;
        stabilitySlider.fillAmount += (active.GetStability() - stabilitySlider.fillAmount) / 365;
    }

}
