using UnityEngine;

public class UIManager : MonoBehaviour
{
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

    private void Render()
    {

    }

}
