using System.Text;

namespace DSA_Practice.Problems;

public class DecodeString
{
    public string decodeString(string s) {
        // Your code goes here
    
        Stack<string> stringStack = new Stack<string>();
        Stack<int> numberStack = new Stack<int>();

        string currentString = "";
        int currentNumber = 0;

        foreach(char c in s){
            if(c == '['){
                stringStack.Push(currentString);
                numberStack.Push(currentNumber);
                currentString = "";
                currentNumber = 0;
            }else if(c == ']'){
                string prevString = stringStack.Pop();
                int prevNumber = numberStack.Pop();

                StringBuilder repeated = new StringBuilder();
                for(int i = 0 ; i< prevNumber; i++){
                    repeated.Append(currentString);
                }
                currentString = prevString + repeated;
            }else if(char.IsDigit(c)){
                currentNumber = currentNumber * 10 + (c - '0');
            }else{
                currentString += c;
            }
        }
        return currentString;
    }
}