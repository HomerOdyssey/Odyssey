using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Region : MonoBehaviour
{
    [SerializeField] private float quality;
    [SerializeField] private float stability;

    [SerializeField] private Choice nextChoice;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetAsMenu);
    }

    public void SetAsMenu()
    {
        UIManager.Instance.Show(this);
    }

    public float GetQuality()
    {
        return quality;
    }

    public float GetStability()
    {
        return stability;
    }

}
