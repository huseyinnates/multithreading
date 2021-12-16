using UnityEngine;
using Unity.Jobs;
using Unity.Collections;


public struct StructofJobs : IJob
{
    
    public void Execute()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            Mathf.Sqrt(Mathf.Pow(10f, 100_000) / 10_000_000f);
        }
    }
}


public class multithreading : MonoBehaviour
{
    public bool a = true;
    void Update()
    {
        if (a)
        {
            NativeList<JobHandle> jobhandler = new NativeList<JobHandle>(Allocator.Temp);
            for (int i = 0; i < 4; i++)
            {
                jobhandler.Add(new StructofJobs().Schedule());
            }

            JobHandle.CompleteAll(jobhandler);
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 1_000_000; a++)
                {
                    Mathf.Sqrt(Mathf.Pow(10f, 100_000) / 10_000_000f);
                }
            }
            
        }
       
        
        
    }
}
