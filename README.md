# Kogane IEnumerable Peek Debug Log Extension Methods

LINQ の中間操作で要素を Debug.Log できる拡張メソッド

## 使用例

```csharp
using System.Linq;
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Awake()
    {
        var list = new[]
        {
            "フシギダネ",
            "フシギソウ",
            "フシギバナ",
        };

        var r1 = list.PeekDebugLog().ToArray();
        var r2 = list.PeekDebugLog( x => $"名前：{x}" ).ToArray();
        var r3 = list.PeekDebugLogWarning().ToArray();
        var r4 = list.PeekDebugLogWarning( x => $"名前：{x}" ).ToArray();
        var r5 = list.PeekDebugLogError().ToArray();
        var r6 = list.PeekDebugLogError( x => $"名前：{x}" ).ToArray();
    }
}
```