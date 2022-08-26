using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Cards : MonoBehaviour
{
    [SerializeField]
    ChanceCard[] chanceDeck;
    [SerializeField]
    FacultyCard[] degreeDeck;

}
public class ChanceCard
{
    string name;
    GameObject prefab;
    bool choice;
    bool holdable;
    Vector3 modifiers;
    int specialFunction;

    ChanceCard(string Name, GameObject Prefab, bool Choice, bool Holdable, Vector3 Modifiers)
    {
        this.name = Name;
        this.prefab = Prefab;
        this.choice = Choice;
        this.holdable = Holdable;
        this.modifiers = Modifiers;
    }
    ChanceCard(string Name, GameObject Prefab, bool Choice, bool Holdable, int SpecialFunction)
    {
        this.name = Name;
        this.prefab = Prefab;
        this.choice = Choice;
        this.holdable = Holdable;
        this.specialFunction = SpecialFunction;
    }

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

public class FacultyCard
{
    string name;
    Vector3 modifiers;

    FacultyCard(string Name, Vector3 Modifiers)
    {
        this.name = Name;
        this.modifiers = Modifiers;
    }
}
