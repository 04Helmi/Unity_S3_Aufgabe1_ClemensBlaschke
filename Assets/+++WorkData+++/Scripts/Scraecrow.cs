using UnityEngine;

public class Scraecrow : MonoBehaviour
{
    [SerializeField] GameObject Indicator;
    public bool canBeInteracted;

    private void Awake()
    {
        canBeInteracted = false;
    }
    private void Update()
    {
        if (canBeInteracted)
        {
            Indicator.SetActive(true);
        }
        else
        {
            Indicator.SetActive(false);
        }
    }
}
