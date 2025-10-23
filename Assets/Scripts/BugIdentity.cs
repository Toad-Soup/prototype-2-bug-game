using System;
using System.Linq;
using UnityEngine;

//store bug identity information

public class BugIdentity : MonoBehaviour
{
    public string bugName;
    public string spouseName;
    public string[] children;
    [SerializeField] public string nature;
   

    void Start()
    {
        bugName = BugDataLoader.Instance.GetRandomName();
        spouseName = BugDataLoader.Instance.GetSpouse();
        children = BugDataLoader.Instance.GetChildren();
        if (string.IsNullOrEmpty(nature))
            nature = BugDataLoader.Instance.GetRandomNature();
    }

    public string GetDescription()
    {
        // basic for now, could make nicer/separate functions for formatting
        return $"{bugName}\n\n" +
               $"Mate: {spouseName}\n"+
               $"Parent to: {string.Join(", ", children)}\n"+
               $"Personality: {nature} \n";
    }

}
