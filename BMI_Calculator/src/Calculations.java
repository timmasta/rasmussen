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
            //BMI is somehow negative, something went wrong
            paymentCategory = "BMI Out of Range";
            AppLog.getLogger().info("An error occured. BMI must have been less than zero.");
        }
        AppLog.getLogger().info("BMI calculated returning the payment category.");
        return paymentCategory;
    }
}
