using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy
{
//maak hier public class variables:
	//1 (acces=public, Type= GameObject, name=obj)
    public GameObject obj;
	//2 (acces=public, Type= int, name=from)
    public int from;
	//3 (acces=public, Type= int, name=to)
    public int to;

    public Enemy(GameObject obj)//verander hier iets zodat je een GameObject met de constructor kan meegeven
    {
        this.obj = obj;
		this.from=0;
		this.to=0;
    }
}