using Services.Progress;
using UnityEngine;

public class HealthView : MonoBehaviour
{
    private ProgressService _progress;
    
    public void Construct(ProgressService progress)
    {
        _progress = progress;
    }
}
