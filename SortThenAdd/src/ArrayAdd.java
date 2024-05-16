public class ArrayAdd extends ArraySort {
    int sum = 0;

    ArrayAdd(int[] numbers) {
        sortArray(numbers); // Call the sorting method from the base class
        addNumbers();
    }

    void addNumbers() {
        for (int num : sortedArray) {
            sum += num; // Adding each number to sum
        }
        System.out.println("Sum of sorted array: " + sum);
    }
}
