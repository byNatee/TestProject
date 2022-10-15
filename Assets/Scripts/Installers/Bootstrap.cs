using Interactables;
using UI;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private InputFieldsReader _inputMenu;
    [SerializeField] private ObjectSpawner _spawner;
    [SerializeField] private ObjectsPool _pool;

    private void Start()
    {
        _spawner.SetPool(_pool);
        _inputMenu.FieldsChangeEvent += _spawner.OnFieldsChange;
    }
}
