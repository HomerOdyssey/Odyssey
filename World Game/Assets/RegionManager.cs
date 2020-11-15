using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionManager : MonoBehaviour
{
    private Region[] regions;


    // Start is called before the first frame update
    private void Start()
    {
        regions = GetComponentsInChildren<Region>();
    }

    public float CalculateAverageQuality()
    {
        float average = 0;
        foreach (var region in regions)
        {
           average +=  region.GetQuality();
        }
        return average / regions.Length;
    }
    public float CalculateAverageStability()
    {
        float average = 0;
        foreach (var region in regions)
        {
            average += region.GetStability();
        }
        return average / regions.Length;
    }
}
