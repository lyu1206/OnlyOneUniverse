using System;
using Battlehub.RTCommon;
using Battlehub.RTEditor.Models;
using Battlehub.Storage;
using UnityEditor;
using UnityEngine;

public class SerialTest : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    private async void Start()
    {
        await RuntimeAssetDatabase.Instance.LoadProjectAsync("Test");
        var datamodel = IOC.Resolve<IAssetDatabaseModel>("AssetDatabaseModel");
        var data = await datamodel.SerializeAsync(cube);
        var cubeobj = await datamodel.DeserializeAsync(data);
    }
}
