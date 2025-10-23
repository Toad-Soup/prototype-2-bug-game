using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;

// get info from the json file

[System.Serializable]
public class BugDataContainer
{
    public List<BugDataEntry> bugs;
}

[System.Serializable]
public class BugDataEntry
{
    public List<string> names;
    public List<string> natures;
}

public class BugDataLoader : MonoBehaviour
{
    public static BugDataLoader Instance;
    private BugDataEntry data;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        TextAsset jsonFile = Resources.Load<TextAsset>("bugData");
        BugDataContainer container = JsonUtility.FromJson<BugDataContainer>(jsonFile.text);
        data = container.bugs[0];
    }

    // functions for retrieving random info

    public string GetRandomName() => data.names[Random.Range(0, data.names.Count)];
    public string GetRandomNature() => data.natures[Random.Range(0, data.natures.Count)];

    public string GetSpouse() => data.names[Random.Range(0, data.names.Count)];

    public string[] GetChildren()
    {
        List<string> children = new List<string>();
        int count = Random.Range(1, 6);
        while (children.Count < count)
        {
            string childName = data.names[Random.Range(0, data.names.Count)];
            if (!children.Contains(childName)) children.Add(childName);
        }

        return children.ToArray();
    }
}
