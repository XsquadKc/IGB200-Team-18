using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cards : MonoBehaviour
{

}
[System.Serializable]
public struct ChanceCard
{
    public string name;
    public GameObject prefab;
    public bool choice;
    public bool holdable;
    public Modifier modifiers;
    public int specialFunction;

    public void AddToHand()
    {

    }

    public void SpecialFunction(int functionID)
    {
        if (functionID == 0)
        {
            return;
        }
    }
}
[System.Serializable]
public struct FacultyCard
{
    public string name;
    public Modifier modifiers;

}
[System.Serializable]
public struct Modifier
{
    public float S;
    public float E;
    public float K;
}
