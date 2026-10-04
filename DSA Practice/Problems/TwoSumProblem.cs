namespace DSA_Practice.Problems
{
    public class TwoSumProblem
    {
        public bool TwoSum(int[] nums, int target)
        {
            int sum = 0;
            int left = 0, right = nums.Length - 1;

            while (left < right)
            {
                sum = nums[left] + nums[right];
                if (sum == target)
                    return true;
                else if(sum > target)
                    right--;
                else
                    left++;
            }
            return false;
        }
        
        /*public static void Main(String[] args)
        {
            TwoSumProblem twoSum = new TwoSumProblem();
            int target = 13;
            int[] nums = [1, 3, 4, 6, 8, 10, 13];
            Console.WriteLine(twoSum.TwoSum(nums, target));
        }*/
    }
}
