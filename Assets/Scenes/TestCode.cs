using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Profiling.Memory.Experimental;

public class TestCode : MonoBehaviour
{
    // Start is called before the first frame update
    int _count = 0;
    void Start()
    {
        UnityEngine.Profiling.Memory.Experimental.MemoryProfiler.createMetaData += CollectMetadata;

        /*Profiler.maxUsedMemory = 256 * 1024 * 1024;
        Profiler.SetAreaEnabled(ProfilerArea.Memory, true);
        
        StopAllCoroutines();
        _count = 0;
        StartCoroutine(SaveProfilerData());*/
    }

    IEnumerator SaveProfilerData() {
        // keep calling this method until Play Mode stops
        while (true) {

            // generate the file path
            string filepath = Application.persistentDataPath + "/profilerLog" + _count;

            // set the log file and enable the profiler
            Profiler.logFile = filepath;
            Profiler.enableBinaryLog = true;
            Profiler.enabled = true;


            // count 300 frames
            for(int i = 0; i < 300; ++i) {

                yield return new WaitForEndOfFrame();

                // workaround to keep the Profiler working
                if (!Profiler.enabled)
                    Profiler.enabled = true;
                
            }

            // start again using the next file name
            _count++;
        }
    }

    public void MyStartProfiling()
    {
        Profiler.maxUsedMemory = 256 * 1024 * 1024;
        Profiler.SetAreaEnabled(ProfilerArea.Memory, true);
        //Profiler.SetAreaEnabled(ProfilerArea.CPU, false);
        StopAllCoroutines();
        _count = 0;
        StartCoroutine(SaveProfilerData());
    }
    public void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 400, 80), "点这里！"))
        {
            //MyStartProfiling();
            MyTestMemory();
        }
        //throw new NotImplementedException();
    }

    public void MyTestMemory()
    {
        Action<string, bool> snapshotCaptureFunc = (string path, bool result) =>
        {
            Debug.Log("capture finish");
        };

        Debug.Log("capture begin");

        CaptureFlags captureFlags = CaptureFlags.ManagedObjects
                                    | CaptureFlags.NativeObjects
                                    | CaptureFlags.NativeAllocations
                                    | CaptureFlags.NativeAllocationSites
                                    | CaptureFlags.NativeStackTraces;

        string initTime = DateTime.Now.ToString("yyyyMMddHHmmss");
        string takeSnapshotPath = "d:/memorysnap/pc_" + initTime + ".snap";
        //QueryMemoryProfiler.TakeSnapshot(basePath, snapshotCaptureFunc, m_CaptureFlags);
        UnityEngine.Profiling.Memory.Experimental.MemoryProfiler.TakeSnapshot(takeSnapshotPath, snapshotCaptureFunc, captureFlags);
    }
    public void CollectMetadata(MetaData data)
    {
        data.content = $"Project name: { Application.productName }";
        data.platform = string.Empty;
    }
    // Update is called once per frame
    void Update()
    {
        myTest();
    }

    public void myTest()
    {
        myTest2();
    }

    public void myTest2()
    {
        //Debug.Log("debuglogout");
    }
}
