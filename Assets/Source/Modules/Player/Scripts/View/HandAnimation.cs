using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class HandAnimation : MonoBehaviour
{
    private const string GRIP_KEY = "Grip";
    private const string TRIGGER_KEY = "Trigger";

    [SerializeField] private InputActionReference _gripReference;
    [SerializeField] private InputActionReference _triggerReference;

    private Animator _animator;

    private void Awake() => _animator = GetComponent<Animator>();

    private void Update()
    {
        float gripValue = _gripReference.action.ReadValue<float>();
        _animator.SetFloat(GRIP_KEY, gripValue);

        float triggerValue = _triggerReference.action.ReadValue<float>();
        _animator.SetFloat(TRIGGER_KEY, triggerValue);
    }
}
