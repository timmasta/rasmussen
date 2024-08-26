import javax.swing.*;
import java.awt.*;
import java.io.*;

public class UserEntry {

    private JPanel mainPanel;
    private JTextField patientName;
    private JSpinner weightSpinner;
    private JSpinner heightSpinner;
    private JSpinner dobSpinner;
    private JButton submitButton;
    private JLabel weightLabel;
    private JLabel dobLabel;
    private JLabel heightLabel;
    private JLabel nameLabel;

    public UserEntry() {
        // Initialize components
        mainPanel = new JPanel(new GridLayout(5, 2, 10, 10));

        nameLabel = new JLabel("Name:");
        patientName = new JTextField(20);

        dobLabel = new JLabel("Date of Birth:");
        dobSpinner = new JSpinner(new SpinnerDateModel());

        weightLabel = new JLabel("Weight:");
        weightSpinner = new JSpinner(new SpinnerNumberModel(0, 0, 300, 1));

        heightLabel = new JLabel("Height:");
        heightSpinner = new JSpinner(new SpinnerNumberModel(0, 0, 300, 1));

        submitButton = new JButton("Submit");
        submitButton.addActionListener(e -> handleSubmit());

        // Add components to panel
        mainPanel.add(nameLabel);
        mainPanel.add(patientName);
        mainPanel.add(dobLabel);
        mainPanel.add(dobSpinner);
        mainPanel.add(weightLabel);
        mainPanel.add(weightSpinner);
        mainPanel.add(heightLabel);
        mainPanel.add(heightSpinner);
        mainPanel.add(new JLabel()); // Empty cell
        mainPanel.add(submitButton);

        // Customize component colors with error handling
        try {
            customizeComponentColors();
        } catch (IllegalArgumentException e) {
            System.err.println("Error setting component colors: " + e.getMessage());
        }
                
    }

    private void customizeComponentColors() {
        // Set colors using hex values
        nameLabel.setForeground(Color.decode("#0000FF")); // Blue
        dobLabel.setForeground(Color.decode("#0000FF")); // Blue
        weightLabel.setForeground(Color.decode("#0000FF")); // Blue
        heightLabel.setForeground(Color.decode("#0000FF")); // Blue

        patientName.setBackground(Color.decode("#D3D3D3")); // Light Gray
        patientName.setForeground(Color.decode("#2F4F4F")); // Dark Slate Gray

        dobSpinner.setBackground(Color.decode("#FFFFFF")); // White
        weightSpinner.setBackground(Color.decode("#FFFFFF")); // White
        heightSpinner.setBackground(Color.decode("#FFFFFF")); // White

        submitButton.setBackground(Color.decode("#008000")); // Green
        submitButton.setForeground(Color.decode("#FFFFFF")); // White
    }

    private void handleSubmit() {
        try {
            String name = patientName.getText();
            String dob = dobSpinner.getValue().toString();
            int weight = (Integer) weightSpinner.getValue();
            int height = (Integer) heightSpinner.getValue();
            Patient patient = new Patient(name, weight, dob, height);
            Calculations calculations = new Calculations();
            double patientBMI = Calculations.bmi(patient.getHeight(), patient.getWeight());
            String rate = calculations.getPaymentCategory(patientBMI);
            String message;
            message = "Name: " + name + "\nDate of Birth: " + dob + "\nWeight: " + weight + "\nHeight: " + height + "\nBMI: " + patientBMI + "\nInsurance Rate: " + rate;
            // Handle form submission, e.g., print values or validate input
            JOptionPane.showMessageDialog(null, message);
            saveToFile(patient);
            AppLog.getLogger().info("Form data has been processed, information has been saved.");
        } catch (Exception e) {
            JOptionPane.showMessageDialog(null, "An error occurred while processing the form: " + e.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
            AppLog.getLogger().info("Form data was not processed, submit failed.");
        }
    }

    private void saveToFile(Patient patient) {
        String fileName = "Results.txt";
        Calculations calculations = new Calculations();
        double patientBMI = Calculations.bmi(patient.getHeight(), patient.getWeight());
        String rate = calculations.getPaymentCategory(patientBMI);
        // Writing to the output file (set the second argument to true to append the file)
        try (BufferedWriter bw = new BufferedWriter(new FileWriter(fileName, true))) {
            //output patient information to a text file
            bw.write("Patient Name: " + patient.getName() + "\n");
            bw.write("Patient Weight: " + patient.getWeight() + " lbs\n");
            bw.write("Patient Height: " + patient.getHeight() + " inches\n");
            bw.write("Patient DOB: " + patient.getDateOfBirth() + "\n");
            bw.write("Patient BMI: " + patientBMI + "\n");
            bw.write("Patient Insurance Rate: " + rate + "\n");
            bw.write("\n");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public JPanel getMainPanel() {
        return mainPanel;
    }

    public static void main(String[] args) {
    	
        // Set up the Swing UI with error handling
        SwingUtilities.invokeLater(() -> {
            try {
                JFrame frame = new JFrame("User Entry Form");
                UserEntry userEntry = new UserEntry();
                frame.setContentPane(userEntry.getMainPanel());
                frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                frame.pack();
                frame.setVisible(true);
                
                AppLog.getLogger().info("Application Started, User form loaded");
            } catch (Exception e) {
                JOptionPane.showMessageDialog(null, "An error occurred while setting up the UI: " + e.getMessage(), "Error", JOptionPane.ERROR_MESSAGE);
                AppLog.getLogger().info("Error loading UI form.");
            }
        });

    }
}
