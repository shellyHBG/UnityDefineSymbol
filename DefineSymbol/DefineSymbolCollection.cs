using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Builder.DefineSymbol
{ 
    public class DefineSymbolCollection
    {
        private List<string> _listSymbols;
        private ISymbolProvider _iSymbolProvider;

        public DefineSymbolCollection(ISymbolProvider inSymbolProvider)
        {
            _iSymbolProvider = inSymbolProvider;
            LoadFromString(inSymbolProvider.GetCurrentSymbols());
        }

        public void Add(string inSymbol)
        {
            if (!_listSymbols.Contains(inSymbol))
            {
                _listSymbols.Add(inSymbol);
                SaveSymbols();
            }
        }

        public void Remove(string inSymbol)
        {
            _listSymbols.RemoveAll(x => x == inSymbol);
            SaveSymbols();
        }

        private void LoadFromString(string inRaw)
        {
            _listSymbols = inRaw.Split(';')
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .Distinct()
                                    .ToList();
        }

        private void SaveSymbols()
        {
            string symbols = string.Join(";", _listSymbols);
            Debug.Log($"Save define symbols: {symbols}");
            _iSymbolProvider.SetCurrentSymbols(symbols);
        }
    }
}
