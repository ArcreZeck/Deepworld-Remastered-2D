using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public GameObject objectHolder;
    public GameObject block;
    public Camera publicCamera;

    public int width;
    public int height;

    public bool useRandomSeed;
    public string seed;

    int[,] map;

    [Range(0, 100)]
    public int groundPercentage;

    void Start()
    {
        GenerateMap();
        if (map != null) {
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    Vector3 pos = new Vector3(-width / 2 + x + 0.5f, -height / 2 + y + 0.5f, objectHolder.transform.position.y - 1f);
                    if (IsVisible(pos, Vector3.one, publicCamera)) {
                        Debug.Log("Test");
                        ObjectPooler.Instance.SpawnFromPool("Earth", pos, objectHolder.transform.rotation);
                    }
                }
            } 
        }
    }

    public void GenerateMap()
    {
        map = new int[width, height];
        RandomFillMap();
        for (var i = 0; i < 2; i++)
        {
            SmoothMapGeneration();
        }
    }

    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = Time.time.ToString();
        }
        System.Random randomNumberGen = new System.Random(seed.ToString().GetHashCode());
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                } else {
                    map[x, y] = (randomNumberGen.Next(0, 100) < groundPercentage)? 1 : 0;
                }
            }
        }
    }

    void SmoothMapGeneration()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++) 
            {
                int neighborWalls = returnSurrounding(x, y);
                if (neighborWalls > 4) 
                {
                    map[x, y] = 1;
                }
                else if (neighborWalls < 4) 
                {
                    map[x, y] = 0;
                }
            }
        }
    }

    int returnSurrounding(int x, int y) 
    {
        int wallCount = 0;
        for (int neighX = x - 1; neighX <= x + 1; neighX++) 
        {
            for (int neighY = y - 1; neighY <= y + 1; neighY++) 
            {
                if (neighX >= 0 && neighX < width && neighY >= 0 && neighY < height) 
                {
                    if (neighX != x || neighY != y) 
                    {
                        wallCount += map[neighX, neighY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }
        return wallCount;
    }

    void OnDrawGizmos() 
    {
        if (map != null) 
        {
            for (int x = 0; x < width; x++) 
            {
                for (int y = 0; y < height; y++) 
                {
                    Gizmos.color = (map[x, y] == 1)? Color.white : Color.clear;
                    Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
                    Gizmos.matrix = rotationMatrix;
                    Vector3 pos = new Vector3(-width / 2 + x + 0.5f, objectHolder.transform.position.y - 1f, -height / 2 + y + 0.5f);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }

    bool IsVisible(Vector3 pos, Vector3 boundSize, Camera camera)
    {
        var bounds = new Bounds(pos, boundSize);
        var planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, bounds);
    }
}
