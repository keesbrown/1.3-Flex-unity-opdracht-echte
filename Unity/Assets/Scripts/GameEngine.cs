using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class GameEngine : MonoBehaviour
{
    public GameObject pigModel;
    public GameObject tileModel;
    public GameObject towerModel;

    private Tower tower;
    private Enemy enemy;
    private GameObject[] path;

    private int currentPathIndex = 0;

    void Start()
    {
        int x = 0;
        int z = 0;
        int size = 2;
            
        RelAdd[] pathplus = new RelAdd[] {

            new RelAdd() {x=0,z=0 },
            new RelAdd() {x=0,z=1 },
            new RelAdd() {x=1,z=0},
            new RelAdd() {x=1,z=0},
            new RelAdd() {x=1,z=0},
            new RelAdd() {x=0,z=-1 },
            new RelAdd() {x=0,z=-1 },
            new RelAdd() {x=0,z=-1 },
            new RelAdd() {x=1,z=0},
            new RelAdd() {x=1,z=0},
            new RelAdd() {x=1,z=0},
        };
        path = new GameObject[pathplus.Length];
        
        for (int i = 0; i < pathplus.Length; i++)
        {
            RelAdd step = pathplus[i];
            x += step.x * size;
            z += step.z *size;
            path[i] = Instantiate(tileModel, new Vector3(x, 0, z), Quaternion.identity);
        }
    
        
        
        GameObject enemyStart = path[0];
        GameObject enemyObj = Instantiate(pigModel, enemyStart.transform.position, Quaternion.identity);
        enemy = new Enemy(enemyObj);
        enemy.from = 0;
        enemy.to = 1;

        
        GameObject towerPlace = path[4];
        GameObject onTile = Instantiate(tileModel, towerPlace.transform.position + new Vector3(0, 0, 2), Quaternion.identity);
        GameObject towerObj = Instantiate(towerModel, onTile.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
        tower = new Tower(towerObj, 5, onTile);
    }
    
    private double GetDist(GameObject a, GameObject b)
    {
        float dx = a.transform.position.x - b.transform.position.x;
        float dy = a.transform.position.y - b.transform.position.y;
        float dz = a.transform.position.z - b.transform.position.z;


        float powered = (dx * dx) + (dy * dy) + (dz * dz);
        double dist = Math.Sqrt(powered);
        Debug.Log(dist);
        return dist;
    }

    private void MoveEnemy(Enemy enemy)
    {
        if (enemy.to >= path.Length)
        {
            return;
        }

        GameObject from = path[enemy.from];
        GameObject to = path[enemy.to];


        float dx = to.transform.position.x - from.transform.position.x;
        float dy = to.transform.position.y - from.transform.position.y;
        float dz = to.transform.position.z - from.transform.position.z;

        Debug.Log(dx + " " + dy + " " + dz);
        
        enemy.obj.transform.position += new Vector3(dx, dy, dz) * Time.deltaTime;

        double dist = GetDist(enemy.obj, to);
        Debug.Log(dist);

        if (dist <= 0.01)
        {
            Debug.Log("goto next!");
            enemy.from++;
            enemy.to++;
            enemy.obj.transform.position = to.transform.position;
            
        }
    }

    void Update()
    {
        if (GetDist(tower.obj, enemy.obj) <= tower.detectRange)
        {
            Debug.Log("near!");
        }
        MoveEnemy(enemy);
    }
}