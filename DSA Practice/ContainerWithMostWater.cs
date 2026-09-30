namespace DSA_Practice
{
    public class ContainerWithMostWater
    {
        private int MaxArea(int[] heights)
        {
            int left = 0, right = heights.Length - 1;
            int currentArea = 0;
            int maxArea = 0;
            int height = 0;

            while (left < right)
            {
                height = Math.Min(heights[left], heights[right]);
                currentArea = (right - left) * height;
                maxArea = Math.Max(currentArea, maxArea);

                if (heights[left] < heights[right])
                {
                    left++;
                }
                else
                    right--;
            }

            return maxArea;
        }

        public static void Main(String[] args)
        {
            ContainerWithMostWater mostWater = new ContainerWithMostWater();
            int[] heights = [1,8,6,2,5,4,8,3,7];
            Console.WriteLine(mostWater.MaxArea(heights));
        }
    }
}