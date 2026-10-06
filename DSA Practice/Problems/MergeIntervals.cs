namespace DSA_Practice.Problems;

public class MergeOverlapIntervals
{
        public int[][] MergeIntervals(int[][] intervals) {
            // Your code goes here
            Array.Sort(intervals, (a,b) => a[0] - b[0]);
            List<int[]> merged = new List<int[]>();

            foreach(var interval in intervals){
                if(merged.Count == 0 || merged[merged.Count - 1][1] < interval[0]){
                    merged.Add(interval);
                }

                if(interval[0] <= merged[merged.Count - 1][1]){
                    merged[merged.Count - 1][0] = Math.Min(merged[merged.Count - 1][0],
                        interval[0]);//Set start as min of cuurent and merged interval
                    merged[merged.Count - 1][1] = Math.Max(merged[merged.Count - 1][1]
                        , interval[1]);//Set end as max of current and merged intevral
                }
            }

            return merged.ToArray();
        }
}
