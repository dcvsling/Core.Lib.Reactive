# Simple Reactive

[![core-lib MyGet Build Status](https://www.myget.org/BuildSource/Badge/core-lib?identifier=869ce727-b882-4710-b8e3-5273fbfac910)](https://www.myget.org/feed/core-lib/package/nuget/Core.Lib.Decorator)

這是 Reactive Extensions 的基礎概念所建立的 Fluent Service Chain

這個專案存在的用意是希望能藉此專案來重新認識 Reactive Extensions 所能做到的事情


## How To Use


使用方式已經盡可能的與 Rx 用法相同, 並且具有 Fluent, Map, Notify的功能

型別對應如下 :

Observable => ServiceClient

Observer => Service

Subject => ServiceChannel

更換名字的目的是為了排除掉固有的 Observable 的刻板概念

使用方式如下

```csharp
    
    var actual = string.Empty;
    var input = Chain.From<string>();

    await input.Next(x => x.ToString())
        .Next(x => x.Count())
        .Run(x => actual = x.ToString());

    input.Execute(this);
    // actual will be this type to string's length string    

```

更多使用方式可參考測試專案

## Rx還有什麼?

Rx 其實運用了非常多的近代的開發技術 

像是巧妙的使用 Flient Interface 來串接方法

透過 Currying 的概念簡化非同步的棘手問題

利用 Fluent Interface 以最簡單的方式完成 Constructor Injection Decorator

用 Observable 和 Observer 的交互關係轉換成為 類似 Proxy 的概念來實際操作物件

將功能細切至近乎可各自獨立 符合 solid, kiss 等等原則 

而且 也具有 exception handling, finally, disposable 等我們常常遺漏的東西

只要運用得當, 一樣可以寫出高可讀性的程式碼 (ex: 把 lambda 換成 method)

裡面有太多值得一看的東西了

這個專案僅將主要的幾個主幹擷取出來並簡化 ~~就是改爛版的意思~~

而希望可以藉此讓使用者了解 這樣的東西還可以如何使用與擴展

## 覺得不夠?

如果您覺得有所收穫 甚至覺得很好用 那我會建議你可以進一步常是真正的 Rx

如果你覺得這很難用 那是理所當然的 因為這是改爛版 所以您更應該使用原本的 Rx

如果你在使用上有問題 歡迎使用Issue來發問

這個 project 的主要目的並非希望大家都使用 Rx

而是希望盡量避免因為一些因為產品介紹而將這樣的好東西排除在常用和學習的考慮之外

## NuGet Feed

基於尚未穩定的緣故，所以暫時沒有規劃上到NuGet.org，如果想直接參考Package可加入下列 NuGet Feed Url

https://www.myget.org/F/core-lib/api/v3/index.json

## License

MIT
