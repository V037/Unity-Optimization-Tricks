using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//credits: V.037_

public class FinalOpti : MonoBehaviour
{
//set always as private your variables for gain some perfomances by hiding them to other scripts, if you want read the variable in the inspector use [SerializeField]
    [SerializeField] private int uncappedNum = 300; //you can modify the number adding what you want to target as fps

    void Awake()
    {
        //normally it is suggested to use awake only for initialize variable,
        //but here we want to be sure to block Unintentional debug.logging from the very start
        notDebugAnymore();
    }

    void Start()
    {
        fpsUncapper();  
    }

    private void fpsUncapper()
    {
        //IMPORTANT: your application must have v-sync off
        Application.targetFrameRate = uncappedNum;  //disable the limit from 60fps to uncappedNum
    }

    private void notDebugAnymore()
    {
#if UNITY_EDITOR
        Debug.unityLogger.logEnabled = true;    //if we are inside the unity editor the debug.logger will always stay on
#else
        Debug.unityLogger.logEnabled = false;   //in the built game we make sure that's disabled for gain some perfomances
#endif                                          //if you also need to debug the build version I suggest then to set this syntax as a comment
    }
}
