using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;

public class Builder 
{
    static void PerformBuild()
    {
        // Setup Build Options (refer to build page for details)
        var options = new BuildPlayerOptions();
        options.scenes = new string[] { "Assets/Main/Main.unity" };
        options.target = BuildTarget.StandaloneWindows64;

        /*  To get command line argument, use the following. 
            However, since all argument will be included, be careful scanning your documents
        */
        var args = Environment.GetCommandLineArgs();

        var idx = Array.FindIndex(args, x => x.ToLower() == "-buildpath");
        if (idx < 0 || idx+1 >= args.Length)
        {
            Debug.Log("-buildPath not found!");
            EditorApplication.Exit(1);
        }
        options.locationPathName = args[idx+1];

        // Build binary as headless (console)
        options.options = BuildOptions.EnableHeadlessMode;
        if (Array.FindIndex(args, x => x.ToLower().Contains("-debug"))>=0)
        {
            Debug.Log("Adding Debug BuildOptions.");
            // Development environment
            options.options |= BuildOptions.Development;
            // Allow attaching debugger (breakpoint and stuffs)
            options.options |= BuildOptions.AllowDebugging;
        }

        var result = BuildPipeline.BuildPlayer(options);

        if (result.summary.result == BuildResult.Succeeded)
            Debug.Log("Build Success!");
        else
            EditorApplication.Exit(1);
    }
    
}
