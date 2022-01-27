using System;
using UnityEngine;

public static class LayerId
{
    public static class Character
    {
        public static readonly int BackId;

        public static readonly int MiddleId;

        public static readonly int FrontId;

        static Character()
        {
            BackId = GetLayersId(Constant.Layer.CharactersBack);
            MiddleId = GetLayersId(Constant.Layer.CharactersMiddle);
            FrontId = GetLayersId(Constant.Layer.CharactersFront);
        }
    }

    private static int GetLayersId(string layerName)
    {
        var id = SortingLayer.NameToID(layerName);

        if (id == 0)
            throw new ArgumentException($"Can't find layer with name {layerName}", nameof(layerName));

        return id;
    }
}
