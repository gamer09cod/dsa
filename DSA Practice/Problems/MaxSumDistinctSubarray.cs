namespace DSA_Practice.Problems;

public class MaxSumDistinctSubarray
{
    public long maxSum(int[] nums, int k) {
        long maxSum = long.MinValue;
        int start = 0;
        Dictionary<int, int> freqMap = new Dictionary<int, int>();
        long currentSum = 0;
    
        for (int end = 0; end < nums.Length; end++) {
            currentSum += nums[end];
            freqMap[nums[end]] = (freqMap.ContainsKey(nums[end]) ? freqMap[nums[end]] : 0) + 1;
        
            if (end - start + 1 == k) {
                if (freqMap.Count == k) {
                    maxSum = Math.Max(maxSum, currentSum);
                }
            
                currentSum -= nums[start];
                freqMap[nums[start]]--;
                if (freqMap[nums[start]] == 0) {
                    freqMap.Remove(nums[start]);
                }
                start++;
            }
        }
    
        return maxSum == long.MinValue ? 0 : maxSum;
    }
    }
}