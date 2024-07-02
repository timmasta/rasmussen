public class Patient implements PatientGuidelines {
    private String name;
    private double weight;
    private String dateOfBirth;
    private double height;

    Patient(String nm, double wt, String dob, double ht){
        name = nm;
        weight = wt;
        dateOfBirth = dob;
        height = ht;
    }

    public String getName(){
        return name;
    }
    public double getWeight(){
        return weight;
    }
    public String getDateOfBirth(){
        return dateOfBirth;
    }
    public double getHeight(){
        return height;
    }
}
