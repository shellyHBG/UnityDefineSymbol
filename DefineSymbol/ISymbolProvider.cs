namespace Builder.DefineSymbol
{
    public interface ISymbolProvider
    {
        string GetCurrentSymbols();
        void SetCurrentSymbols(string inSymbols);
    }
}
