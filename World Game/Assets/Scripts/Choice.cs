using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public float qualityOfLifeChange;
    public float stabilityChange;
    public float costMilitary;
    public float costHospitality;

    public int turns;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnPressed);
    }

    private void OnPressed()
    {

    }
}
