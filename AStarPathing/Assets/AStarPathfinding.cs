using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AStarPathfinding : MonoBehaviour
{
    public Pixel pixel;
    public Canvas can;
    public RectTransform screen;
    int width = 7;
    int height = 7;

    Vector2Int startPosition = new Vector2Int(0,0);
    Vector2Int targetPosition = new Vector2Int(4,6);

    public Pixel[,] pixels;

    // Start is called before the first frame update
    void Start()
    {
        Transform t = gameObject.transform;
        Vector3 offset = new Vector3(-400, -400);

        pixels = new Pixel[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                t.position = offset + new Vector3(x * 110, y * 110, 0);
                pixels[x, y] = Instantiate(pixel, t.position, Quaternion.identity);
                pixels[x, y].transform.SetParent(screen, false);
                pixels[x, y].x = x;
                pixels[x, y].y = y;

            }
        }

        pixels[startPosition.x, startPosition.y].GetComponent<Image>().color = new Color(0.2f, 0.2f, 1f, 1f);
        pixels[targetPosition.x, targetPosition.y].GetComponent<Image>().color = new Color(0.5f, 0f, 1f, 1f);

        SetupEnvironment();

        CalculateAStar();
        //Transform t = gameObject.transform;
        //t.position = new Vector3(100, 100, 0);
        //GameObject g = Instantiate(pixel, t.position, Quaternion.identity);
        //g.transform.SetParent(can.transform, false);
    }

    void SetupEnvironment()
    {
        for(int i = 0; i < 4; i++)
        {
            Pixel go = pixels[2 + i, 2];
            go.GetComponent<Pixel>().isObstacle = true;
            go.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
        }

        for (int i = 0; i < 4; i++)
        {
            Pixel go = pixels[1, 3+i];
            go.GetComponent<Pixel>().isObstacle = true;
            go.GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
        }
    }

    bool CalculateAStar()
    {
        List<Pixel> openList = new List<Pixel>();
        List<Pixel> closedList = new List<Pixel>();

        pixels[startPosition.x, startPosition.y].gCost = 0;
        pixels[startPosition.x, startPosition.y].fCost = 0;
        openList.Add(pixels[startPosition.x, startPosition.y]);

        while(openList.Count > 0)
        {
            openList.Sort(SortByFCost);
            Pixel current = openList[0];
            openList.RemoveAt(0);

            if (current.x == targetPosition.x && current.y == targetPosition.y)
            {
                Debug.Log("Path found!");
                pixels[startPosition.x, startPosition.y].GetComponent<Image>().color = new Color(0.2f, 0.2f, 1f, 1f);
                pixels[targetPosition.x, targetPosition.y].GetComponent<Image>().color = new Color(0.5f, 0f, 1f, 1f);

                Pixel temp = pixels[targetPosition.x, targetPosition.y].predecessor;
                while (temp != null && temp != pixels[startPosition.x, startPosition.y])
                {
                    temp.GetComponent<Image>().color = new Color(1f, 1f, 0.1f, 1f);
                    temp = temp.predecessor;
                }
                return true;
            }

            closedList.Add(current);
            current.GetComponent<Image>().color = new Color(1f, 0.2f, 0.2f, 1f);

            List<Pixel> neighbours = getNeighbours(current);
            if(current.x == 4 && current.y == 5)
            {
                Debug.Log(neighbours);
            }
            foreach(Pixel p in neighbours)
            {
                if(closedList.Contains(p))
                {
                    continue;
                }

                float currentGCost = current.gCost + 1f;

                if (openList.Contains(p) && p.gCost <= currentGCost)
                {
                    continue;
                }
                p.gCost = currentGCost;
                p.setCurrent(p.gCost);
                p.hCost = ManhattenDist(p.x, p.y, targetPosition.x, targetPosition.y);
                p.setEstimated(p.hCost);
                p.fCost = p.gCost + p.hCost;
                p.setMinimum(p.fCost);
                p.predecessor = current;
                openList.Add(p);
                p.GetComponent<Image>().color = new Color(0.2f, 1f, 0.2f, 1f);
            }
        }
        
        Debug.Log("No Path found!");
        return false;
    }

    int ManhattenDist(int x1, int y1, int x2, int y2)
    {
        return Mathf.Abs(x1 - x2) + Mathf.Abs(y1 - y2);
    }

    List<Pixel> getNeighbours(Pixel p)
    {
        List<Pixel> result = new List<Pixel>();

        if(p.x > 0 && !pixels[p.x - 1, p.y].isObstacle)
        {
            result.Add(pixels[p.x - 1, p.y]);
        }

        if (p.y > 0 && !pixels[p.x, p.y - 1].isObstacle)
        {
            result.Add(pixels[p.x, p.y-1]);
        }

        if (p.x < width-1 && !pixels[p.x + 1, p.y].isObstacle)
        {
            result.Add(pixels[p.x + 1, p.y]);
        }

        if (p.y < height-1 && !pixels[p.x, p.y + 1].isObstacle)
        {
            result.Add(pixels[p.x, p.y + 1]);
        }

        return result;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static int SortByFCost(Pixel p1, Pixel p2)
    {
        return p1.fCost.CompareTo(p2.fCost);
    }
}
