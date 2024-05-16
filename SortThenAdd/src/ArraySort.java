import java.util.Arrays;

public class ArraySort {
    int[] sortedArray;

    void sortArray(int[] numbers) {
        Arrays.sort(numbers); // Sorting the array
        sortedArray = numbers;
    }

    void printSortedArray() {
        System.out.println("Sorted array: " + Arrays.toString(sortedArray));
    }
}
