using UnityEngine;

public class Country : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private float conflict;
    [SerializeField] private int id;

    [SerializeField] private int conflictChance;

    [SerializeField] private float aidHelp;
    [SerializeField] private float militaryHelp;
    [SerializeField] private float reliefHelp;
    [SerializeField] private float initialConflictValue;

    public void SetID(int id)
    {
        this.id = id;
    }

    public void CheckForChance()
    {
        int chance =  Random.Range(0, 100);
        if (conflictChance > chance)
        {
            StartConflict();
        }
    }

    public void StartConflict()
    {
    }

    private void OnValidate()
    {
        id = 0;
        name = transform.name;
        conflictChance = Random.Range(0, 100);
        aidHelp = Random.Range(0, 1f);
        militaryHelp = Random.Range(0, 1f);
        reliefHelp = Random.Range(0, 1f);
        initialConflictValue = Random.Range(0, 1f);
    }
}
