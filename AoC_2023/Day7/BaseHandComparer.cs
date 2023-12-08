namespace AoC_2023.Day7;

internal abstract class BaseHandComparer : IComparer<Hand>
{
    protected abstract Dictionary<char, int> LabelValues { get; }
    protected abstract HandType GetHandType(Hand hand);
    
    public int Compare(Hand x, Hand y)
    {
        var xHandType = GetHandType(x);
        var yHandType = GetHandType(y);

        if(xHandType > yHandType)
            return 1;
        
        if(xHandType < yHandType)
            return -1;
        
        for(var i = 0; i < Hand.NumberOfLabels; i++)
        {
            if(LabelValues[x.Labels[i]] > LabelValues[y.Labels[i]])
                return 1;

            if(LabelValues[x.Labels[i]] < LabelValues[y.Labels[i]])
                return -1;
        }

        return 0;
    }
}