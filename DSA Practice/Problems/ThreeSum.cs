namespace DSA_Practice.Problems;


public class ThreeSum {
    public List<List<int>> CalculateThreeSum(int[] nums) {
        
        List<List<int>> result = new List<List<int>>();
        // Sort array to enable two-pointer technique and handle duplicates
        Array.Sort(nums);
        
        // Fix the first element and use two pointers for the remaining two
        for (int i = 0; i < nums.Length - 2; i++) {
            // Skip duplicate values for the first element to avoid duplicate triplets
            if (i > 0 && nums[i] == nums[i - 1]) {
                continue;
            }
            
            // Initialize two pointers for the remaining subarray
            int left = i + 1;
            int right = nums.Length - 1;
            
            // Use two-pointer technique to find pairs that sum to -nums[i]
            while (left < right) {
                int total = nums[i] + nums[left] + nums[right];
                
                if (total < 0) {
                    // Sum too small, move left pointer right to increase sum
                    left++;
                } else if (total > 0) {
                    // Sum too large, move right pointer left to decrease sum
                    right--;
                } else {
                    // Found a valid triplet
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    
                    // Skip all duplicate values to avoid duplicate triplets
                    while (left < right && nums[left] == nums[left + 1]) {
                        left++;
                    }
                    while (left < right && nums[right] == nums[right - 1]) {
                        right--;
                    }
                    // Move both pointers to continue searching
                    left++;
                    right--;
                }
            }
        }
        return result;
    }
    
    /*public static void Main(String[] args)
    {
        ThreeSum threeSum = new ThreeSum();
        int[] nums = [-1,0,1,2,-1,-1];
        Console.WriteLine(threeSum.CalculateThreeSum(nums));
    }*/
}