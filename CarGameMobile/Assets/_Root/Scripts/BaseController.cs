using System;
using System.Collections.Generic;
using UnityEngine;

using Object = UnityEngine.Object;

internal abstract class BaseController : IDisposable
{
    private List<IDisposable> _disposables;
    private List<GameObject> _gameObjects;
    private bool _isDisposed;


    public void Dispose()
    {
        if (_isDisposed)
            return;

        _isDisposed = true;

        DisposeDisposables();
        DisposeGameObjects();

        OnDispose();
    }

    private void DisposeDisposables()
    {
        if (_disposables == null)
            return;

        foreach (IDisposable disposables in _disposables)
            disposables.Dispose();

        _disposables.Clear();
    }
    
    private void DisposeGameObjects()
    {
        if (_gameObjects == null)
            return;

        foreach (GameObject gameObject in _gameObjects)
            Object.Destroy(gameObject);

        _gameObjects.Clear();
    }

    protected virtual void OnDispose() { }


    protected void AddController(BaseController baseController) =>
        AddDisposable(baseController);

    protected void AddRepository(IRepository repository) =>
        AddDisposable(repository);

    private void AddDisposable(IDisposable disposable)
    {
        _disposables ??= new List<IDisposable>();
        _disposables.Add(disposable);
    }
    protected void AddGameObject(GameObject gameObject)
    {
        _gameObjects ??= new List<GameObject>();
        _gameObjects.Add(gameObject);
    }

    protected void Log(string message) =>
        Debug.Log(WrapMessage(message));

    protected void Error(string message) =>
        Debug.LogError(WrapMessage(message));

    private string WrapMessage(string message) =>
        $"[{GetType().Name}] {message}";

}
