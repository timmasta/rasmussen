//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        //TIP Press <shortcut actionId="ShowIntentionActions"/> with your caret at the highlighted text
        // to see how IntelliJ IDEA suggests fixing it.

        System.out.printf("Hello and welcome!\r");

        Patient patient = new Patient("tim", 170, "06/28/1984", 74);
        System.out.println(patient.getName());
        System.out.println(patient.getHeight());
        System.out.println(patient.getWeight());
        System.out.println(patient.getDateOfBirth());
        Calculations calculations = new Calculations();
        double patientBMI = Calculations.bmi(patient.getHeight(), patient.getWeight());
        System.out.println("BMI is calculated as: " + patientBMI);
        System.out.println(calculations.getPaymentCategory(patientBMI));
    }
}