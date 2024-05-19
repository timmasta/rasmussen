public class Calculations {
    static double bmi;
    String paymentCategory;

    static double bmi(double ht, double wt){
        bmi = ((wt/(ht * ht)) * 703);
        return bmi;
    }

    String getPaymentCategory(double bmiCalculation){
        String paymentCategory = "";
        if (bmiCalculation > 0 && bmiCalculation < 18.5){
            paymentCategory = "Low";
        }
        else if(bmiCalculation >= 18.5 && bmiCalculation < 25){
            paymentCategory = "Low";
        }
        else if(bmiCalculation >= 25 && bmiCalculation < 30){
            paymentCategory = "High";
        }
        else if(bmiCalculation >= 30){
            paymentCategory = "Highest";
        }
        else{
            //bmi is somehow negative, something went wrong
            paymentCategory = "BMI Out of Range";
        }
        return paymentCategory;
    }
}
