namespace Assignment1;
using static WeekDays;
public static class Iterators
{
    public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items) {
        
        var returnList = new List<T>(); 

        foreach (var item in items)
        {
            foreach (var item2 in item)
            {
                returnList.Add(item2); 
            }
        }
        return returnList; 
    }

    public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
    {   
        foreach(var item in items){
            if(predicate(item))
            {
                yield return item;
            }

        }
    }
    public static bool isFriday(WeekDays day){

        if(day == WeekDays.Friday){
            return true;
        }
        return false;
    
    }
  
    
}