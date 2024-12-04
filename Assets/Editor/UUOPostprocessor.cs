using System;
using System.IO;
using UnityEditor;
using UnityEngine;

public class UUOPostprocessor : AssetPostprocessor
{
    private void OnPostprocessAnimation(GameObject root, AnimationClip clip)
    {
        var animationfoler = "Assets/RawUnityResources/Animations/";
        if (!Directory.Exists(animationfoler))
            Directory.CreateDirectory(animationfoler);
        AssetDatabase.CreateAsset(clip, $"{animationfoler}{root.name}");
        Debug.Log($"animataion ani created:{root.name}");
    }

    // private void OnPostprocessModel(GameObject g)
    // {
    //     // var animationfoler = "Assets/RawUnityResources/Animations/";
    //     // if (!Directory.Exists(animationfoler))
    //     //     Directory.CreateDirectory(animationfoler);
    //     // if (assetPath.ToLower().EndsWith(".fbx"))
    //     // {
    //     //     var aniname = Path.GetFileNameWithoutExtension(assetPath);
    //     //     var animationClips = AnimationUtility.GetAnimationClips(g);
    //     //     foreach (var clip in animationClips)
    //     //     {
    //     //         AssetDatabase.CreateAsset(clip, $"{animationfoler}/{clip.name}/.ani");
    //     //         Debug.Log($"animataion ani created:{clip.name}");
    //     //     }
    //     // }
    // }

    // private void OnPreprocessAnimation()
    // {
    //     // var assetani = assetImporter;
    //     // Debug.Log($"pre animation process :{assetani.name}");
    // }
}
