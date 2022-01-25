using UnityEngine;

public static class LayerId
{
    public static class Character
    {
        public static int BackId = SortingLayer.NameToID(Constant.Layer.CharactersBack);

        public static int MiddleId = SortingLayer.NameToID(Constant.Layer.CharactersMiddle);

        public static int FrontId = SortingLayer.NameToID(Constant.Layer.CharactersFront);
    }
}
