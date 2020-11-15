using System.Collections.Generic;
using System.Linq;
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
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.001f;
        UIManager.Instance.OnNextTurn += NextTurn;

        Choice choice = GetComponent<Choice>();
        nextChoices.Add(choice);
        choice.enabled = false;
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

    public string GetName()
    {
        return name;
    }

    public void Add(Choice choice)
    {
        nextChoices.Add(choice);
    }

    public void NextTurn()
    {
        for (int i = nextChoices.Count - 1; i >= 0; i--)
        {
            quality += nextChoices[i].qualityOfLifeChange;
            quality = Mathf.Clamp01(quality);
            stability += nextChoices[i].stabilityChange;
            stability = Mathf.Clamp01(stability);


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
