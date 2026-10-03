namespace DSA_Practice;

public class TrappingRainWater
{
    private int leftMax = 0;
    private int rightMax = 0;
    private int filledWater = 0;
    public int TrappingWater(int[] height) {
        int left = 0, right = height.Length -1;
        leftMax = height[left];
        rightMax = height[right];

        while(left < right){
            if(leftMax < rightMax){
                left++;
                if(height[left] < leftMax)
                    filledWater += leftMax - height[left];
                leftMax = Math.Max(height[left], leftMax);
            }else{
                right--;
                if(height[right] < rightMax)
                    filledWater += rightMax - height[right];
                rightMax = Math.Max(height[right], rightMax);
            }
        }
        return filledWater;
    }
}