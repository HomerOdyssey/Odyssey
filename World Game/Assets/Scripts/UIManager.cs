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
    [SerializeField] private Image budgetSlider;
    [SerializeField] private TextMeshProUGUI militaryBudgetText;
    [SerializeField] private Image militaryBudgetSlider;
    [SerializeField] private TextMeshProUGUI peaceBudgetText;
    [SerializeField] private Image peaceBudgetSlider;
    [SerializeField] private Canvas iconsCanvas;


    [SerializeField] private long humanitarionBudget;
    private long humanitarionBudgetMax;
    [SerializeField] private long peaceBudget;
    private long peaceBudgetMax;
    [SerializeField] private long militaryBudget;
    private long militaryBudgetMax;

    public event Action OnNextTurn;

    private Region active;
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        militaryBudgetMax = militaryBudget;
        humanitarionBudgetMax = humanitarionBudget;
        peaceBudgetMax = peaceBudget;
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

        if (militaryBudget - choice.costMilitary <= 0 || humanitarionBudget - choice.costHospitality <= 0 || peaceBudget - choice.costPeace <= 0)
        {
            choice.Reject();
            return;

        }

        militaryBudget -= choice.costMilitary;
        humanitarionBudget -= choice.costHospitality;
        peaceBudget -= choice.costPeace;
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
        budgetText.text = $"$ {humanitarionBudget}";
        peaceBudgetText.text = $"$ {peaceBudget}";

        peaceBudgetSlider.fillAmount = Mathf.InverseLerp(0, peaceBudgetMax, peaceBudget);
        budgetSlider.fillAmount = Mathf.InverseLerp(0, humanitarionBudgetMax, humanitarionBudget);
        militaryBudgetSlider.fillAmount = Mathf.InverseLerp(0, militaryBudgetMax, militaryBudget);

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
