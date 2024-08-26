import java.util.logging.Handler;
import java.util.logging.LogRecord;

public class ConsoleHandler extends Handler{
	
	@Override
    public void publish(LogRecord record) {
        System.out.println(getFormatter().format(record));
    }
	
	@Override
    public void flush() {
        // No need to flush for console output
		//Included this to resolve errors
    }

    @Override
    public void close() throws SecurityException {
        // No resources to close
    	//Included this to resolve errors
    }
}
