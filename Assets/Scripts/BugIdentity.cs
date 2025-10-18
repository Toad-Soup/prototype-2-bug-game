using System;
using System.Linq;
using UnityEngine;

public class BugIdentity : MonoBehaviour
{
    public string bugName;
    public string spouseName;
    public string[] children;
    public string nature;

    void Start()
    {
        bugName = BugDataLoader.Instance.GetRandomName();
        spouseName = BugDataLoader.Instance.GetSpouse();
        children = BugDataLoader.Instance.GetChildren();
        nature = BugDataLoader.Instance.GetRandomNature();
    }

    public string GetDescription()
    {
        // basic for now, could make nicer/separate functions so name can be bolder
        return $"{bugName}\n\n" +
               $"Mate: {spouseName}\n"+
               $"Parent to: {string.Join(", ", children)}\n"+
               $"Personality: {nature} \n";
    }

}
