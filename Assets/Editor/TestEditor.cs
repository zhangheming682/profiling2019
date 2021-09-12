using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.Profiling.Memory.Experimental;

static class TestEditor
{
    // Start is called before the first frame update
    [MenuItem("Test/Take Snap")]
    static void TakeSnap()
    {
        //MemoryProfiler.SnapshotFinished
        MemorySnapshot.RequestNewSnapshot();
        MemorySnapshot.OnSnapshotReceived += MemorySnapshot_OnSnapshotReceived;
        //MemoryProfiler.createMetaData = 

    }

    private static void MemorySnapshot_OnSnapshotReceived(PackedMemorySnapshot packedSnapshot)
    {
        //var nativeObjects = packedSnapshot.nativeObjects.Select(packedNativeUnityEngineObject => UnpackNativeUnityEngineObject(packedSnapshot, packedNativeUnityEngineObject)).ToArray();

        //Debug.Log("~~~~~~~~~~~~~nativeType begin~~~~~~~~~~~~~~~~~~~");
        //foreach (var nativeType in obj.nativeTypes)
        //{
            
        //    Debug.Log($"nativeType  {nativeType} name {nativeType.name}");
        //}
        //Debug.Log("~~~~~~~~~~~~~nativeType end~~~~~~~~~~~~~~~~~~~");

        //Debug.Log("~~~~~~~~~~~~~nativeObject begin~~~~~~~~~~~~~~~~~~~");
        //foreach (var nativeObject in obj.nativeObjects)
        //{
        //    Debug.Log($"nativeObject  {nativeObject} name {nativeObject.name}");
        //}
        //Debug.Log("~~~~~~~~~~~~~nativeObject end~~~~~~~~~~~~~~~~~~~");


        //throw new System.NotImplementedException();
    }
}
