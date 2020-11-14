using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public float qualityOfLifeChange;
    public float stabilityChange;
    public long costMilitary;
    public long costHospitality;

    public int turns;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnPressed);
    }

    private void OnPressed()
    {
        UIManager.Instance.Add(this);
    }

    public void Reject()
    {

    }
}
