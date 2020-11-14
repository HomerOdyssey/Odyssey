using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider qualityOfLifeSlider;
    [SerializeField] private Slider stabilitySlider;

    [SerializeField] private long budget;
    [SerializeField] private long militaryBudget;


    private Region active;
    public static UIManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    public void Show(Region region)
    {
        active = region;
        Render();
    }

    public void Show(Choice region)
    {
    }


    public void NextTurn()
    {

    }

    private void Render()
    {
        stabilitySlider.value = active.GetStability();
        qualityOfLifeSlider.value = active.GetQuality();
    }

}
