using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    [SerializeField] List<Color> layers;
    [SerializeField] SpriteRenderer rend;

    int x;
    int y;
    Field field;
   public void Set(int _x, int _y, Field f)
    {
        x = _x;
        y = _y;
        field = f;
        field.onUp += UpdateState;  
        UpdateState();
    }

    void UpdateState()
    {
        transform.position = new Vector3(x, y, 0);
        
        float pnX = ((float)x + field.seed) / field.Scale;
        float pnY = ((float)y + field.seed) / field.Scale;

        float d = Mathf.PerlinNoise(pnX, pnY);
        int biome = Mathf.FloorToInt(d * layers.Count);

        biome = Mathf.Max(biome, 0);
        biome = Mathf.Min(biome, layers.Count - 1);

        rend.color = layers[biome];
    }
}
