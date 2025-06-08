using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class ItemDataPostprocessor :AssetPostprocessor
{
    
    //공부&테스트용 자동 삭제
    private static void OnPostprocessAllAssets(
        string[] importedAssets, string[] deletedAssets, 
        string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string deletedPath in deletedAssets)
        {
            if (deletedPath.StartsWith("Assets/ItemsData") && deletedPath.EndsWith(".asset"))
            {
                string fileName = Path.GetFileNameWithoutExtension(deletedPath);
                string jsonPath=Path.Combine(Application.persistentDataPath, "ItemJson" ,$"{fileName}.json");

                if (File.Exists(jsonPath))
                {
                    File.Delete(jsonPath);
                    Debug.Log($"deleted file {jsonPath}");
                }
            }
        }
    }
}
