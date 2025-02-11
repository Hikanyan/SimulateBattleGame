using System.Collections.Generic;
public static class PrefabKeys
{
    private static readonly Dictionary<string, string> PrefabPathDictionary = new Dictionary<string, string>()
    {
        { Character, "Assets/HikanyanLaboratory/UISystem/Resources/Character.prefab" },
        { SampleList, "Assets/HikanyanLaboratory/UISystem/Resources/SampleList.prefab" },
    };

    public const string Character = "Character";
    public const string SampleList = "SampleList";
    public static IEnumerable<string> GetAllKeys()
    {
        return PrefabPathDictionary.Keys;
    }
}