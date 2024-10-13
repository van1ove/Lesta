using UnityEngine;

namespace Script.Utils
{
    public static class LayerMaskIndexContainer
    {
        public static readonly int Player = LayerMask.NameToLayer("Player");
        public static readonly int SpinningTrap = LayerMask.NameToLayer("SpinningTrap");
    }
}