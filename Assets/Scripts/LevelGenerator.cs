using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    public float offset = 5f;
    public Material material01;
    public Material material02;

    void generateTile (int x, int z)
    {
        Color pixelcolor = map.GetPixel(x, z);

        if (pixelcolor.a == 0)
        {
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelcolor))
            {
                Vector3 position = new Vector3(x, 0, z) * offset;
                Instantiate(colorMapping.prefab, position, Quaternion.identity);
                GameObject prefab = Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);

            }
        }
    }
    public void generateLaberints()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int z = 0; z < map.height; z++)
            {
                generateTile(x,z);
            }
        }
    }
    public void colorChildren()
    {
        foreach(Transform child in transform)
        {
            if (child.tag == "wall")
            {
                if (Random.Range(1,100) % 3 == 0)
                {
                    child.gameObject.GetComponent<Renderer>().material = material01;
                }
                else
                {
                    child.gameObject.GetComponent<Renderer>().material = material02;
                }
            }
            if (child.childCount > 0)
            {
                foreach(Transform grandchild in child.transform)
                    if (Random.Range(1, 100) % 3 == 0)
                    {
                        child.gameObject.GetComponent<Renderer>().material = material01;
                    }
                    else
                    {
                        child.gameObject.GetComponent<Renderer>().material = material02;
                    }
            }
        }
    }
}
