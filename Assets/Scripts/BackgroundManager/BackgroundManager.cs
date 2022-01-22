using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _reference;

    private float _spriteWidth;

    private LinkedList<BackgroundStructure> _backgrounds = new LinkedList<BackgroundStructure>();


    private void Start()
    {
        CalculateSpriteWidth();

        GenerateBackgrounds();
    }

    private void FixedUpdate()
    {
        MoveBackgrounds();
    }

    private void GenerateBackgrounds()
    {
        // 4 backgrounds are optimal for movement algorithm
        for (int i = 0; i < 4; i++)
        {
            var newBackground = GameObject.Instantiate(_reference);
            newBackground.name = $"background{i}";
            newBackground.transform.position = new Vector3(
                _reference.transform.position.x + (_spriteWidth * i),
                _reference.transform.position.y,
                _reference.transform.position.z);

            _backgrounds.AddLast(new BackgroundStructure()
            {
                GameObjectInstance = newBackground,
                RendererInstance = newBackground.GetComponent<Renderer>()
            });
        }
    }

    private void CalculateSpriteWidth()
    {
        if (_reference == null)
            throw new NullReferenceException(nameof(_reference));
        var renderer = _reference.GetComponentInChildren<SpriteRenderer>();
        if (renderer == null)
            throw new NullReferenceException($"Can't get sprite renderer in child elements of {nameof(_reference)}");

        _spriteWidth = renderer.size.x;
    }

    private void MoveBackgrounds()
    {
        var first = _backgrounds.First();
        var last = _backgrounds.Last();

        if (last.RendererInstance.isVisible && !first.RendererInstance.isVisible)
        {
            first.GameObjectInstance.transform.position = new Vector3(
                last.GameObjectInstance.transform.position.x + _spriteWidth,
                last.GameObjectInstance.transform.position.y,
                last.GameObjectInstance.transform.position.z);

            _backgrounds.RemoveFirst();
            _backgrounds.AddLast(first);
        }
        else if (first.RendererInstance.isVisible && !last.RendererInstance.isVisible)
        {
            last.GameObjectInstance.transform.position = new Vector3(
                first.GameObjectInstance.transform.position.x - _spriteWidth,
                first.GameObjectInstance.transform.position.y,
                first.GameObjectInstance.transform.position.z);

            _backgrounds.RemoveLast();
            _backgrounds.AddFirst(last);
        }
    }
}
