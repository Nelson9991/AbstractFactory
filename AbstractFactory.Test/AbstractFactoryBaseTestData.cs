using System.Collections;
using AbstractFactory.Core.Factories;

namespace AbstractFactory.Test;

public class AbstractFactoryBaseTestData : IEnumerable<object[]>
{
    private readonly TheoryData<IVehiculoFactory, string> _data = new();

    protected void AddTestData<TConcreteFactory>(string gama)
        where TConcreteFactory : IVehiculoFactory, new()
    {
        _data.Add(new TConcreteFactory(), gama);
    }

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
