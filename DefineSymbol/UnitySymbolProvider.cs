using System;
using UnityEditor;

namespace Builder.DefineSymbol
{
    public class UnitySymbolProvider : ISymbolProvider
    {
        private BuildTargetGroup _buildGroup;

        public UnitySymbolProvider()
        {
            // get build group: by platform
            _buildGroup = BuildPipeline.GetBuildTargetGroup(EditorUserBuildSettings.activeBuildTarget);
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

        void ISymbolProvider.SetCurrentSymbols(string inSymbols)
        {
            if (_buildGroup == BuildTargetGroup.Unknown)
            {
                throw new NotSupportedException($"Unknown buildGroup={_buildGroup}");
            }
            PlayerSettings.SetScriptingDefineSymbolsForGroup(_buildGroup, inSymbols);
        }
        #endregion
    }
}
