using System;
using UnityEditor;

namespace Builder.DefineSymbol
{
    public class UnitySymbolProvider : ISymbolProvider
    {
        private BuildTargetGroup _buildGroup;

        public UnitySymbolProvider(BuildTargetGroup targetGroup)
        {
            _buildGroup = targetGroup;
        }

        #region implement ISymbolProvider
        string ISymbolProvider.GetCurrentSymbols()
        {
            if (_buildGroup == BuildTargetGroup.Unknown)
            {
                throw new NotSupportedException($"Unknown buildGroup={_buildGroup}");
            }
            return PlayerSettings.GetScriptingDefineSymbolsForGroup(_buildGroup);
        }

        void ISymbolProvider.SetCurrentSymbols(string szSymbols)
        {
            if (_buildGroup == BuildTargetGroup.Unknown)
            {
                throw new NotSupportedException($"Unknown buildGroup={_buildGroup}");
            }
            PlayerSettings.SetScriptingDefineSymbolsForGroup(_buildGroup, szSymbols);
        }
        #endregion
    }
}
