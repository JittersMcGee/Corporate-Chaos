using UnityEngine;

public class PlayerMonies : MonoBehaviour
{
    int monies;

    public int Monies
    {
        get { return monies; }
    }
    
    public void AddMonies(int value)
    {
        monies += value;
    }
}
