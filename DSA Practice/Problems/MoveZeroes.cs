namespace DSA_Practice.Problems;

public class MoveZeroes
{
    public void MoveZeroesFunc(int[] nums) {
        int insertPointer = 0;
        int temp = 0;
        for(int i = 0; i<nums.Length; i++){
            if(nums[i] != 0){
                temp = nums[i];
                nums[i] = nums[insertPointer];
                nums[insertPointer] = temp;
                insertPointer ++;
            }
        }
    }
}