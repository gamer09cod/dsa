namespace DSA_Practice.Problems;

public class MaxPointsForCards
{
    public int maxScore(int[] cards, int k) {  
        int start = 0;
        int maxSum = int.MinValue;//Sum of cards not in window, maximise it.
        int windowSum = 0;
        
        int totalSum = 0;
        for(int i = 0; i< cards.Length; i++){
            totalSum += cards[i];
        }

        if(k == cards.Length)
            return totalSum;

        for(int end = 0; end < cards.Length; end ++){
            windowSum += cards[end];
            if(end - start + 1 == cards.Length-k){
                //Sum of non-selected cards = Total - windowSum
                maxSum = Math.Max(totalSum - windowSum, maxSum);//Maximise sum for non-selected cards
                windowSum -= cards[start];
                start ++;
            }
        }
        return maxSum;
    }
}