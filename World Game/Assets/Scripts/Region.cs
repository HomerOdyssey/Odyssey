using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Image))]
public class Region : MonoBehaviour
{
    [SerializeField] private float quality;
    [SerializeField] private float stability;
    [SerializeField] private new string name;

    [SerializeField] private List<Choice> nextChoices;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SetAsMenu);
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
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
        for (int i = nextChoices.Count - 1; i >= 0; i--)
        {
            quality += nextChoices[i].qualityOfLifeChange;
            stability += nextChoices[i].stabilityChange;


            if (--nextChoices[i].turns <= 0)
            {
                nextChoices.RemoveAt(i);
            }
        }
    }

    private void Reset()
    {
        name = gameObject.name;
        quality = Random.Range(0, 1f);
        stability = Random.Range(0, 1f);
    }
}
