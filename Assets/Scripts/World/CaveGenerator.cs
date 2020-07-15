using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    public GameObject parent;

    public string seed;
    public bool seedIsRandom;
    public int width;
    public int height;

    private int[,] cavePoints;

    [Range(0,100)]
    public int randFillPercent;

    private void Awake() {
        GenerateCave();
        for (var i = 0; i < 3; i++)
        {
            SmoothMapGeneration();
        }
    }

    void Start()
    {
        RenderGrid();
    }

    private void GenerateCave() {
        cavePoints = new int[width, height];

        if (seedIsRandom == true) {
            seed = Random.Range(0, 1000000).ToString();
        }

        System.Random randChoice = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (randChoice.Next(0, 100) < randFillPercent) {
                    cavePoints[x, y] = 1;
                } else {
                    cavePoints[x, y] = 0;
                }
            }
        }
    }

    private void RenderGrid() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (cavePoints[x, y] == 1) {
                    ObjectPooler.Instance.SpawnFromPool("Block", new Vector3(((-width / 2 + x) + 10) * 102.4f, (-height + y - 10) * 102.4f, 1f));
                }
            }
        }
    }

    void SmoothMapGeneration() {
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                int neighborWalls = returnSurrounding(x, y);
                if (neighborWalls > 4) {
                    cavePoints[x, y] = 1;
                } else if (neighborWalls < 4) {
                    cavePoints[x, y] = 0;
                }
            }
        }
    }

    int returnSurrounding(int x, int y) {
        int wallCount = 0;
        for (int neighX = x - 1; neighX <= x + 1; neighX++) {
            for (int neighY = y - 1; neighY <= y + 1; neighY++) {
                if (neighX >= 0 && neighX < width && neighY >= 0 && neighY < height) {
                    if (neighX != x || neighY != y) {
                        wallCount += cavePoints[neighX, neighY];
                    }
                } else {
                    wallCount++;
                }
            }
        }
        return wallCount;
    }

    bool IsVisible(Vector3 pos, Vector3 boundSize, Camera camera) {
        var bounds = new Bounds(pos, boundSize);
        var planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}
