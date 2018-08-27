# NamedIndexers
A small utility library that introduces a generic proxy classes which simulate named indexers (also known as indexed properties) with user-supplied getter and optional setter functions through lambdas or delegates.

## Rationale
Sometimes you may find it logical to have a class with two or more indexers, but it's not obvious from context what each does. Maybe your keys automatically cast into each other which creates ambiguity or  you need two numeric indexers each using a different internal logic. You want to be clear what each indexer does but using getter and setter functions would be cumbersome and not so user friendly. Instead, this library allows you to create small proxy objects with their own indexers which refer back to their host object through lambda expressions.

## Install
You can get it from NuGet under the name `IcIWare.NamedIndexers`.
Alternatively you can download the DLL from the [releases](https://github.com/DAud-IcI/NamedIndexers/releases/tag/1.0.0) and simply add it as a reference.


## Usage
You have two classes at your disposal inside the `IcIWare.NamedIndexers` namespace:
* NamedIndexer : can be used for both getting and setting
* NamedGetter : getter only version
Create a `public readonly` field in your class. Initialize it in the constructor of the host class using lambda expressions. This way the object doesn't have to be aware of its host because the lambda's automatic closure takes care of it all.

```C#
public class ExampleObject
{
    private int[] _numbers = new[] { 4, 8, 15, 16, 23, 42 };
    public readonly NamedIndexer<int, int> TheNumbersButBackwards;
    
    public ExampleObject()
    {
        TheNumbersButBackwards = new NamedIndexer<int, int>(
            i => _numbers[_numbers.Length - 1 - i],
            (i, x) => { _numbers[_numbers.Length - 1 - i] = x; });
    }
    
    public static Main(string[] args)
    {
        var example = new ExampleObject();
        Console.WriteLine("The answer is {0}.", example.TheNumbersButBackwards[0]);
    }
}
```
