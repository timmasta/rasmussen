import java.util.ArrayList;
import java.util.Random;
//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        int n = 10; // Change this to the desired size of the array
        int min = 100; // Minimum value (inclusive)
        int max = 501; // Maximum value (exclusive)

        // Create an array to hold random integers
        int[] randomArray = new int[n];

        Random random = new Random();
        //populate the array with random integers (size and range are set above)
        for (int i = 0; i < n; i++) {
            randomArray[i] = random.nextInt(max - min) + min; // Generates a random integer between min and max-1
        }

        // Instantiate the arraySort object which prints the sorted array
        ArraySort arraySort = new ArraySort();
        arraySort.sortArray(randomArray);
        arraySort.printSortedArray();
        // Instantiate the arrayAdd object which adds the elements and prints the sum of the array
        ArrayAdd arrayAdd = new ArrayAdd(randomArray);






    }
}