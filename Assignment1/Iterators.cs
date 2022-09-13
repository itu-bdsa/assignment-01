namespace Assignment1;

public static class Iterators
{
  public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
  {
    var output = new List<T>();

    foreach (var item in items)
      output.AddRange(item);

    return output;
  }

  public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
    => throw new NotImplementedException();
}
