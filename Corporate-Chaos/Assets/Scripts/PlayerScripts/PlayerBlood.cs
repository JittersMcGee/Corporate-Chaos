using UnityEngine;

public class PlayerBlood : MonoBehaviour
{
    int blood = 0;

    public int Blood
    {
        get { return blood; }
    }

    public void AddBlood(int value)
    {
        blood += value;
    }
}
