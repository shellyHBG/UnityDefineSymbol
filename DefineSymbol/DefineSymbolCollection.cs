using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Builder.DefineSymbol
{ 
    public class DefineSymbolCollection
    {
        private List<string> _listSymbols;
        ISymbolProvider _iSymbolProvider;

        public DefineSymbolCollection(ISymbolProvider symbolProvider)
        {
            _iSymbolProvider = symbolProvider;
            loadFromString(symbolProvider.GetCurrentSymbols());
        }

        public void Add(string symbol)
        {
            if (!_listSymbols.Contains(symbol))
            {
                _listSymbols.Add(symbol);
                saveSymbols();
            }
        }

        public void Remove(string symbol)
        {
            _listSymbols.RemoveAll(x => x == symbol);
            saveSymbols();
        }

        private void loadFromString(string raw)
        {
            _listSymbols = raw.Split(';')
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .Distinct()
                                    .ToList();
        }

        private void saveSymbols()
        {
            string szSymbols = string.Join(";", _listSymbols);
            Debug.Log($"Save define symbols: {szSymbols}");
            _iSymbolProvider.SetCurrentSymbols(szSymbols);
        }
    }
}
