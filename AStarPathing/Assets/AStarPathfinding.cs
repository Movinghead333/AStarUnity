using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarPathfinding : MonoBehaviour
{
    public Pixel p;
    public GameObject pixel;
    public Canvas can;
    int width = 8;
    int height = 8;

    public GameObject[,] pixels;

    // Start is called before the first frame update
    void Start()
    {
        Transform t = gameObject.transform;
        Vector3 offset = new Vector3(-400, -400);

        pixels = new GameObject[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                t.position = offset + new Vector3(x * 110, y * 110, 0);
                pixels[x, y] = Instantiate(pixel, t.position, Quaternion.identity);
                pixels[x, y].transform.SetParent(can.transform, false);
            }
        }

        //Transform t = gameObject.transform;
        //t.position = new Vector3(100, 100, 0);
        //GameObject g = Instantiate(pixel, t.position, Quaternion.identity);
        //g.transform.SetParent(can.transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
