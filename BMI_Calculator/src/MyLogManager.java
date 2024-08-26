import java.io.IOException;
import java.util.logging.ConsoleHandler;
import java.util.logging.FileHandler;
import java.util.logging.Logger;
import java.util.logging.SimpleFormatter;
import java.util.logging.LogManager;

public class MyLogManager {
	public static void configureLogging() {
        Logger logger = Logger.getLogger(AppLog.class.getName());

        ConsoleHandler consoleHandler = new ConsoleHandler();
        consoleHandler.setFormatter(new LogFormatter());

        LogManager.getLogManager().reset(); // Reset default configuration
        logger.addHandler(consoleHandler);
        
        try {
            // Create a FileHandler to write log messages to a file
            FileHandler fileHandler = new FileHandler("UserEntryApp.log", true);
            fileHandler.setFormatter(new SimpleFormatter()); // You can use your custom formatter here

            logger.addHandler(fileHandler); // Add the file handler to the logger
        } catch (IOException e) {
            logger.severe("Failed to initialize file handler: " + e.getMessage());
        }
        
        logger.setUseParentHandlers(false); // Disable parent handlers to avoid double logging
    }

}
