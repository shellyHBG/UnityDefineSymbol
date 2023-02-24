using Builder.DefineSymbol;
using UnityEditor;

public class TestDefineSymbol
{
    [MenuItem("Unit/Builder/DefineSymbols/Add sy1")]
    public static void Add_sy1()
    {
        ISymbolProvider symbol = new UnitySymbolProvider();

        DefineSymbolCollection collection = new DefineSymbolCollection(symbol);
        collection.Add("sy1");
    }

    [MenuItem("Unit/Builder/DefineSymbols/Remove sy1")]
    public static void Remove_sy1()
    {
        ISymbolProvider symbol = new UnitySymbolProvider();

        DefineSymbolCollection collection = new DefineSymbolCollection(symbol);
        collection.Remove("sy1");
    }
}
