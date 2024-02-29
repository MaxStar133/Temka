using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnValidateField();
public class Field : MonoBehaviour
{
    public const int Size = 50;

    [SerializeField] World world;
    public float Scale = 3f;
    public float seed = 3245f;

    public event OnValidateField onUp;
    void Start()
    {
        for (int x = -Size; x < Size; x++)
        {
           // Debug.Log(x + "x");
            for (int y = -Size; y < Size; y++)
            {
              //  Debug.Log(y + "y");
                Instantiate(world, transform).Set(x, y, this);
            }
        }
    }
    private void OnValidate()
    {
        onUp?.Invoke();
    }
}
