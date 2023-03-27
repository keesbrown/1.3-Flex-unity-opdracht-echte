using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//class make oefening
public class Tower
{
//maak hier public class variables:
	//1  (acces=public, Type= GameObject, name=obj)
    public GameObject obj;
	//2 (acces=public, Type= GameObject, name=onTile)
    public GameObject onTile;
	//3 (acces=public, Type= float, name=detectRange)
    public float detectRange;

	//verander hier iets zodat je alle variablen mee kan geven aan de constructor
	//volgorde: obj, detectRange,onTile
    public Tower(GameObject obj, float detectRange, GameObject onTile)
    {
        this.obj = obj;
        this.detectRange = detectRange;
        this.onTile = onTile;
    }
}
