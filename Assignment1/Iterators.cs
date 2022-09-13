namespace Assignment1;

public static class Iterators
{
    
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items){
        
        foreach (var v in items){
            foreach (var w in v)
            {
                yield return w;
            }    
        
        }
        //items.SelectMany(x=>x).ToList();

    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate) {
        foreach (var v in items)
        {            
            if(predicate(v)){
                yield return v;
            }
        }
    }
}