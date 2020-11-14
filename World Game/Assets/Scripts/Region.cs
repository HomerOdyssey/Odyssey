using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Region : MonoBehaviour
{
    [SerializeField] private float quality;
    [SerializeField] private float stability;
    [SerializeField] private new string name;

    [SerializeField] private List<Choice> nextChoices;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetAsMenu);
        UIManager.Instance.OnNextTurn += NextTurn;
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

    public string GetName()
    {
        return name;
    }

    public void Add(Choice choice)
    {
        nextChoices.Add(choice);
    }

    private void NextTurn()
    {
        Debug.Log(nextChoices.Count);
        for (int i = nextChoices.Count - 1; i >= 0; i--)
        {
            Debug.Log(i);
            quality += nextChoices[i].qualityOfLifeChange;
            stability += nextChoices[i].stabilityChange;


            if (--nextChoices[i].turns <= 0)
            {
                nextChoices.RemoveAt(i);
            }
        }
    }
}
