import java.util.logging.Logger;

public class AppLog {
	private static final Logger logger = Logger.getLogger(AppLog.class.getName());
	
	static {
        // Configure logging settings
        MyLogManager.configureLogging();
    }

    public static Logger getLogger() {
        return logger;
    }

    public static void writeToLog(String message) {
        logger.info(message);
    }
	
}
