using UnityEngine;

public class DisableRendererOnPlay : MonoBehaviour
{
    [SerializeField] private Renderer _renderer;
    void Start()
    {
        _renderer.enabled = false;
    }
}
